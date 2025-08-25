using System.Text.Json.Serialization;
using SimuladorCredito.Interfaces.ReadModels.Converters;

namespace SimuladorCredito.Interfaces.ReadModels
{
    public record SimulationResumeDto
    {
        public int idSimulacao { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal valorDesejado { get; set; }
        
        public short prazo { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal valorTotalParcelas { get; set; }
    }
}