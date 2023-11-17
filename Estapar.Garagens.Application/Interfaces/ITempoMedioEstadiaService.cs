using Estapar.Garagens.Application.DTOs.TempoMedioEstadia;

namespace Estapar.Garagens.Application.Interfaces
{
    public interface ITempoMedioEstadiaService
    {
        Task<TempoMedioDto> ObterTempoMedioEstadiaMensalista(string codigoGaragem, DateTime periodoInicio, DateTime periodoFinal);
        Task<TempoMedioDto> ObterTempoMedioEstadiaNaoMensalista(string codigoGaragem, DateTime periodoInicio, DateTime periodoFinal);
    }
}
