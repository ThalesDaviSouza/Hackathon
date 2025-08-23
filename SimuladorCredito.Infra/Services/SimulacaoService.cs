using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Repositories;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Infra.Services
{
    public class SimulacaoService : ISimulacaoService
    {
        private readonly IBaseLocalRepository<Simulacao> _simulacaoRepository;

        public SimulacaoService(IBaseLocalRepository<Simulacao> simulacaoRepository)
        {
            _simulacaoRepository = simulacaoRepository;
        }

        public Simulacao CreateSimulation(
            IEnumerable<IResultadoSimulacaoCalculator> calculators,
            int coProduto,
            decimal taxaJuros,
            short prazo,
            decimal valorDesejado
        )
        {
            Simulacao simulacao = new Simulacao();
            simulacao.CoProduto = coProduto;
            simulacao.PcTaxaJuros = taxaJuros;
            simulacao.Prazo = prazo;
            simulacao.ValorDesajado = valorDesejado;

            foreach (var calculator in calculators)
            {
                var resultadoSimulacao = calculator.Simulate(prazo, valorDesejado, taxaJuros);
                resultadoSimulacao.CoResultaSimulacao = simulacao.ResultadosSimulacao.Count;
                simulacao.ResultadosSimulacao.Add(resultadoSimulacao);
            }

            return simulacao;
        }

        public async Task SaveSimulation(Simulacao simulacao)
        {
            await _simulacaoRepository.Create(simulacao);
        }
    }
}