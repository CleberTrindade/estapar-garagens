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
            var carros = await _passagemRepository.ObterCarrosPorPeriodoMensalista(periodoInicio, periodoFinal);

            if (carros.Count() > 0)
            {
                var dados = carros.Select(p => ((TimeSpan)(p.DataHoraSaida - p.DataHoraEntrada)).TotalHours).Sum();

                return new TempoMedioDto() { TempoMedio = (dados / carros.ToList().Count), Mensalista = true };
            }

            return new TempoMedioDto() { };
        }

        public async Task<TempoMedioDto> ObterTempoMedioEstadiaNaoMensalista(DateTime periodoInicio, DateTime periodoFinal)
        {
            var carros = await _passagemRepository.ObterCarrosPorPeriodoNaoMensalista(periodoInicio, periodoFinal);

            if (carros.Count() > 0)
            {
                var dados = carros.Select(p => ((TimeSpan)(p.DataHoraSaida - p.DataHoraEntrada)).TotalHours).Sum();

                return new TempoMedioDto() { TempoMedio = (dados / carros.ToList().Count), Mensalista = false };
            }

            return new TempoMedioDto() { };
        }
    }
}
