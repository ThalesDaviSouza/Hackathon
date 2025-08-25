using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.ReadModels;
using SimuladorCredito.Interfaces.Repositories;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Infra.Services
{
    public class MetricsService : IMetricsService
    {
        private readonly IMetricsRepository _metricsRepository;

        public MetricsService(IMetricsRepository metricsRepository)
        {
            _metricsRepository = metricsRepository;
        }

        public async Task Add(EndpointMetric metrics)
        {
            await _metricsRepository.Add(metrics);
        }

        public async Task AddMany(IEnumerable<EndpointMetric> metrics)
        {
            await _metricsRepository.AddMany(metrics);
        }

        public async Task<IEnumerable<EndpointMetric>> Get()
        {
            return await _metricsRepository.Get();
        }

        public async Task<TelemetryPerDayDto> GetPerDay(DateTime? dataReferencia)
        {
            return await _metricsRepository.GetPerDay(dataReferencia);
        }
    }
}