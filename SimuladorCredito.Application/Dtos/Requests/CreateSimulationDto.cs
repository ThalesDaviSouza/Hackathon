using System.ComponentModel.DataAnnotations;

namespace SimuladorCredito.Application.Dtos.Requests
{
    public record CreateSimulationDto
    {
        [Required]
        public decimal ValorDesejado { get; set; }
        [Required]
        public short prazo { get; set; }
    }
}