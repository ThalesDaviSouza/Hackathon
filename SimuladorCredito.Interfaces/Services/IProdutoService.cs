using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Services
{
    public interface IProdutoService
    {
        public IEnumerable<Produto> GetAll();
    }
}