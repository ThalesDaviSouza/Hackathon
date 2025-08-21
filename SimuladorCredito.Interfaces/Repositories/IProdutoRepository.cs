namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IProdutoRepository<T> : IBaseRepository<T>
    {
        public Task<T> GetToSimulate(decimal valorDesejado);
    }
}