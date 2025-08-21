using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Services
{
    public interface IProdutoService
    {
        public Task<IEnumerable<Produto>> GetAll();
    }
}