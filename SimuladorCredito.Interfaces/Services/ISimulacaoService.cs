using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Services
{
    public interface ISimulacaoService
    {
        public Simulacao CreateSimulation(
            IEnumerable<IResultadoSimulacaoCalculator> calculators,
            int coProduto,
            decimal taxaJuros,
            short prazo,
            decimal valorDesejado
        );

        public Task SaveSimulation(Simulacao simulacao);
        
    }
}