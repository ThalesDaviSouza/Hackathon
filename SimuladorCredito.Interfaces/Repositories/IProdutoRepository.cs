namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IProdutoRepository<T> : IBaseRepository<T>
    {
        public Task<T?> GetToSimulation(decimal valorDesejado);
    }
}