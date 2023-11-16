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
        private readonly IPassagemService _passagemService;
        public FechamentoController(IPassagemService passagemService)
        {
            _passagemService = passagemService;
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

            var retorno = await _passagemService.ObterCarrosPorPeriodo(dtInicio, dtFim);

            var dados = _mapper

            var t = retorno
            .Where(p => p.DataHoraEntrada >= dtInicio && p.DataHoraSaida <= dtFim)
            .GroupBy(p => p)
            .Select(g => new
            {
                FormaPagamento = g.Key,
                Quantidade = g.Count(),
                ValorTotal = g.Sum(p => p.PrecoTotal)
            })
            .ToList();


            return Ok(retorno);
        }
    }
}