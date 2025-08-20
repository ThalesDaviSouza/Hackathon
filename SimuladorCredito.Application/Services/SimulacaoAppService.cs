using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Application.Services
{
    public class SimulacaoAppService
    {
        private readonly IEnumerable<IResultadoSimulacaoCalculator> _calculators;

        public SimulacaoAppService(IEnumerable<IResultadoSimulacaoCalculator> calculators)
        {
            _calculators = calculators;
        }

        public Simulacao Simulate(short prazo, decimal valorDesejado)
        {
            // TODO: buscar o produto correto no banco
            decimal taxaJuros = 0.0179m;

            Simulacao simulacao = new Simulacao();

            foreach (var calculator in _calculators)
            {
                var resultadoSimulacao = calculator.Simulate(prazo, valorDesejado, taxaJuros);
                simulacao.ResultadosSimulacao.Add(resultadoSimulacao);
            }

            return simulacao;
        }
    }
}