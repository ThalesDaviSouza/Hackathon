using AutoMapper;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Application.Profiles
{
    public class ParcelasProfile : Profile
    {
        public ParcelasProfile()
        {
            CreateMap<Parcela, ParcelaDto>()
                .ForMember(dest => dest.numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.valorAmortizacao, opt => opt.MapFrom(src => Math.Round(src.ValorAmortizacao, 2)))
                .ForMember(dest => dest.valorJuros, opt => opt.MapFrom(src => Math.Round(src.ValorJuros, 2)))
                .ForMember(dest => dest.valorPrestacao, opt => opt.MapFrom(src => Math.Round(src.ValorPrestacao, 2)));
                
        }
    }
}