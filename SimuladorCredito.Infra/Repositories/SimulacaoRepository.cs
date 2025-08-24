using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Application.ReadModels.Responses;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infra.Persistance;
using SimuladorCredito.Interfaces.Repositories;

namespace SimuladorCredito.Infra.Repositories
{
    public class SimulacaoRepository : LocalRepository<Simulacao>, ISimulacaoRepository
    {
        private readonly IProdutoRepository _produtoRepository;

        public SimulacaoRepository(
            BancoLocalDbContext context,
            IProdutoRepository produtoRepository
        ) : base(context)
        {
            _produtoRepository = produtoRepository;
        }

        public override async Task Create(Simulacao simulacao)
        {
            simulacao.DataReferencia = DateTime.Today;
            await _dbSet.AddAsync(simulacao);
        }

        public async Task<IEnumerable<SimulationsByProductDto>> GetGroupedByProducts()
        {
            var groupParcelas = _context.Parcelas
                .AsNoTracking()
                .GroupBy(p => p.CoSimulacao)
                .Select(p => new
                {
                    CoSimulacao = p.Key,
                    valorMedioPrestacao = p.Average(pp => pp.ValorAmortizacao + pp.ValorJuros),
                    valorTotalCredito = p.Sum(pp => pp.ValorAmortizacao + pp.ValorJuros)
                });

            var simulationsByProduct = await _dbSet
                .AsNoTracking()
                .GroupBy(s => s.DataReferencia)
                .Select(simulationsByDate => new SimulationsByProductDto
                {
                    dataReferencia = simulationsByDate.Key,
                    simulacoes = simulationsByDate
                        .GroupBy(s => s.CoProduto)
                        .Select(simulations => new SimulationsByProductItemDto
                        {
                            codigoProduto = simulations.Key,
                            taxaMediaJuros = simulations.Average(s => s.PcTaxaJuros),
                            valorTotalDesejado = simulations.Sum(s => s.ValorDesajado),
                            valorTotalCredito = (
                                from simulation in simulations
                                join parcelas in groupParcelas
                                    on simulation.CoSimulacao equals parcelas.CoSimulacao
                                select parcelas.valorTotalCredito
                            ).Sum(),

                            valorMedioPrestacao = (
                                from simulation in simulations
                                join parcelas in groupParcelas
                                    on simulation.CoSimulacao equals parcelas.CoSimulacao
                                select parcelas.valorMedioPrestacao
                            ).Average()
                        })
                })
                .ToListAsync();


            if (!simulationsByProduct.Any())
                return new List<SimulationsByProductDto>();

            // TODO: buscar no cache antes de buscar no banco
            var produtos = await _produtoRepository.Get();
            var produtosDictionary = produtos.ToDictionary(s => s.CoProduto);

            foreach (var group in simulationsByProduct)
            {
                foreach (var simulacao in group.simulacoes)
                {
                    simulacao.descricaoProduto = produtosDictionary[simulacao.codigoProduto].NoProduto;
                }
            }

            return simulationsByProduct;
        }

        public async Task<PagedReturnDto<SimulationResumeDto>> GetPaged(int offset, int pageSize)
        {
            IQueryable<Simulacao> query = _dbSet
                .AsNoTracking()
                .OrderBy(s => s.CoSimulacao);

            query = query.Skip(offset);

            var results = await query
                .Take(pageSize)
                .Select(simulacao => new SimulationResumeDto
                {
                    idSimulacao = simulacao.CoSimulacao,
                    prazo = simulacao.Prazo,
                    valorDesejado = simulacao.ValorDesajado,
                    valorTotalParcelas = simulacao.ResultadosSimulacao
                        .SelectMany(resultado => resultado.Parcelas)
                        .Sum(p => p.ValorAmortizacao + p.ValorJuros)
                })
                .ToListAsync();

            var simulationsCount = await _dbSet.CountAsync();

            return new PagedReturnDto<SimulationResumeDto>
            {
                page = (int)(offset / pageSize) + 1,
                qtdRegistros = simulationsCount,
                qtdRegistrosPagina = results.Count(),
                registros = results
            };
        }

    
  }
}