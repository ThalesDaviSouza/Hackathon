using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infra.Persistance.Configuration;

namespace SimuladorCredito.Infra.Persistance
{
    public class BancoLocalDbContext : DbContext
    {
        public BancoLocalDbContext(DbContextOptions<BancoLocalDbContext> options)
        : base(options) { }

        public DbSet<Simulacao> Simulacoes { get; set; }
        public DbSet<ResultadoSimulacao> ResultadosSimulacoes { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigSimulacoes();
            modelBuilder.ConfigResultadosSimulacoes();
            modelBuilder.ConfigParcelas();

            base.OnModelCreating(modelBuilder);
        }
        
    }
}