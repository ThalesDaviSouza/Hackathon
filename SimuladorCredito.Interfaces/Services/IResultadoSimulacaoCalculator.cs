using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Interfaces.Services
{
    public interface IResultadoSimulacaoCalculator
    {
        public ResultadoSimulacao Simulate(short prazo, decimal valorDesejado, decimal taxaJuros);
    }
}