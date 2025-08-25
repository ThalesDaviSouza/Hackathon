namespace SimuladorCredito.Interfaces.ReadModels
{
    public record PagedReturnDto<T> where T : class
    {
        public int page { get; set; }
        public int qtdRegistros { get; set; }
        public int qtdRegistrosPagina { get; set; }
        public IEnumerable<T> registros { get; set; } = new List<T>();
    }
}