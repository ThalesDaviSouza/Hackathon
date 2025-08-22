namespace SimuladorCredito.Interfaces.Repositories
{
    public interface IBaseLocalRepository<T> : IBaseRepository<T>
    {
        public Task Create(T newEntity);
    }
}