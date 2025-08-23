using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Application.ReadModels.Responses;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Repositories
{
    public interface ISimulacaoRepository : IBaseLocalRepository<Simulacao>
    {
        public Task<PagedReturnDto<SimulationResumeDto>> GetPaged(int offset, int pageSize);
    }
}