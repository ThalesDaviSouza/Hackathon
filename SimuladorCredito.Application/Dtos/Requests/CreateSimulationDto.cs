namespace SimuladorCredito.Application.Dtos.Requests
{
    public record CreateSimulationDto
    {
        public decimal ValorDesejado { get; set; }
        public short prazo { get; set; }
    }
}