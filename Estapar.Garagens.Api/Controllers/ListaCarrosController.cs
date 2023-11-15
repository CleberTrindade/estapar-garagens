using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaCarrosController : ControllerBase
    {
        private readonly ILogger<ListaCarrosController> _logger;

        public ListaCarrosController(ILogger<ListaCarrosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "ObterCarrosPorPeriodosAsync")]
        public async Task<string> ObterCarrosPorPeriodosAsync()
        {
            return "Em contrucao";
        }
    }
}