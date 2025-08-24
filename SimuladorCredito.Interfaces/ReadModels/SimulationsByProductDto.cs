namespace SimuladorCredito.Application.ReadModels.Responses
{
    public record SimulationsByProductDto
    {
        public DateTime dataReferencia { get; set; }
        public IEnumerable<SimulationsByProductItemDto> simulacoes { get; set; } = new List<SimulationsByProductItemDto>();
    }
}