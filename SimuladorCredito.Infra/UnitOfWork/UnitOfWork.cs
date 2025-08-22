using Microsoft.EntityFrameworkCore.Storage;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infra.Persistance;
using SimuladorCredito.Infra.Repositories;
using SimuladorCredito.Interfaces.Repositories;
using SimuladorCredito.Interfaces.UnitOfWork;

namespace SimuladorCredito.Infra.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
        private readonly BancoLocalDbContext _context;
        private IDbContextTransaction? _transaction;

        public IBaseLocalRepository<Simulacao> Simulacoes { get; private set; }
        public IBaseLocalRepository<ResultadoSimulacao> ResultadosSimulacoes { get; private set; }
        public IBaseLocalRepository<Parcela> Parcelas { get; private set; }

        public UnitOfWork(BancoLocalDbContext context)
        {
            _context = context;

            Simulacoes = new LocalRepository<Simulacao>(context);
            ResultadosSimulacoes = new LocalRepository<ResultadoSimulacao>(context);
            Parcelas = new LocalRepository<Parcela>(context);
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

  }
}