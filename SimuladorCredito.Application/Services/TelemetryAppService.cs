using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.ReadModels;
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

        public async Task<TelemetryPerDayDto> Get(DateTime? dataReferencia)
        {
            return await _metricsService.GetPerDay(dataReferencia);
        }
    }
}