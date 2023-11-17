using Estapar.Garagens.Application.DTOs;
using Estapar.Garagens.Application.Enums;

namespace Estapar.Garagens.Application.Interfaces
{
    public interface IListagemCarrosService
    {
        Task<IEnumerable<CarroGaragemDto>> ObterCarrosPorPeriodo(DateTime periodoInicio, DateTime periodoFinal);
        Task<IEnumerable<CarroGaragemDto>> ObterCarrosEmGaragem();
        Task<IEnumerable<CarroGaragemDto>> ObterHistoricoEstadia();
        Task<ProcessamentoBaseExternaEnum> ObterDadosServicoExterno();
    }
}
