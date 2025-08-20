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

            return app;
        }
    }
}