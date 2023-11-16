using Estapar.Garagens.Application.Enums;
using Estapar.Garagens.Application.Extensions;
using Estapar.Garagens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("api/listagem-carros")]
    public class ListaCarrosController : ControllerBase
    {
        private readonly IPassagemService _passagemService;

        public ListaCarrosController(IPassagemService passagemService)
        {
            _passagemService = passagemService;
        }

        

        [HttpGet("ObterFechamentoPorPeriodo")]
        public async Task<IActionResult> ObterFechamentoPorPeriodo(string dataInicio, string dataFim)
        {
            var dtInicio = DateTime.Parse(dataInicio);
            var dtFim = DateTime.Parse(dataFim);

            if (dtInicio == DateTime.MinValue || dtFim == DateTime.MinValue)
                return BadRequest("Por favor, informar um periodo válido.");


            if (dtInicio >= dtFim)
                return BadRequest("A data de início não deve ser maior ou igual que a data de fim.");

            var retorno = await _passagemService.ObterCarrosPorPeriodo(dtInicio, dtFim);

            return Ok(retorno);
        }

        [HttpGet("ObterCarrosEmGaragem")]
        public async Task<IActionResult> ObterCarrosEmGaragem()
        {
            var retorno = await _passagemService.ObterCarrosEmGaragem();

            return Ok(retorno);
        }

        [HttpGet("ObterHistoricoEstadia")]
        public async Task<IActionResult> ObterHistoricoEstadia()
        {
            var retorno = await _passagemService.ObterHistoricoEstadia();

            return Ok(retorno);
        }

        [HttpGet("ObterDadosServicoExterno")]
        public async Task<IActionResult> ObterDadosServicoExterno()
        {
            var retorno = await _passagemService.ObterDadosServicoExterno();

            if (retorno == ProcessamentoBaseExterna.ErroAoProcessar)
                return BadRequest(retorno.GetDescription());

            return Ok(retorno.GetDescription());
        }
    }
}