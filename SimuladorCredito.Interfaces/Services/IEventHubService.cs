namespace SimuladorCredito.Interfaces.Services
{
    public interface IEventHubService
    {
        public Task EnviarAsync<T>(T dto);
    }
}