using Estapar.Garagens.Infrastructure.ExternalServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FechamentoController : ControllerBase
    {

        private readonly ILogger<FechamentoController> _logger;
        private readonly IFormaPagamentoService _formaPagamentoService;

        public FechamentoController(ILogger<FechamentoController> logger, IFormaPagamentoService formaPagamentoService)
        {
            _logger = logger;
            _formaPagamentoService = formaPagamentoService;
        }

        [HttpGet(Name = "ObterFechamentoPorPeriodo")]
        public async Task<IActionResult> ObterFechamentoPorPeriodo()
        {
            var formasPagamento = await _formaPagamentoService.GetData();

            if (formasPagamento == null)
                return BadRequest();

            return Ok(formasPagamento);
        }
    }
}