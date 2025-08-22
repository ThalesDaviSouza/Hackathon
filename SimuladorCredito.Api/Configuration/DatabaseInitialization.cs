using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Infra.Persistance;

namespace SimuladorCredito.Api.Configuration
{
    public static class DatabaseInitialization
    {
        public static WebApplication InitializateDataBase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BancoLocalDbContext>();
                db.Database.Migrate();
            }

            return app;
        }
    }
}