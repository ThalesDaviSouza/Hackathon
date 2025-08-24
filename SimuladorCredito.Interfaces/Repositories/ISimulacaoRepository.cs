using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Application.ReadModels.Responses;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Repositories
{
    public interface ISimulacaoRepository : IBaseLocalRepository<Simulacao>
    {
        Task<PagedReturnDto<SimulationResumeDto>> GetPaged(int offset, int pageSize);

        Task<IEnumerable<SimulationsByProductDto>> GetGroupedByProducts();
    }
}