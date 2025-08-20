using SimuladorCredito.Api.Middlewares;

namespace SimuladorCredito.Api.Configuration
{
    public static class MiddlewareConfiguration
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
            return app.UseMiddleware<MetricsMiddleware>();
        }
    }
}