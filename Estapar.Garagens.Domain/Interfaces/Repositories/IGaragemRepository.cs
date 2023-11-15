using Estapar.Garagens.Domain.Entities;

namespace Estapar.Garagens.Domain.Interfaces.Repositories
{
    public interface IGaragemRepository : IRepositoryBase<Garagem>
    {
        Task<List<Garagem>> GetDataFile();
    }
}
