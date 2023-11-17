using AutoMapper;
using Estapar.Garagens.Application.DTOs;
using Estapar.Garagens.Application.Enums;
using Estapar.Garagens.Application.Interfaces;
using Estapar.Garagens.Domain.Entities;
using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.ExternalServices.Interfaces;
using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Application.Services
{
    public class ListagemCarrosService : IListagemCarrosService
    {

        private readonly IPassagemRepository _passagemRepository;
        private readonly IMapper _mapper;
        private readonly IPassagemExternalService _passagemExternalService;


        public ListagemCarrosService(IPassagemRepository passagemRepository, IMapper mapper,
                               IPassagemExternalService passagemExternalService)
        {
            _passagemRepository = passagemRepository;
            _mapper = mapper;
            _passagemExternalService = passagemExternalService;
        }
        public async Task<IEnumerable<CarroGaragemDto>> ObterCarrosEmGaragem(string codigoGaragem)
        {
            var carros = await _passagemRepository.ObterCarrosEmGaragem(codigoGaragem);

            return _mapper.Map<IEnumerable<CarroGaragemDto>>(carros);
        }

        public async Task<IEnumerable<CarroGaragemDto>> ObterCarrosPorPeriodo(string codigoGaragem, DateTime periodoInicio, DateTime periodoFinal)
        {
            var carros = await _passagemRepository.ObterCarrosPorPeriodo(codigoGaragem, periodoInicio, periodoFinal);
            return _mapper.Map<IEnumerable<CarroGaragemDto>>(carros);
        }

        public async Task<IEnumerable<CarroGaragemDto>> ObterHistoricoEstadia(string codigoGaragem)
        {
            var carros = await _passagemRepository.ObterHistoricoEstadia(codigoGaragem);

            return _mapper.Map<IEnumerable<CarroGaragemDto>>(carros);
        }
    }
}
