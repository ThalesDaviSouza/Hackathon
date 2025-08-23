using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infra.Persistance.Configuration
{
    public static class SimulacoesConfiguration
    {
        public static ModelBuilder ConfigSimulacoes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Simulacao>(entity =>
            {
                entity.ToTable("Simulacoes");

                entity.HasKey(p => p.CoSimulacao );

                entity.Property(p => p.CoSimulacao).HasColumnName("CO_SIMULACAO");
                entity.Property(p => p.CoProduto).HasColumnName("CO_PRODUTO").IsRequired();
                entity.Property(p => p.PcTaxaJuros).HasColumnName("PC_TAXA_JUROS")
                    .HasPrecision(12, 8)
                    .IsRequired();

            });

            return modelBuilder;
        }
    }
}