using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IMetricsRepository
    {
        Task<IEnumerable<EndpointMetric>> Get();        
        Task Add(EndpointMetric metrics);    
        Task AddMany(IEnumerable<EndpointMetric> metrics);        
    }
}