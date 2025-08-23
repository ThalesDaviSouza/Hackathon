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
        private readonly GetSimulacaoAppService _getSimulacaoAppService;

        public SimulacoesController(SimulacaoAppService simulacaoAppService, GetSimulacaoAppService getSimulacaoAppService)
        {
            _simulacaoAppService = simulacaoAppService;
            _getSimulacaoAppService = getSimulacaoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSimulationDto dto)
        {
            var simulacao = await _simulacaoAppService.Simulate(dto.prazo, dto.ValorDesejado);

            return CreatedAtAction(
                nameof(Get),
                simulacao
            );
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var simulacao = await _getSimulacaoAppService.GetAll();

            return Ok(simulacao);
        }        
    }
}