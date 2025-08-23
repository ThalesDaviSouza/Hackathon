using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        public Task<Produto?> GetToSimulation(decimal valorDesejado, short prazo);
    }
}