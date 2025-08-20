using System.ComponentModel.DataAnnotations;

namespace SimuladorCredito.Domain.Entities
{
    public class Parcela
    {
        public int CoResultaSimulacao { get; set; }
        public short Numero { get; set; }
        public decimal ValorAmortizacao { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorPrestacao => ValorJuros + ValorAmortizacao;


        public virtual ResultadoSimulacao? ResultadoSimulacao { get; set; }
    }
}