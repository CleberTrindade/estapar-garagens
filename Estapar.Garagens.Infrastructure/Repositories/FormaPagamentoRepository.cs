using Estapar.Garagens.Domain.Entities;
using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.Context;

namespace Estapar.Garagens.Infrastructure.Repositories
{
    public class FormaPagamentoRepository : RepositoryBase<FormaPagamento>, IFormaPagamentoRepository
    {
        private readonly ApplicationDbContext _context;
        public FormaPagamentoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
