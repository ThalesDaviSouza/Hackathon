using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Api.Middlewares;

namespace SimuladorCredito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetriasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var metrics = TelemetryMiddleware.GetMetrics()
                .Select(item => new
                {
                    endpoint = item.Key,
                    qtdRequisicoes = item.Value.TotalRequests,
                    tempoMedio = item.Value.AverageDuration,
                    tempoMinimo = item.Value.MinDuration,
                    tempoMaximo = item.Value.MaxDuration,
                    percentualSucesso = item.Value.SuccessPercentage
                });

            return Ok(metrics);
        }       
    }
}