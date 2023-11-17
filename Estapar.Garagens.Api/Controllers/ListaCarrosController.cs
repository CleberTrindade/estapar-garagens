using Estapar.Garagens.Api.Config;
using Estapar.Garagens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("api/listagem-carros")]
    public class ListaCarrosController : BaseController
    {
        private readonly IListagemCarrosService _listagemCarrosService;

        public ListaCarrosController(IListagemCarrosService listagemCarrosService)
        {
            _listagemCarrosService = listagemCarrosService;
        }



        [HttpGet("ListarCarrosPorPeriodo")]
        public async Task<IActionResult> ListarCarrosPorPeriodo(string codigoGaragem, string dataInicio, string dataFim)
        {
            DateTime dtInicioOut;
            DateTime dtFimOut;

            if (!DateTime.TryParse(dataInicio, out dtInicioOut) || !DateTime.TryParse(dataFim, out dtFimOut))
            {
                AddError("Por favor, informar datas válidas.");
                return CustomResponse();
            }

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

            var retorno = await _listagemCarrosService.ObterCarrosPorPeriodo(codigoGaragem, dtInicio, dtFim);

            return CustomResponse(retorno);
        }

        [HttpGet("ListarCarrosEmGaragem")]
        public async Task<IActionResult> ListarCarrosEmGaragem(string codigoGaragem)
        {
            var retorno = await _listagemCarrosService.ObterCarrosEmGaragem(codigoGaragem);

            return CustomResponse(retorno);
        }

        [HttpGet("ObterHistoricoEstadia")]
        public async Task<IActionResult> ObterHistoricoEstadia(string codigoGaragem)
        {
            var retorno = await _listagemCarrosService.ObterHistoricoEstadia(codigoGaragem);

            return CustomResponse(retorno);
        }
    }
}