﻿using Estapar.Garagens.Application.DTOs.TempoMedioEstadia;
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

        public async Task<TempoMedioDto> ObterTempoMedioEstadiaMensalista(string codigoGaragem, DateTime periodoInicio, DateTime periodoFinal)
        {
            var carros = await _passagemRepository.ObterCarrosPorPeriodoMensalista(codigoGaragem, periodoInicio, periodoFinal);

            if (carros.Count() > 0)
            {
                TimeSpan somaTotalHoras = TimeSpan.FromTicks(carros.Sum(item => item.ObterTotalHoras().Ticks));

                return new TempoMedioDto() { CodigoGaragem = codigoGaragem, TempoMedio = (somaTotalHoras / carros.ToList().Count), Mensalista = true };
            }
            return new TempoMedioDto() { };
        }

        public async Task<TempoMedioDto> ObterTempoMedioEstadiaNaoMensalista(string codigoGaragem, DateTime periodoInicio, DateTime periodoFinal)
        {
            var carros = await _passagemRepository.ObterCarrosPorPeriodoNaoMensalista(codigoGaragem, periodoInicio, periodoFinal);

            if (carros.Count() > 0)
            {
                TimeSpan somaTotalHoras = TimeSpan.FromTicks(carros.Sum(item => item.ObterTotalHoras().Ticks));

                return new TempoMedioDto() { CodigoGaragem = codigoGaragem, TempoMedio = (somaTotalHoras / carros.ToList().Count), Mensalista = false };
            }
            return new TempoMedioDto() { };
        }
    }
}
