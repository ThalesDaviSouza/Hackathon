using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Repositories;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Application.Services
{
    public class TelemetryAppService
    {
        private readonly IMetricsRepository _metricsRepository;

        public TelemetryAppService(IMetricsRepository metricsRepository)
        {
            _metricsRepository = metricsRepository;
        }

        public async Task Add(EndpointMetrics endpointMetrics)
        {
            await _metricsRepository.Add(endpointMetrics);
        }

        public async Task<IEnumerable<EndpointMetrics>> Get()
        {
            return await _metricsRepository.Get();
        }
    }
}