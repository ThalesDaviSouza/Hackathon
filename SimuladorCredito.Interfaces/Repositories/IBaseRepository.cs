namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        public IEnumerable<T> Get();
    }
}