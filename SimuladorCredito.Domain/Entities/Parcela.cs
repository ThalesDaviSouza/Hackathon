namespace SimuladorCredito.Domain.Entities
{
    public class Parcela
    {
        public int CoSimulacao { get; set; }
        public int CoResultaSimulacao { get; set; }
        public short Numero { get; set; }
        public decimal ValorAmortizacao { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorPrestacao => ValorJuros + ValorAmortizacao;


        public virtual ResultadoSimulacao? ResultadoSimulacao { get; set; }
    }
}