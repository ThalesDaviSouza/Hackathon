using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace SimuladorCredito.Api.Configuration
{
    public static class OpenTelemetryConfiguration
    {
        public static IServiceCollection AddOpenTelemetryConfiguration(this IServiceCollection services, string serviceName)
        {
            services.AddOpenTelemetry()
                .WithTracing(tracerProviderBuilder =>
                {
                    tracerProviderBuilder
                        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName))
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddConsoleExporter();
                })
                .WithMetrics(metricsProviderBuilder =>
                {
                    metricsProviderBuilder
                        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName))
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddConsoleExporter();
                });

            return services;
        }
    }
}
