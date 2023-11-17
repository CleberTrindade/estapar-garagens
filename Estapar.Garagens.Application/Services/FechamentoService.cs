using Estapar.Garagens.Application.DTOs.Fechamento;
using Estapar.Garagens.Application.Interfaces;
using Estapar.Garagens.Domain.Interfaces.Repositories;

namespace Estapar.Garagens.Application.Services
{
    public class FechamentoService : IFechamentoService
    {
        private readonly IPassagemRepository _passagemRepository;

        public FechamentoService(IPassagemRepository passagemRepository)
        {
            _passagemRepository = passagemRepository;
        }

        public async Task<IEnumerable<FechamentoDto>> ObterFechamentoPorPeriodo(string codigoGaragem, DateTime periodoInicio, DateTime periodoFinal)
        {
            var fechamento = await _passagemRepository.ObterCarrosPorPeriodo(codigoGaragem, periodoInicio, periodoFinal);
                        
            var dados = fechamento.GroupBy(p => p.FormaPagamento)
            .Select(g => new FechamentoDto()
            {
                FormaPagamento = g.Key,
                Quantidade = g.Count(),
                ValorTotal = g.Sum(p => p.PrecoTotal)
            });

            return dados;
        }
    }
}
