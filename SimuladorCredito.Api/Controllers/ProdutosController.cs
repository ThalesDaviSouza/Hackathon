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
            var produtos = await _produtoAppService.GetAll();

            return Ok(produtos);
        }
    }
}