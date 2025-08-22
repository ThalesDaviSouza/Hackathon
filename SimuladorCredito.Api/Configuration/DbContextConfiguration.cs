using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Infra.Persistance;

namespace SimuladorCredito.Api.Configuration
{
    public static class DbContextConfiguration
    {
        public static WebApplicationBuilder ConfigDbContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ProdutoDbContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("HackathonConnection"))
            );

            builder.Services.AddDbContext<BancoLocalDbContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("LocalConnection"))
            );

            return builder;
        }
    }
}