namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<IEnumerable<T>> Get();
    }
}