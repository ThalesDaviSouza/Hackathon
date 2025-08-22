using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infra.Persistance.Configuration
{
    public static class ParcelasConfiguration
    {
        public static ModelBuilder ConfigParcelas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcela>(entity =>
            {
                entity.ToTable("Parcelas");

                entity.HasKey(p => new { p.CoResultaSimulacao, p.Numero });

                entity.Property(p => p.CoSimulacao).HasColumnName("CO_SIMULACAO");
                entity.Property(p => p.CoResultaSimulacao).HasColumnName("CO_RESULTADO_SIMULACAO");
                entity.Property(p => p.Numero).HasColumnName("NUMERO");
                entity.Property(p => p.ValorAmortizacao)
                    .HasColumnName("VALOR_AMORTIZACAO")
                    .HasPrecision(22, 10); // Precisão para simular a HP-12C
                entity.Property(p => p.ValorJuros)
                    .HasColumnName("VALOR_JUROS")
                    .HasPrecision(22, 10); // Precisão para simular a HP-12C

                entity.HasOne(p => p.ResultadoSimulacao)
                    .WithMany(res => res.Parcelas)
                    .HasForeignKey(p => new { p.CoSimulacao, p.CoResultaSimulacao })
                    .OnDelete(DeleteBehavior.Cascade);
            });

            return modelBuilder;
        }
    }
}