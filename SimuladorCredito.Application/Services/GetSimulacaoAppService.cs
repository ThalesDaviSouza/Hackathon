using AutoMapper;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Interfaces.ReadModels;
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
        
        public async Task<IEnumerable<SimulationsByProductDto>> GetByProducts()
        {
            return await _simulacaoService.GetGroupedByProducts();
        }
     }
}