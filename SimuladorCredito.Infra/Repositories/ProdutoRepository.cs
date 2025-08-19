using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Repositories;

namespace SimuladorCredito.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository<Produto>
    {
        public IEnumerable<Produto> Get()
        {
            //TODO: conectar com o banco
            return new List<Produto>
            {
                new Produto { CoProduto = 1, NoProduto = "Produto 1"},
                new Produto { CoProduto = 2, NoProduto = "Produto 2"},
                new Produto { CoProduto = 3, NoProduto = "Produto 3"},
                new Produto { CoProduto = 4, NoProduto = "Produto 4"},
            };
        }
    }
}