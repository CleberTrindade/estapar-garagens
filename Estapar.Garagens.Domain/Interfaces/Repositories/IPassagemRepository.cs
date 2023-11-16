using Estapar.Garagens.Domain.Entities;

namespace Estapar.Garagens.Domain.Interfaces.Repositories
{
    public interface IPassagemRepository : IRepositoryBase<Passagem>
    {
        Task<IEnumerable<Passagem>> ObterCarrosPorPeriodo(DateTime PeriodoInicio, DateTime PeriodoFinal);
        Task<IEnumerable<Passagem>> ObterCarrosEmGaragem();
        Task<IEnumerable<Passagem>> ObterHistoricoEstadia();
    }
}
