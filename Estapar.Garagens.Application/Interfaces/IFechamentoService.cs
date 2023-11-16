using Estapar.Garagens.Application.DTOs.Fechamento;

namespace Estapar.Garagens.Application.Interfaces
{
    public interface IFechamentoService
    {
        Task<IEnumerable<FechamentoDto>> ObterFechamentoPorPeriodo(DateTime periodoInicio, DateTime periodoFinal);
    }
}
