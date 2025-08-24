using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IMetricsRepository
    {
        Task<IEnumerable<EndpointMetrics>> Get();        
        Task Add(EndpointMetrics metrics);    
    }
}