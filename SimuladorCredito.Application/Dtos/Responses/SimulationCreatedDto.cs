namespace SimuladorCredito.Application.Dtos.Responses
{
    public record SimulationCreatedDto
    {
        public int idSimulacao { get; set; }
        public int codigoProduto { get; set; }
        public string descricaoProduto { get; set; } = string.Empty;
        public decimal taxaJuros { get; set; }
        public IEnumerable<SimulationResultDto> resultadosSimulacao { get; set; } = new List<SimulationResultDto>();

    }
}