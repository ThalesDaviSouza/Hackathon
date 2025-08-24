namespace SimuladorCredito.Application.ReadModels.Responses
{
    public record SimulationsByProductItemDto
    {
        public int codigoProduto { get; set; }
        public string descricaoProduto { get; set; } = string.Empty;
        public decimal taxaMediaJuros { get; set; }
        public decimal valorMedioPrestacao { get; set; }
        public decimal valorTotalDesejado { get; set; }
        public decimal valorTotalCredito { get; set; }
    }
}