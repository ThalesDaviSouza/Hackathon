using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Infra.Persistance;
using SimuladorCredito.Interfaces.UnitOfWork;

namespace SimuladorCredito.Infra.Repositories
{
    public class SimulacaoRepository : LocalRepository<Simulacao>
    {
        private readonly IUnitOfWork _uow;

        public SimulacaoRepository(BancoLocalDbContext context, IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public override async Task Create(Simulacao simulacao)
        {
            await _uow.BeginTransactionAsync();
            await _uow.Simulacoes.Create(simulacao);
            await _uow.CommitAsync();
        }
    }
}