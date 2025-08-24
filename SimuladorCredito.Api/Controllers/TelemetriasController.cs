using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Services;
using SimuladorCredito.Domain.Entities;

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
        public async Task<IActionResult> Get()
        {
            var metrics = await _telemetryAppService.Get();
            return Ok(metrics);
        }       
    }
}