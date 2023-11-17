using Estapar.Garagens.Domain.Entities;

namespace Estapar.Garagens.Domain.Interfaces.Repositories
{
    public interface IPassagemRepository : IRepositoryBase<Passagem>
    {
        Task<IEnumerable<Passagem>> ObterCarrosPorPeriodo(string codigoGaragem, DateTime PeriodoInicio, DateTime PeriodoFinal);        
        Task<IEnumerable<Passagem>> ObterCarrosEmGaragem(string codigoGaragem);
        Task<IEnumerable<Passagem>> ObterHistoricoEstadia(string codigoGaragem);
        Task<IEnumerable<Passagem>> ObterCarrosPorPeriodoMensalista(string codigoGaragem, DateTime PeriodoInicio, DateTime PeriodoFinal);
        Task<IEnumerable<Passagem>> ObterCarrosPorPeriodoNaoMensalista(string codigoGaragem, DateTime PeriodoInicio, DateTime PeriodoFinal);
        Task<IEnumerable<(Passagem, Garagem)>> ObterDadosPassagem();
    }
}
