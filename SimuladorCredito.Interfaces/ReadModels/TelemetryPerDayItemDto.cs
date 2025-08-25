namespace SimuladorCredito.Interfaces.ReadModels
{
    public record TelemetryPerDayItemDto
    {
        public string nomeEndpoint { get; set; } = string.Empty;
        public string metodoHttp { get; set; } = string.Empty;
        public long qtdRequisicoes { get; set; }
        public double tempoMedio { get; set; }
        public double tempoMinimo { get; set; }
        public double tempoMaximo { get; set; }
        public double percentualSucesso { get; set; }
    }
}