using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Application.ReadModels.Responses;
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

        Task<PagedReturnDto<SimulationResumeDto>> GetPaged(int page, int pageSize);

        public Task SaveSimulation(Simulacao simulacao);
        
    }
}