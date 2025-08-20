
using SimuladorCredito.Domain.Entities;
using SimuladorCredito.Interfaces.Services;

namespace SimuladorCredito.Infra.Services.ResultadoSimulacaoCalculators
{
    public class PRICECalculator : IResultadoSimulacaoCalculator
    {
        public ResultadoSimulacao Simulate(short prazo, decimal valorDesejado, decimal taxaJuros)
        {
            ResultadoSimulacao resultado = new ResultadoSimulacao("PRICE");

            double juros = (double)(valorDesejado * taxaJuros);
            decimal valorParcela = (decimal)(juros / (1 - Math.Pow((double)(1 + taxaJuros), prazo * (-1))));

            decimal saldoDevedor = valorDesejado;

            for (short i = 1; i <= prazo; i++)
            {
                decimal valorJuros = saldoDevedor * taxaJuros;
                decimal valorAmortizacao = valorParcela - valorJuros;

                Parcela parcela = new Parcela();
                parcela.Numero = i;
                parcela.ValorAmortizacao = valorAmortizacao;
                parcela.ValorJuros = valorJuros;

                resultado.Parcelas.Add(parcela);

                saldoDevedor -= valorAmortizacao;
            }

            return resultado;
        }
    
    }
}