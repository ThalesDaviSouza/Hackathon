using MongoDB.Driver;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Repositories;

namespace SimuladorCredito.Infra.Repositories
{
    public class MetricsRepository : IMetricsRepository
    {
        private readonly IMongoCollection<EndpointMetric> _colletion;

        public MetricsRepository(IMongoDatabase database)
        {
            _colletion = database.GetCollection<EndpointMetric>("metrics");
        }

        public async Task Add(EndpointMetric metrics)
        {
            await _colletion.InsertOneAsync(metrics);
        }

        public async Task AddMany(IEnumerable<EndpointMetric> metrics)
        {
            await _colletion.InsertManyAsync(metrics);
        }

        public async Task<IEnumerable<EndpointMetric>> Get()
        {
            return await _colletion.Find(_ => true).ToListAsync();
        }
    }
}