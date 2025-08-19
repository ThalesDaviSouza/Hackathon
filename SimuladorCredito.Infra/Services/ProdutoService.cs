using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Repositories;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Infra.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository<Produto> _produtoRepository;

        public ProdutoService(IProdutoRepository<Produto> produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepository.Get();
        }
    }
}