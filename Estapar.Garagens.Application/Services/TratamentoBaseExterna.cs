using AutoMapper;
using Estapar.Garagens.Application.Enums;
using Estapar.Garagens.Application.Extensions;
using Estapar.Garagens.Application.Interfaces;
using Estapar.Garagens.Domain.Entities;
using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.ExternalServices.Interfaces;
using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Application.Services
{
    public class TratamentoBaseExterna : ITratamentoBaseExterna
    {
        private readonly IMapper _mapper;
        private readonly IPassagemRepository _passagemRepository;
        private readonly IGaragemRepository _garagemRepository;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        private readonly IPassagemExternalService _passagemExternalService;
        private readonly IGaragemExternalService _garagemExternalService;
        private readonly IFormaPagamentoExternalService _formaPagamentoExternalService;

        public TratamentoBaseExterna(IMapper mapper,
                                     IPassagemRepository passagemRepository,
                                     IGaragemRepository garagemRepository,
                                     IFormaPagamentoRepository formaPagamentoRepository,
                                     IPassagemExternalService passagemExternalService,
                                     IGaragemExternalService garagemExternalService,
                                     IFormaPagamentoExternalService formaPagamentoExternalService)
        {
            _mapper = mapper;
            _passagemRepository = passagemRepository;
            _garagemRepository = garagemRepository;
            _formaPagamentoRepository = formaPagamentoRepository;
            _passagemExternalService = passagemExternalService;
            _garagemExternalService = garagemExternalService;
            _formaPagamentoExternalService = formaPagamentoExternalService;
        }

        public async Task<List<string>> ProcessarDadosServicoExterno()
        {
            List<string> processamento = new List<string>();

            //var pgto = await ObterDadosFormaPagamentoServicoExterno();
            //var grg = await ObterDadosGaragemServicoExterno();
            var psg = await ObterDadosPassagemServicoExterno();

            //processamento.Add($"Dados Pagamento Servico Externo: {pgto.GetDescription()}");
            //processamento.Add($"Dados Garagem Servico Externo: {grg.GetDescription()}");
            processamento.Add($"Dados Passagem Servico Externo: {psg.GetDescription()}");

            return processamento;
        }

        private async Task<ProcessamentoBaseExternaEnum> ObterDadosFormaPagamentoServicoExterno()
        {
            var result = await _formaPagamentoExternalService.GetData();

            var dados = _mapper.Map<List<FormaPagamentoFileDto>, List<FormaPagamento>>(result);

            var reg = await _formaPagamentoRepository.GetAll();

            if (reg.Count() == 0 || reg.Count() < dados.Count())
            {
                await _formaPagamentoRepository.AddRange(dados);
                return ProcessamentoBaseExternaEnum.ProcessadaComSucesso;
            }
            else
                return reg.Count() == 0 ? ProcessamentoBaseExternaEnum.NaoLocalizada : ProcessamentoBaseExternaEnum.JaProcessada;
        }
        private async Task<ProcessamentoBaseExternaEnum> ObterDadosGaragemServicoExterno()
        {
            var result = await _garagemExternalService.GetData();

            var dados = _mapper.Map<List<GaragemFileDto>, List<Garagem>>(result);

            var reg = await _garagemRepository.GetAll();

            if (reg.Count() == 0 || reg.Count() < dados.Count())
            {
                await _garagemRepository.AddRange(dados);
                return ProcessamentoBaseExternaEnum.ProcessadaComSucesso;
            }
            else
                return reg.Count() == 0 ? ProcessamentoBaseExternaEnum.NaoLocalizada : ProcessamentoBaseExternaEnum.JaProcessada;
        }
        private async Task<ProcessamentoBaseExternaEnum> ObterDadosPassagemServicoExterno()
        {
            var resultPassagem = await _passagemExternalService.GetData();

            var dadosPassagem = _mapper.Map<List<PassagemFileDto>, List<Passagem>>(resultPassagem);

            var resultGaragem = await _garagemExternalService.GetData();

            var dadosGaragem = _mapper.Map<List<GaragemFileDto>, List<Garagem>>(resultGaragem);


            var dados = ObterJuncaoDados(dadosPassagem, dadosGaragem).ToList();

            var reg = await _passagemRepository.ObterHistoricoEstadia();

            if (reg.Count() == 0 || reg.Count() < dados.Count())
            {
                await _passagemRepository.AddRange(dados);
                return ProcessamentoBaseExternaEnum.ProcessadaComSucesso;
            }
            else
                return reg.Count() == 0 ? ProcessamentoBaseExternaEnum.NaoLocalizada : ProcessamentoBaseExternaEnum.JaProcessada;
        }

        private IEnumerable<Passagem> ObterJuncaoDados(List<Passagem> passagens, List<Garagem> garagens)
        {
            var resultado = from passagem in passagens
                            join garagem in garagens on passagem.Garagem equals garagem.Codigo
                            select new { Passagem = passagem, Garagem = garagem };

            foreach (var item in resultado)
            {
                if (!item.Passagem.FormaPagamento.Equals("MEN"))
                    item.Passagem.AtualizarPrecoTotal(item.Garagem);
                else
                    item.Passagem.PrecoTotal = 0;
            }

            return passagens;
        }
    }
}
