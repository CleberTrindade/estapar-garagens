using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Config
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public ICollection<string> Erros = new List<string>();
        protected ActionResult CustomResponse(object result = null)
        {
            if (!Erros.Any())
                return Ok(new CustomResponse(result));

            return BadRequest(new CustomResponse(Erros.ToList(), false));
        }

        protected ActionResult CustomNotFoundResponse(object result = null)
        {
            return NotFound(new CustomResponse(result));
        }

        protected void AddError(string erro)
        {
            Erros.Add(erro);
        }
    }
}