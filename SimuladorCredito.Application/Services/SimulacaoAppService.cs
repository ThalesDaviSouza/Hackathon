using AutoMapper;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Domain.Exceptions.HttpExceptions;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Application.Services
{
    public class SimulacaoAppService
    {
        private readonly IEnumerable<IResultadoSimulacaoCalculator> _calculators;
        private readonly ProdutoAppService _produtoAppService;
        private readonly IMapper _mapper;
        private readonly IEventHubService _eventHubService;

        public SimulacaoAppService(
            IEnumerable<IResultadoSimulacaoCalculator> calculators,
            ProdutoAppService produtoAppService,
            IMapper mapper,
            IEventHubService eventHubService
        )
        {
            _calculators = calculators;
            _produtoAppService = produtoAppService;
            _mapper = mapper;
            _eventHubService = eventHubService;
        }

        public async Task<SimulationCreatedDto> Simulate(short prazo, decimal valorDesejado)
        {
            var produto = await _produtoAppService.GetProdutoToSimulation(valorDesejado);

            if (produto == null)
                throw new BadRequestException("Produto correspondente não encontrado");

            decimal taxaJuros = produto.PcTaxaJuros;

            Simulacao simulacao = new Simulacao();
            simulacao.Produto = produto;

            foreach (var calculator in _calculators)
            {
                var resultadoSimulacao = calculator.Simulate(prazo, valorDesejado, taxaJuros);
                simulacao.ResultadosSimulacao.Add(resultadoSimulacao);
            }

            var simulacaoDto = _mapper.Map<SimulationCreatedDto>(simulacao);

            await _eventHubService.SendAsync(simulacaoDto);

            return simulacaoDto;
        }
    }
}