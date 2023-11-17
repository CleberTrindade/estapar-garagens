using Estapar.Garagens.Api.Config;
using Estapar.Garagens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("api/fechamento")]
    public class FechamentoController : BaseController
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
            {
                AddError("Por favor, informar um periodo válido.");
                return CustomResponse();
            }

            if (dtInicio >= dtFim)
            {
                AddError("A data de início não deve ser maior ou igual que a data de fim.");
                return CustomResponse();
            }

            var retorno = await _fechamentoService.ObterFechamentoPorPeriodo(dtInicio, dtFim);

            return CustomResponse(retorno);
        }
    }
}