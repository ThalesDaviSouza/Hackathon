using AutoMapper;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Interfaces.UnitOfWork;

namespace SimuladorCredito.Application.Services
{
    public class GetSimulacaoAppService
    {
        private readonly ProdutoAppService _produtoAppService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public GetSimulacaoAppService(
            ProdutoAppService produtoAppService,
            IMapper mapper,
            IUnitOfWork uow
        )
        {
            _produtoAppService = produtoAppService;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<SimulationCreatedDto>> GetAll()
        {
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