using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.ReadModels;

namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IMetricsRepository
    {
        Task<IEnumerable<EndpointMetric>> Get();  
        Task<TelemetryPerDayDto> GetPerDay(DateTime? dataReferencia);  
        Task Add(EndpointMetric metrics);    
        Task AddMany(IEnumerable<EndpointMetric> metrics);        
    }
}