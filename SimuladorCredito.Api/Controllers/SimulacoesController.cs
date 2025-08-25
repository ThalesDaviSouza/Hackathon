using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Dtos.Requests;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Application.Services;
using SimuladorCredito.Interfaces.ReadModels;

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
        [ProducesResponseType(typeof(SimulationCreatedDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] CreateSimulationDto dto)
        {
            var simulacao = await _simulacaoAppService.Simulate(dto.prazo, dto.ValorDesejado);

            return CreatedAtAction(
                nameof(Get),
                simulacao
            );
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedReturnDto<SimulationResumeDto>), StatusCodes.Status200OK)]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> Get(
            [FromQuery] int? page,
            [FromQuery] int? pageSize
        )
        {
            var pagedResult = await _getSimulacaoAppService.Get(page ?? 1, pageSize ?? 200);

            return Ok(pagedResult);
        }

        [HttpGet("por-produto")]
        [ProducesResponseType(typeof(SimulationsByProductDto), StatusCodes.Status200OK)]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> GetByProducts()
        {
            var simulationsByProduct = await _getSimulacaoAppService.GetByProducts();

            return Ok(simulationsByProduct);
        }

    }
}