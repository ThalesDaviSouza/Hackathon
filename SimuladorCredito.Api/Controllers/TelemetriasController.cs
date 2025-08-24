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
            await _telemetryAppService.Add(new EndpointMetrics
            {
                Endpoint = "teste",
                DataReferencia = DateTime.Now,
                DurationMs = 1234
            });

            var metrics = await _telemetryAppService.Get();

            // var metrics = TelemetryMiddleware.GetMetrics()
            //     .Select(item => new
            //     {
            //         endpoint = item.Key,
            //         qtdRequisicoes = item.Value.TotalRequests,
            //         tempoMedio = item.Value.AverageDuration,
            //         tempoMinimo = item.Value.MinDuration,
            //         tempoMaximo = item.Value.MaxDuration,
            //         percentualSucesso = item.Value.SuccessPercentage
            //     });

            return Ok(metrics);
        }       
    }
}