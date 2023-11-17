using Estapar.Garagens.Application.Interfaces;
using Estapar.Garagens.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("api/fechamento")]
    public class FechamentoController : ControllerBase
    {
        private readonly IFechamentoService _fechamentoService;

        public FechamentoController(IFechamentoService fechamentoService)
        {
            _fechamentoService = fechamentoService;
        }

        [HttpGet("ObterDadosPagamento")]
        public async Task<IActionResult> ObterDadosPagamento(string dataInicio, string dataFim)
        {
            var dtInicio = DateTime.Parse(dataInicio);
            var dtFim = DateTime.Parse(dataFim);

            if (dtInicio == DateTime.MinValue || dtFim == DateTime.MinValue)
                return BadRequest("Por favor, informar um periodo válido.");


            if (dtInicio >= dtFim)
                return BadRequest("A data de início não deve ser maior ou igual que a data de fim.");

            

            var retorno = await _fechamentoService.ObterFechamentoPorPeriodo(dtInicio, dtFim);

            return Ok(retorno);
        }
    }
}