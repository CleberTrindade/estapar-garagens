using Estapar.Garagens.Application.Enums;
using Estapar.Garagens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("api/GerarBase")]
    public class GerarBaseController : ControllerBase
    {
        private readonly ITratamentoBaseExterna _tratamentoBaseExterna;

        public GerarBaseController(ITratamentoBaseExterna tratamentoBaseExterna)
        {
            _tratamentoBaseExterna = tratamentoBaseExterna;
        }

        [HttpGet("ObterDadosServicoExterno")]
        public async Task<IActionResult> ObterDadosServicoExterno()
        {
            var retorno = await _tratamentoBaseExterna.ProcessarDadosServicoExterno();

            return Ok(retorno);

        }
    }
}
