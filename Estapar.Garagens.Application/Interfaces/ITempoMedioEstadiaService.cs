using Estapar.Garagens.Application.DTOs.TempoMedioEstadia;

namespace Estapar.Garagens.Application.Interfaces
{
    public interface ITempoMedioEstadiaService
    {
        Task<TempoMedioDto> ObterTempoMedioEstadiaMensalista(DateTime periodoInicio, DateTime periodoFinal);
        Task<TempoMedioDto> ObterTempoMedioEstadiaNaoMensalista(DateTime periodoInicio, DateTime periodoFinal);
    }
}
