namespace SimuladorCredito.Domain.Entities
{
    public class Simulacao
    {
        public int CoSimulacao { get; set; }
        public int CoProduto { get; set; }
        public decimal PcTaxaJuros { get; set; }
        public decimal ValorDesajado { get; set; }
        public short Prazo { get; set; }

        public virtual ICollection<ResultadoSimulacao> ResultadosSimulacao { get; set; } = new List<ResultadoSimulacao>();

    }
}