using System.Diagnostics;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Api.Middlewares
{
    public class TelemetryMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMetricsService _metricsService;


        public TelemetryMiddleware(RequestDelegate next, IMetricsService metricsService)
        {
            _next = next;
            _metricsService = metricsService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            await _next(context);
            sw.Stop();

            var metric = new EndpointMetric
            {
                DataReferencia = DateTime.Now,
                Endpoint = context.Request.Path,
                Duration = sw.Elapsed.TotalMilliseconds,
                StatusResponse = context.Response.StatusCode,
                Method = context.Request.Method
            };

            await _metricsService.Add(metric);
        }
    }
}
