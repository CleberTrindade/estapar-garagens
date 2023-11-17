using Estapar.Garagens.Domain.Entities;
using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Estapar.Garagens.Infrastructure.Repositories
{
    public class PassagemRepository : RepositoryBase<Passagem>, IPassagemRepository
    {

        private readonly ApplicationDbContext _context;
        public PassagemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Passagem>> ObterCarrosEmGaragem()
        {
            return await _context.Passagens.Where(p => p.DataHoraSaida == null).ToListAsync();

        }

        public async Task<IEnumerable<Passagem>> ObterCarrosPorPeriodo(DateTime PeriodoInicio, DateTime PeriodoFinal)
        {
            return await _context.Passagens.Where(p => p.DataHoraEntrada >= PeriodoInicio &&
                                                   p.DataHoraSaida <= PeriodoFinal).ToListAsync();
        }

        public async Task<IEnumerable<Passagem>> ObterCarrosPorPeriodoMensalista(DateTime PeriodoInicio, DateTime PeriodoFinal)
        {
            return await _context.Passagens.Where(p => p.DataHoraEntrada >= PeriodoInicio &&
                                                       p.DataHoraSaida <= PeriodoFinal &&
                                                       p.FormaPagamento == "MEN").ToListAsync();
        }

        public async Task<IEnumerable<Passagem>> ObterCarrosPorPeriodoNaoMensalista(DateTime PeriodoInicio, DateTime PeriodoFinal)
        {
            return await _context.Passagens.Where(p => p.DataHoraEntrada >= PeriodoInicio &&
                                                       p.DataHoraSaida <= PeriodoFinal &&
                                                       p.FormaPagamento != "MEN").ToListAsync();
        }

        
        public async Task<IEnumerable<Passagem>> ObterHistoricoEstadia()
        {
            return await _context.Passagens.Where(p => p.DataHoraSaida != null).ToListAsync();
        }
    }
}
