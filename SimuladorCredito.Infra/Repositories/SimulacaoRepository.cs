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
            await _dbSet.AddAsync(simulacao);
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