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
        private readonly ISimulacaoService _simulacaoService;
        private readonly IUnitOfWork _uow;

        public SimulacaoAppService(
            IEnumerable<IResultadoSimulacaoCalculator> calculators,
            ProdutoAppService produtoAppService,
            IMapper mapper,
            IEventHubService eventHubService,
            ISimulacaoService simulacaoService,
            IUnitOfWork uow
        )
        {
            _calculators = calculators;
            _produtoAppService = produtoAppService;
            _mapper = mapper;
            _eventHubService = eventHubService;
            _simulacaoService = simulacaoService;
            _uow = uow;
        }

        public async Task<SimulationCreatedDto> Simulate(short prazo, decimal valorDesejado)
        {
            var produto = await _produtoAppService.GetProdutoToSimulation(valorDesejado, prazo);

            if (produto == null)
                throw new BadRequestException("Não existe um produto que atenda aos parâmetros solicitados");

            var simulacao = _simulacaoService.CreateSimulation(
                _calculators,
                produto.CoProduto,
                produto.PcTaxaJuros,
                prazo,
                valorDesejado
            );
            
            await _uow.BeginTransactionAsync();
            await _simulacaoService.SaveSimulation(simulacao);
            await _uow.CommitAsync();

            var simulacaoDto = _mapper.Map<SimulationCreatedDto>(simulacao);

            simulacaoDto.descricaoProduto = produto.NoProduto;


            await _eventHubService.SendAsync(simulacaoDto);

            return simulacaoDto;
        }
    }
}