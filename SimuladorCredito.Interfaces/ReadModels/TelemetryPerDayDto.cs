using System.Text.Json.Serialization;
using SimuladorCredito.Interfaces.ReadModels.Converters;

namespace SimuladorCredito.Interfaces.ReadModels
{
    public record TelemetryPerDayDto
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime dataReferencia { get; set; }
        public IEnumerable<TelemetryPerDayItemDto> listaEndpoints { get; set; } = new List<TelemetryPerDayItemDto>();
    }
}