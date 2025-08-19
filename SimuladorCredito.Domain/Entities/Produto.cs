namespace SimuladorCredito.Domain.Entities
{
    public class Produto
    {
        public int CoProduto { get; set; }
        public required string NoProduto { get; set; }
        public decimal PcTaxaJuros { get; set; }
        public short NuMinMeses { get; set; }
        public short? NuMaxMeses { get; set; }
        public decimal VrMinimo { get; set; }
        public decimal? VrMaximo { get; set; }

    }
}