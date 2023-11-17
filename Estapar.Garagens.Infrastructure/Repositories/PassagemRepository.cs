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
        public async Task<IEnumerable<Passagem>> ObterCarrosEmGaragem(string codigoGaragem)
        {
            return await _context.Passagens.Where(p => p.Garagem == codigoGaragem && p.DataHoraSaida == null).ToListAsync();

        }

        public async Task<IEnumerable<Passagem>> ObterCarrosPorPeriodo(string codigoGaragem, DateTime PeriodoInicio, DateTime PeriodoFinal)
        {
            return await _context.Passagens.Where(p => p.Garagem == codigoGaragem && 
                                                       p.DataHoraEntrada >= PeriodoInicio &&
                                                       p.DataHoraSaida <= PeriodoFinal).ToListAsync();
        }

        public async Task<IEnumerable<Passagem>> ObterCarrosPorPeriodoMensalista(string codigoGaragem, DateTime PeriodoInicio, DateTime PeriodoFinal)
        {
            return await _context.Passagens.Where(p => p.Garagem == codigoGaragem && 
                                                       p.DataHoraEntrada >= PeriodoInicio &&
                                                       p.DataHoraSaida <= PeriodoFinal &&
                                                       p.FormaPagamento == "MEN").ToListAsync();
        }

        public async Task<IEnumerable<Passagem>> ObterCarrosPorPeriodoNaoMensalista(string codigoGaragem, DateTime PeriodoInicio, DateTime PeriodoFinal)
        {
            return await _context.Passagens.Where(p => p.Garagem == codigoGaragem &&
                                                       p.DataHoraEntrada >= PeriodoInicio &&
                                                       p.DataHoraSaida <= PeriodoFinal &&
                                                       p.FormaPagamento != "MEN").ToListAsync();
        }

        public async Task<IEnumerable<(Passagem, Garagem)>> ObterDadosPassagem()
        {
            var resultado = await (from passagem in _context.Passagens
                                   join garagem in _context.Garagens on passagem.Garagem equals garagem.Codigo                                   
                                   select new { Passagem = passagem, Garagem = garagem }
                                  ).ToListAsync();

            return resultado.Select(x => (x.Passagem, x.Garagem));
        }

        public async Task<IEnumerable<Passagem>> ObterHistoricoEstadia(string codigoGaragem)
        {
            return await _context.Passagens.Where(p => p.Garagem == codigoGaragem && p.DataHoraSaida != null).ToListAsync();
        }
    }
}
