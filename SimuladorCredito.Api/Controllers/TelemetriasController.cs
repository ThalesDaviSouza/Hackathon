using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Services;

namespace SimuladorCredito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetriasController : ControllerBase
    {
        private readonly TelemetryAppService _telemetryAppService;

        public TelemetriasController(TelemetryAppService telemetryAppService)
        {
            _telemetryAppService = telemetryAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTime? dataReferencia)
        {
            var metrics = await _telemetryAppService.Get(dataReferencia);

            return Ok(metrics);
        }       
    }
}