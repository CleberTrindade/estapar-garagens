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
        public async Task<IActionResult> ListarCarrosPorPeriodo(string dataInicio, string dataFim)
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

            var retorno = await _listagemCarrosService.ObterCarrosPorPeriodo(dtInicio, dtFim);

            return CustomResponse(retorno);
        }

        [HttpGet("ListarCarrosEmGaragem")]
        public async Task<IActionResult> ListarCarrosEmGaragem()
        {
            var retorno = await _listagemCarrosService.ObterCarrosEmGaragem();

            return CustomResponse(retorno);
        }

        [HttpGet("ObterHistoricoEstadia")]
        public async Task<IActionResult> ObterHistoricoEstadia()
        {
            var retorno = await _listagemCarrosService.ObterHistoricoEstadia();

            return CustomResponse(retorno);
        }
    }
}