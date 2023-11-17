using Estapar.Garagens.Domain.Entities;

namespace Estapar.Garagens.Domain.Interfaces.Repositories
{
    public interface IPassagemRepository : IRepositoryBase<Passagem>
    {
        Task<IEnumerable<Passagem>> ObterCarrosPorPeriodo(DateTime PeriodoInicio, DateTime PeriodoFinal);        
        Task<IEnumerable<Passagem>> ObterCarrosEmGaragem();
        Task<IEnumerable<Passagem>> ObterHistoricoEstadia();
        Task<IEnumerable<Passagem>> ObterCarrosPorPeriodoMensalista(DateTime PeriodoInicio, DateTime PeriodoFinal);
        Task<IEnumerable<Passagem>> ObterCarrosPorPeriodoNaoMensalista(DateTime PeriodoInicio, DateTime PeriodoFinal);
        Task<IEnumerable<(Passagem, Garagem)>> ObterDadosPassagem();
    }
}
