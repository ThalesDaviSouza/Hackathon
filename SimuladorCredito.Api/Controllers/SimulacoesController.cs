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
        public async Task<IActionResult> Get([FromBody] CreateSimulationDto dto)
        {
            var simulacao = await _simulacaoAppService.Simulate(dto.prazo, dto.ValorDesejado);

            // TODO: Persistir no banco local e salvar no event hub

            return Ok(simulacao);
        }        
    }
}