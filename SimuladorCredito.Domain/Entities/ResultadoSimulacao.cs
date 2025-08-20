namespace SimuladorCredito.Domain.Entities
{
    public class ResultadoSimulacao
    {
        public int CoSimulacao { get; set; }
        public int CoResultaSimulacao { get; set; }
        public string Tipo { get; set; }

        public virtual Simulacao? Simulacao { get; set; }
        public virtual ICollection<Parcela> Parcelas { get; set; } = new List<Parcela>();

        public ResultadoSimulacao(string Tipo)
        {
            this.Tipo = Tipo;
        }
    }
}