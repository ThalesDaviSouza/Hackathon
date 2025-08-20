using Serilog;
using SimuladorCredito.Api.Middlewares;

namespace SimuladorCredito.Api.Configuration
{
    public static class MiddlewareConfiguration
    {
        public static IApplicationBuilder ConfigMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
            app.UseResponseCaching();
            app.UseMiddleware<MetricsMiddleware>();

            app.UseSerilogRequestLogging(options =>
            {
                options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
                options.GetLevel = (httpContext, elapsed, ex) =>
                {
                    return ex != null || httpContext.Response.StatusCode >= 500
                        ? Serilog.Events.LogEventLevel.Error
                        : Serilog.Events.LogEventLevel.Information;
                };
            });

            return app;
        }
    }
}