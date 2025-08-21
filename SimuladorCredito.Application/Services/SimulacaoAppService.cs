using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Domain.Exceptions.HttpExceptions;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Application.Services
{
    public class SimulacaoAppService
    {
        private readonly IEnumerable<IResultadoSimulacaoCalculator> _calculators;
        private readonly ProdutoAppService _produtoAppService;

        public SimulacaoAppService(IEnumerable<IResultadoSimulacaoCalculator> calculators, ProdutoAppService produtoAppService)
        {
            _calculators = calculators;
            _produtoAppService = produtoAppService;
        }

        public async Task<Simulacao> Simulate(short prazo, decimal valorDesejado)
        {
            var produto = await _produtoAppService.GetProdutoToSimulation(valorDesejado);

            if (produto == null)
                throw new BadRequestException("Produto correspondente não encontrado");

            decimal taxaJuros = produto.PcTaxaJuros;

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