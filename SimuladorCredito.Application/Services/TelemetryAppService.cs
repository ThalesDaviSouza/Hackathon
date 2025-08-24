using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Application.Services
{
    public class TelemetryAppService
    {
        private readonly IMetricsService _metricsService;

        public TelemetryAppService(IMetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        public async Task Add(EndpointMetric endpointMetrics)
        {
            await _metricsService.Add(endpointMetrics);
        }

        public async Task<IEnumerable<EndpointMetric>> Get()
        {
            return await _metricsService.Get();
        }
    }
}