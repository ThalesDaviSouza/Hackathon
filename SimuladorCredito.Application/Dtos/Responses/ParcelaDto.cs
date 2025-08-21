namespace SimuladorCredito.Application.Dtos.Responses
{
    public record ParcelaDto
    {
        public short numero { get; set; }
        public decimal valorAmortizacao { get; set; }
        public decimal valorJuros { get; set; }
        public decimal valorPrestacao { get; set; }
    }
}