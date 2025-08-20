using System.ComponentModel.DataAnnotations;

namespace SimuladorCredito.Domain.Entities
{
    public class Simulacao
    {
        public int CoSimulacao { get; set; }
        public int CoProduto { get; set; }

        public virtual Produto? Produto { get; set; }
        public virtual ICollection<ResultadoSimulacao> ResultadosSimulacao { get; set; } = new List<ResultadoSimulacao>();

    }
}