using Microsoft.OpenApi.Models;

namespace SimuladorCredito.Api.Configuration
{
  public static class SwaggerConfiguration
  {
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "Simulador de Crédito API",
          Version = "v1",
          Description = "API para simulação de crédito"
        });
      });

      return services;
    }

    public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
    {
      app.UseSwagger();
      app.UseSwaggerUI();

      return app;
    }
  }
}
