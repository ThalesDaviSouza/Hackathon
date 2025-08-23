using AutoMapper;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Application.ReadModels.Responses;
using SimuladorCredito.Interfaces.Services;
using SimuladorCredito.Interfaces.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class GetSimulacaoAppService
    {
        private readonly ProdutoAppService _produtoAppService;
        private readonly ISimulacaoService _simulacaoService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public GetSimulacaoAppService(
            ProdutoAppService produtoAppService,
            ISimulacaoService simulacaoService,
            IMapper mapper,
            IUnitOfWork uow
        )
        {
            _produtoAppService = produtoAppService;
            _simulacaoService = simulacaoService;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<PagedReturnDto<SimulationResumeDto>> Get(
            int page,
            int pageSize
        )
        {
            var results = await _simulacaoService.GetPaged(page, pageSize);
            return results;
        }
        
        public async Task<IEnumerable<SimulationCreatedDto>> GetAll()
        {
            // TODO: refatorar isso
            var results = await _uow.ResultadosSimulacoes.Get();
            var parcelas = await _uow.Parcelas.Get();
            var simulations = await _uow.Simulacoes.Get();
            foreach (var simulation in simulations)
            {
                simulation.ResultadosSimulacao = results.Where(s => s.CoSimulacao == simulation.CoSimulacao).ToList();

                foreach (var result in simulation.ResultadosSimulacao)
                {
                    result.Parcelas = parcelas.Where(s => s.CoResultaSimulacao == result.CoResultaSimulacao).ToList();
                }
            }
            var retorno = _mapper.Map<ICollection<SimulationCreatedDto>>(simulations);

            return retorno;
        }
    }
}