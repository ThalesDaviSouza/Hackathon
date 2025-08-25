using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.ReadModels;

namespace SimuladorCredito.Interfaces.Services
{
    public interface IMetricsService
    {
        Task<IEnumerable<EndpointMetric>> Get();
        Task<TelemetryPerDayDto> GetPerDay(DateTime? dataReferencia);  
        Task Add(EndpointMetric metrics);
        Task AddMany(IEnumerable<EndpointMetric> metrics);
    }
}