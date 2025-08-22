using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Infra.Persistance;
using SimuladorCredito.Interfaces.Repositories;

namespace SimuladorCredito.Infra.Repositories
{
  public class LocalRepository<T> : IBaseLocalRepository<T> where T : class
  {
        protected readonly BancoLocalDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public LocalRepository(BancoLocalDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T newEntity)
        {
            await _dbSet.AddAsync(newEntity);
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
  }
}