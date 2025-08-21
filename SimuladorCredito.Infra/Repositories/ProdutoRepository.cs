using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infra.Persistance;
using SimuladorCredito.Interfaces.Repositories;

namespace SimuladorCredito.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository<Produto>
    {
        private readonly ProdutoDbContext _context;

        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
        }

        public async Task<Produto?> GetToSimulation(decimal valorDesejado)
        {
            return await _context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(produto =>
                    produto.VrMinimo <= valorDesejado && (produto.VrMaximo == null || produto.VrMaximo >= valorDesejado)
                )!;
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }
  }
}