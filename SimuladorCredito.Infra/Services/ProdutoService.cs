using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Repositories;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Infra.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _produtoRepository.Get();
        }

        public async Task<Produto?> GetProdutoToSimulation(decimal valorDesejado, short prazo)
        {
            return await _produtoRepository.GetToSimulation(valorDesejado, prazo);
        }
    }
}