using SimuladorCredito.Interfaces.Repositories;
using SimuladorCredito.Infra.Repositories;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infra.Services;
using SimuladorCredito.Interfaces.Services;
using SimuladorCredito.Application.Services;

namespace SimuladorCredito.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // Repositórios
            services.AddScoped<IProdutoRepository<Produto>, ProdutoRepository>();

            // Serviços de Infra
            services.AddScoped<IProdutoService, ProdutoService>();

            // Serviços de Application
            services.AddScoped<ProdutoAppService>();

            return services;
        }
    }
}
