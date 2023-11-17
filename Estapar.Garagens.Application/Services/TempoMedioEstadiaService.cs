using Estapar.Garagens.Application.DTOs.TempoMedioEstadia;
using Estapar.Garagens.Application.Interfaces;
using Estapar.Garagens.Domain.Interfaces.Repositories;
using System.Text.Json;

namespace Estapar.Garagens.Application.Services
{
    public class TempoMedioEstadiaService : ITempoMedioEstadiaService
    {
        private readonly IPassagemRepository _passagemRepository;

        public TempoMedioEstadiaService(IPassagemRepository passagemRepository)
        {
            _passagemRepository = passagemRepository;
        }

        public async Task<TempoMedioDto> ObterTempoMedioEstadiaMensalista(DateTime periodoInicio, DateTime periodoFinal)
        {
            var fechamento = await _passagemRepository.ObterCarrosPorPeriodoMensalista(periodoInicio, periodoFinal);

            var dados = fechamento.Select(p => ((TimeSpan)(p.DataHoraSaida - p.DataHoraEntrada)).TotalHours).Sum();

            return new TempoMedioDto() { TempoMedio = (dados / fechamento.ToList().Count), Mensalista = true };
        }

        public async Task<TempoMedioDto> ObterTempoMedioEstadiaNaoMensalista(DateTime periodoInicio, DateTime periodoFinal)
        {
            var carros = await _passagemRepository.ObterCarrosPorPeriodoNaoMensalista(periodoInicio, periodoFinal);

            if (carros.Count() > 0)
            {
                var dados = carros.Select(p => ((TimeSpan)(p.DataHoraSaida - p.DataHoraEntrada)).TotalHours).Sum();

                var md = (dados / carros.ToList().Count);

                var tt = new TempoMedioDto() { TempoMedio = (dados / carros.ToList().Count), Mensalista = true };

                return new TempoMedioDto() { TempoMedio = (dados / carros.ToList().Count), Mensalista = true };
            }

            return new TempoMedioDto(){ };
        }
    }
}
