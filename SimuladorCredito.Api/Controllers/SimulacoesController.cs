using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Dtos.Requests;
using SimuladorCredito.Application.Services;

namespace SimuladorCredito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimulacoesController : ControllerBase
    {
        private readonly SimulacaoAppService _simulacaoAppService;

        public SimulacoesController(SimulacaoAppService simulacaoAppService)
        {
            _simulacaoAppService = simulacaoAppService;
        }

        [HttpPost]
        public IActionResult Get([FromBody] CreateSimulationDto dto)
        {
            var simulacao = _simulacaoAppService.Simulate(dto.prazo, dto.ValorDesejado);
            return Ok(simulacao);
        }        
    }
}