using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.ReadModels;

namespace SimuladorCredito.Interfaces.Repositories
{
    public interface ISimulacaoRepository : IBaseLocalRepository<Simulacao>
    {
        Task<PagedReturnDto<SimulationResumeDto>> GetPaged(int offset, int pageSize);

        Task<IEnumerable<SimulationsByProductDto>> GetGroupedByProducts();
    }
}