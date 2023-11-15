using Microsoft.AspNetCore.Mvc;

namespace Estapar.Garagens.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TempoMedioController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TempoMedioController> _logger;

        public TempoMedioController(ILogger<TempoMedioController> logger)
        {
            _logger = logger;
        }

        //Calcular tempo médio de estadia de mensalistas
        [HttpGet(Name = "CalcularTempoMedioMensalistaAsync")]
        public async Task<string> CalcularTempoMedioMensalistaAsync()
        {
            return "Em contrucao";
        }
    }
}