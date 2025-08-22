using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Repositories;

namespace SimuladorCredito.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBaseLocalRepository<Simulacao> Simulacoes { get; }
        IBaseLocalRepository<ResultadoSimulacao> ResultadosSimulacoes { get; }
        IBaseLocalRepository<Parcela> Parcelas { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}