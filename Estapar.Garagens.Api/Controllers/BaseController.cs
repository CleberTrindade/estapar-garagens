using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public ICollection<string> Erros = new List<string>();
        protected ActionResult CustomResponse(object result = null)
        {
            if (Isvalid())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Erros.ToArray()}
            }));
        }

        protected bool Isvalid()
        {
            return !Erros.Any();
        }

        protected void AddError(string erro)
        {
            Erros.Add(erro);
        }
    }
}