using System.Text.Json.Serialization;
using SimuladorCredito.Interfaces.ReadModels.Converters;

namespace SimuladorCredito.Application.ReadModels.Responses
{
    public record SimulationsByProductItemDto
    {
        public int codigoProduto { get; set; }
        public string descricaoProduto { get; set; } = string.Empty;

        [JsonConverter(typeof(DecimalConverter))]
        public decimal taxaMediaJuros { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal valorMedioPrestacao { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal valorTotalDesejado { get; set; }
        
        [JsonConverter(typeof(DecimalConverter))]
        public decimal valorTotalCredito { get; set; }
    }
}