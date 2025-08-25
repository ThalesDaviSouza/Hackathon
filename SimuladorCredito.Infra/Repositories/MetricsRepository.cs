using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.ReadModels;
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

        public async Task<TelemetryPerDayDto> GetPerDay(DateTime? dataReferencia)
        {
            var dataQuery = dataReferencia.HasValue ? dataReferencia.Value : DateTime.Today;
            var end = dataQuery.AddDays(1);

            var listaEndpoints = await _colletion
                .Aggregate()
                .Match(x => x.DataReferencia >= dataQuery && x.DataReferencia < end)
                .Group(
                    x => new { x.Endpoint, x.Method },
                    g => new TelemetryPerDayItemDto
                    {
                        nomeEndpoint = g.Key.Endpoint,
                        metodoHttp = g.Key.Method,
                        percentualSucesso = (double)g.Count(m => m.StatusResponse >= 200 && m.StatusResponse < 300) / g.Count(),
                        qtdRequisicoes = g.Count(),
                        tempoMedio = g.Average(m => m.Duration),
                        tempoMinimo = g.Min(m => m.Duration),
                        tempoMaximo = g.Max(m => m.Duration)
                    }
                )
                .ToListAsync();


            return new TelemetryPerDayDto
            {
                dataReferencia = dataQuery,
                listaEndpoints = listaEndpoints
            };
        }
    }
}