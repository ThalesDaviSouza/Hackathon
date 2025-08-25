using FluentValidation;
using FluentValidation.AspNetCore;
using SimuladorCredito.Application.Dtos.Requests;

namespace SimuladorCredito.Api.Configuration
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
                
            services.AddValidatorsFromAssemblyContaining<CreateSimulationDto>();

            return services;
        }
    }
}