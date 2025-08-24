using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Services
{
    public interface IMetricsService
    {
        Task<IEnumerable<EndpointMetric>> Get();        
        Task Add(EndpointMetric metrics);
        Task AddMany(IEnumerable<EndpointMetric> metrics);
    }
}