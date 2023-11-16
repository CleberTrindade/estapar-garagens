using Estapar.Garagens.Domain.Entities;
using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.Context;

namespace Estapar.Garagens.Infrastructure.Repositories
{
    public class GaragemRepository : RepositoryBase<Garagem>, IGaragemRepository
    {
        private readonly ApplicationDbContext _context;
        public GaragemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
