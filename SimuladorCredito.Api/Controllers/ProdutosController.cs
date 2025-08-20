using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Services;

namespace SimuladorCredito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoAppService _produtoAppService;

        public ProdutosController(ProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> Get()
        {
            var produtos = _produtoAppService.GetAll();
            await Task.Delay(5000);

            return Ok(produtos);
        }
    }
}