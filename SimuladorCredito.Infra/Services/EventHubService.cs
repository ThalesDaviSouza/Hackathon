using System.Text;
using System.Text.Json;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Extensions.Configuration;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Infra.Services
{
    public class EventHubService : IEventHubService
    {
        private readonly string _connectionString;
        private readonly string _eventHubName;

        public EventHubService(IConfiguration configuration)
        {
            _connectionString = configuration["EVENTHUB_CONNECTION_STRING"]!;
            _eventHubName = configuration["EVENTHUB_NAME"]!;
        }

        public async Task EnviarAsync<T>(T dto)
        {
            // Se falhar adicionar o nome também
            await using var producerClient = new EventHubProducerClient(_connectionString);

            string json = JsonSerializer.Serialize(dto);
            using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

            if (!eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(json))))
                throw new Exception("Evento muito grande para o batch");

            await producerClient.SendAsync(eventBatch);
        }
  }
}