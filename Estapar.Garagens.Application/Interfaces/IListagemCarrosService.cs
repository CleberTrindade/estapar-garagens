using Estapar.Garagens.Application.DTOs;
using Estapar.Garagens.Application.Enums;

namespace Estapar.Garagens.Application.Interfaces
{
    public interface IListagemCarrosService
    {
        Task<IEnumerable<CarroGaragemDto>> ObterCarrosPorPeriodo(string codigoGaragem, DateTime periodoInicio, DateTime periodoFinal);
        Task<IEnumerable<CarroGaragemDto>> ObterCarrosEmGaragem(string codigoGaragem);
        Task<IEnumerable<CarroGaragemDto>> ObterHistoricoEstadia(string codigoGaragem);
    }
}
