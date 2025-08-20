using System.Collections.Concurrent;
using System.Diagnostics;

namespace SimuladorCredito.Api.Middlewares
{
    public class MetricsMiddleware
    {
        private readonly RequestDelegate _next;

        private static readonly ConcurrentDictionary<string, EndpointMetrics> _metrics = new();

        public MetricsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            string endpoint = context.Request.Path;
            int statusCode = context.Response.StatusCode;
            double durationMs = stopwatch.Elapsed.TotalMilliseconds;

            var endpointMetrics = _metrics.GetOrAdd(endpoint, new EndpointMetrics());

            lock (endpointMetrics)
            {
                endpointMetrics.TotalRequests++;
                endpointMetrics.TotalDuration += durationMs;
                endpointMetrics.MinDuration = Math.Min(endpointMetrics.MinDuration, durationMs);
                endpointMetrics.MaxDuration = Math.Max(endpointMetrics.MaxDuration, durationMs);
                if (statusCode == 200)
                    endpointMetrics.SuccessRequests++;
            }
        }

        public static IReadOnlyDictionary<string, EndpointMetrics> GetMetrics()
        {
            return _metrics;
        }
    }

    public class EndpointMetrics
    {
        public int TotalRequests { get; set; } = 0;
        public double TotalDuration { get; set; } = 0;
        public double MinDuration { get; set; } = double.MaxValue;
        public double MaxDuration { get; set; } = double.MinValue;
        public int SuccessRequests { get; set; } = 0;

        public double AverageDuration => TotalRequests == 0 ? 0 : TotalDuration / TotalRequests;
        public double SuccessPercentage => TotalRequests == 0 ? 0 : ((double)SuccessRequests / TotalRequests) * 100;
    }
}
