using AutoMapper;
using Estapar.Garagens.Application.DTOs;
using Estapar.Garagens.Domain.Entities;
using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Application.Mappings
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile() {

            /*
            CreateMap<FormaPagamento, FormaPagamentoDto>()
            .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao)).ReverseMap();

            CreateMap<FormaPagamento, FormaPagamentoFileDto>()
            .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao)).ReverseMap();

            CreateMap<Garagem, GaragemDto>()
            .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Preco_1aHora, opt => opt.MapFrom(src => src.Preco_1aHora))
            .ForMember(dest => dest.Preco_HorasExtra, opt => opt.MapFrom(src => src.Preco_HorasExtra))
            .ForMember(dest => dest.Preco_Mensalista, opt => opt.MapFrom(src => src.Preco_Mensalista))
            .ReverseMap();

            CreateMap<Garagem, GaragemFileDto>()
            .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Preco_1aHora, opt => opt.MapFrom(src => src.Preco_1aHora))
            .ForMember(dest => dest.Preco_HorasExtra, opt => opt.MapFrom(src => src.Preco_HorasExtra))
            .ForMember(dest => dest.Preco_Mensalista, opt => opt.MapFrom(src => src.Preco_Mensalista))
            .ReverseMap();

            CreateMap<Passagem, PassagemDto>()
            .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
            .ForMember(dest => dest.Garagem, opt => opt.MapFrom(src => src.Garagem))
            .ForMember(dest => dest.CarroPlaca, opt => opt.MapFrom(src => src.CarroPlaca))
            .ForMember(dest => dest.CarroMarca, opt => opt.MapFrom(src => src.CarroMarca))
            .ForMember(dest => dest.CarroModelo, opt => opt.MapFrom(src => src.CarroModelo))
            .ForMember(dest => dest.DataHoraEntrada, opt => opt.MapFrom(src => src.DataHoraEntrada))
            .ForMember(dest => dest.DataHoraSaida, opt => opt.MapFrom(src => src.DataHoraSaida))
            .ForMember(dest => dest.FormaPagamento, opt => opt.MapFrom(src => src.FormaPagamento))
            .ForMember(dest => dest.PrecoTotal, opt => opt.MapFrom(src => src.PrecoTotal))
            .ReverseMap();

            
            */

            CreateMap<Passagem, CarroGaragemDto>().ReverseMap();            

            CreateMap<PassagemFileDto, Passagem>()
            .ForMember(dest => dest.Garagem, opt => opt.MapFrom(src => src.Garagem))
            .ForMember(dest => dest.CarroPlaca, opt => opt.MapFrom(src => src.CarroPlaca))
            .ForMember(dest => dest.CarroMarca, opt => opt.MapFrom(src => src.CarroMarca))
            .ForMember(dest => dest.CarroModelo, opt => opt.MapFrom(src => src.CarroModelo))
            .ForMember(dest => dest.DataHoraEntrada, opt => opt.MapFrom(src => DateTime.Parse(src.DataHoraEntrada)))
            .ForMember(dest => dest.DataHoraSaida, opt => opt.MapFrom(src => src.ValidarDataHoraSaida()))
            .ForMember(dest => dest.FormaPagamento, opt => opt.MapFrom(src => src.FormaPagamento))
            .ForMember(dest => dest.PrecoTotal, opt => opt.MapFrom(src => src.ValidarPrecoTotal()))
            ;
        }
    }
}
