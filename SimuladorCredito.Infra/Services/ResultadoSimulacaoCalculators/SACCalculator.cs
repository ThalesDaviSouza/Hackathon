
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Infra.Services.ResultadoSimulacaoCalculators
{
    public class SACCalculator : IResultadoSimulacaoCalculator
    {
        public ResultadoSimulacao Simulate(short prazo, decimal valorDesejado, decimal taxaJuros)
        {
            ResultadoSimulacao resultado = new ResultadoSimulacao("SAC");

            decimal valorAmortizacao = valorDesejado / prazo;
            decimal valorRestante = valorDesejado;

            for (short i = 1; i <= prazo; i++)
            {
                decimal valorJuros = valorRestante * taxaJuros;
                Parcela parcela = new Parcela();
                parcela.Numero = i;
                parcela.ValorAmortizacao = valorAmortizacao;
                parcela.ValorJuros = valorJuros;

                valorRestante -= valorAmortizacao;

                resultado.Parcelas.Add(parcela);
            }

            return resultado;
        }
    
    }
}