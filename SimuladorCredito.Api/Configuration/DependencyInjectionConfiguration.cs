using SimuladorCredito.Interfaces.Repositories;
using SimuladorCredito.Infra.Repositories;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infra.Services;
using SimuladorCredito.Interfaces.Services;
using SimuladorCredito.Application.Services;
using SimuladorCredito.Infra.Services.ResultadoSimulacaoCalculators;
using SimuladorCredito.Interfaces.UnitOfWork;
using SimuladorCredito.Infra.UnitOfWork;

namespace SimuladorCredito.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // Repositórios
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ISimulacaoRepository, SimulacaoRepository>();
            services.AddScoped<IBaseLocalRepository<ResultadoSimulacao>, LocalRepository<ResultadoSimulacao>>();
            services.AddScoped<IBaseLocalRepository<Parcela>, LocalRepository<Parcela>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMetricsRepository, MetricsRepository>();

            // Serviços de Infra
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IResultadoSimulacaoCalculator, SACCalculator>();
            services.AddScoped<IResultadoSimulacaoCalculator, PRICECalculator>();
            services.AddScoped<IEventHubService, EventHubService>();
            services.AddScoped<ISimulacaoService, SimulacaoService>();

            // Serviços de Application
            services.AddScoped<ProdutoAppService>();
            services.AddScoped<SimulacaoAppService>();
            services.AddScoped<GetSimulacaoAppService>();
            services.AddScoped<TelemetryAppService>();

            return services;
        }
    }
}
