using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infra.Persistance.Configuration
{
    public static class ResultadosSimulacoesConfiguration
    {
        public static ModelBuilder ConfigResultadosSimulacoes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultadoSimulacao>(entity =>
            {
                entity.ToTable("RESULTADOS_SIMULACOES");

                entity.HasKey(p => new { p.CoSimulacao, p.CoResultaSimulacao });

                entity.Property(p => p.CoResultaSimulacao).HasColumnName("CO_RESULTADO_SIMULACAO");
                entity.Property(p => p.CoSimulacao).HasColumnName("CO_SIMULACAO");
                entity.Property(p => p.Tipo).HasColumnName("TIPO");

                entity.HasOne(p => p.Simulacao)
                    .WithMany(res => res.ResultadosSimulacao)
                    .HasForeignKey(p => p.CoSimulacao)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            return modelBuilder;
        }
    }
}