using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimuladorCredito.Domain.Entities
{
    public class EndpointMetrics
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        
        public string Endpoint { get; set; } = string.Empty;
        public long DurationMs { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}