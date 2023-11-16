using Estapar.Garagens.Application.DTOs;
using Estapar.Garagens.Application.Enums;

namespace Estapar.Garagens.Application.Interfaces
{
    public interface IPassagemService
    {
        Task<IEnumerable<CarroGaragemDto>> ObterCarrosPorPeriodo(DateTime periodoInicio, DateTime periodoFinal);
        Task<IEnumerable<CarroGaragemDto>> ObterCarrosEmGaragem();
        Task<IEnumerable<CarroGaragemDto>> ObterHistoricoEstadia();
        Task<ProcessamentoBaseExterna> ObterDadosServicoExterno();
    }
}
