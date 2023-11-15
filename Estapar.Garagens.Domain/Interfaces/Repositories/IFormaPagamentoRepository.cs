using Estapar.Garagens.Domain.Entities;

namespace Estapar.Garagens.Domain.Interfaces.Repositories
{
    public interface IFormaPagamentoRepository : IRepositoryBase<FormaPagamento>
    {
        Task<List<FormaPagamento>> GetDataFile();
    }
}
