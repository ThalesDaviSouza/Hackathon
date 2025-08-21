namespace SimuladorCredito.Interfaces.Services
{
    public interface IEventHubService
    {
        public Task SendAsync<T>(T dto);
    }
}