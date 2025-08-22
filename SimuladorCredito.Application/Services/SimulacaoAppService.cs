using AutoMapper;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Domain.Exceptions.HttpExceptions;
using SimuladorCredito.Interfaces.Services;
using SimuladorCredito.Interfaces.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class SimulacaoAppService
    {
        private readonly IEnumerable<IResultadoSimulacaoCalculator> _calculators;
        private readonly ProdutoAppService _produtoAppService;
        private readonly IMapper _mapper;
        private readonly IEventHubService _eventHubService;
        private readonly IUnitOfWork _uow;

        public SimulacaoAppService(
            IEnumerable<IResultadoSimulacaoCalculator> calculators,
            ProdutoAppService produtoAppService,
            IMapper mapper,
            IEventHubService eventHubService,
            IUnitOfWork uow
        )
        {
            _calculators = calculators;
            _produtoAppService = produtoAppService;
            _mapper = mapper;
            _eventHubService = eventHubService;
            _uow = uow;
        }

        public async Task<SimulationCreatedDto> Simulate(short prazo, decimal valorDesejado)
        {
            var produto = await _produtoAppService.GetProdutoToSimulation(valorDesejado, prazo);

            if (produto == null)
                throw new NotFoundException("Não foi encontrado um produto dentro dos parâmetros solicitados");

            Simulacao simulacao = new Simulacao();
            simulacao.CoProduto = produto.CoProduto;

            decimal taxaJuros = produto.PcTaxaJuros;
            foreach (var calculator in _calculators)
            {
                var resultadoSimulacao = calculator.Simulate(prazo, valorDesejado, taxaJuros);
                resultadoSimulacao.CoResultaSimulacao = simulacao.ResultadosSimulacao.Count;
                simulacao.ResultadosSimulacao.Add(resultadoSimulacao);
            }

            var simulacaoSaved = await SaveSimulation(simulacao);

            var simulacaoDto = _mapper.Map<SimulationCreatedDto>(simulacaoSaved);

            simulacaoDto.descricaoProduto = produto.NoProduto;
            simulacaoDto.taxaJuros = produto.PcTaxaJuros;


            await _eventHubService.SendAsync(simulacaoDto);

            return simulacaoDto;
        }

        public async Task<Simulacao> SaveSimulation(Simulacao simulacao)
        {
            await _uow.BeginTransactionAsync();
            await _uow.Simulacoes.Create(simulacao);
            await _uow.CommitAsync();

            return simulacao;
        }
    }
}