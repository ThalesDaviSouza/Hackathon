using System.Text.Json.Serialization;
using SimuladorCredito.Interfaces.ReadModels.Converters;

namespace SimuladorCredito.Application.ReadModels.Responses
{
    public record SimulationsByProductDto
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime dataReferencia { get; set; }
        public IEnumerable<SimulationsByProductItemDto> simulacoes { get; set; } = new List<SimulationsByProductItemDto>();
    }
}