using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Repositories;

namespace SimuladorCredito.Infra.Repositories
{
    public class MetricsRepository : IMetricsRepository
    {
        private readonly IMongoCollection<EndpointMetrics> _colletion;

        public MetricsRepository(IMongoDatabase database)
        {
            _colletion = database.GetCollection<EndpointMetrics>("metrics");
        }

        public async Task Add(EndpointMetrics metrics)
        {
            await _colletion.InsertOneAsync(metrics);
        }

        public async Task<IEnumerable<EndpointMetrics>> Get()
        {
            return await _colletion.Find(_ => true).ToListAsync();
        }
    }
}