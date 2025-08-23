namespace SimuladorCredito.Application.ReadModels.Responses
{
    public record SimulationResumeDto
    {
        public int idSimulacao { get; set; }
        public decimal valorDesejado { get; set; }
        public short prazo { get; set; }
        public decimal valorTotalParcelas { get; set; }
    }
}