namespace SimuladorCredito.Api.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfig();
            services.AddControllers();
            services.AddDependencyInjection();
            services.AddResponseCaching();
            services.AddFluentValidation();

            return services;
        }
    }
}