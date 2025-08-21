using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infra.Persistance
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options)
        : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.HasKey(p => p.CoProduto);

                entity.Property(p => p.CoProduto)
                    .HasColumnName("CO_PRODUTO");

                entity.Property(p => p.NoProduto)
                    .HasColumnName("NO_PRODUTO");

                entity.Property(p => p.PcTaxaJuros)
                    .HasColumnName("PC_TAXA_JUROS");

                entity.Property(p => p.NuMinMeses)
                    .HasColumnName("NU_MINIMO_MESES");

                entity.Property(p => p.NuMaxMeses)
                    .HasColumnName("NU_MAXIMO_MESES");

                entity.Property(p => p.VrMinimo)
                    .HasColumnName("VR_MINIMO");

                entity.Property(p => p.VrMaximo)
                    .HasColumnName("VR_MAXIMO");
            });

            base.OnModelCreating(modelBuilder);
        }
        
    }
}