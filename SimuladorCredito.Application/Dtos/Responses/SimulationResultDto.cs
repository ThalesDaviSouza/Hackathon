namespace SimuladorCredito.Application.Dtos.Responses
{
    public record SimulationResultDto
    {
        public string tipo { get; set; } = string.Empty;
        public IEnumerable<ParcelaDto> parcelas { get; set; } = new List<ParcelaDto>();
    }
}