using SimuladorCredito.Api.Middlewares;

namespace SimuladorCredito.Api.Configuration
{
    public static class ErrorMiddlewareConfiguration
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorMiddleware>();
        }
    }
}