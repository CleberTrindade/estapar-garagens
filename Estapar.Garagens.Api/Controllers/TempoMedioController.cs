using Estapar.Garagens.Application.Interfaces;
using Estapar.Garagens.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TempoMedioController : ControllerBase
    {
        private readonly ITempoMedioEstadiaService _tempoMedioEstadiaService;

        public TempoMedioController(ITempoMedioEstadiaService tempoMedioEstadiaService)
        {
            _tempoMedioEstadiaService = tempoMedioEstadiaService;
        }

        //Calcular tempo m�dio de estadia de mensalistas
        [HttpGet("CalcularTempoMedioEstadias")]
        public async Task<IActionResult> CalcularTempoMedioEstadias(string dataInicio, string dataFim, bool mensalista)
        {
            var dtInicio = DateTime.Parse(dataInicio);
            var dtFim = DateTime.Parse(dataFim);

            if (dtInicio == DateTime.MinValue || dtFim == DateTime.MinValue)
                return BadRequest("Por favor, informar um periodo v�lido.");


            if (dtInicio >= dtFim)
                return BadRequest("A data de in�cio n�o deve ser maior ou igual que a data de fim.");

            var retorno = mensalista ? await _tempoMedioEstadiaService.ObterTempoMedioEstadiaMensalista(dtInicio, dtFim)
                                     : await _tempoMedioEstadiaService.ObterTempoMedioEstadiaNaoMensalista(dtInicio, dtFim);

            if (retorno.TempoMedio == 0)
                return NotFound("Dados n�o localizados");

            return Ok(retorno);
        }

    }
}