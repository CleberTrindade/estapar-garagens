using Estapar.Garagens.Api.Config;
using Estapar.Garagens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TempoMedioController : BaseController
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
            {
                AddError("Por favor, informar um periodo v�lido.");
                return CustomResponse();
            }

            if (dtInicio >= dtFim)
            {
                AddError("A data de in�cio n�o deve ser maior ou igual que a data de fim.");
                return CustomResponse();
            }

            var retorno = mensalista ? await _tempoMedioEstadiaService.ObterTempoMedioEstadiaMensalista(dtInicio, dtFim)
                                     : await _tempoMedioEstadiaService.ObterTempoMedioEstadiaNaoMensalista(dtInicio, dtFim);
            return CustomResponse(retorno);
        }

    }
}