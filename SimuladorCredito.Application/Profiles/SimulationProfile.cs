using AutoMapper;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Application.Profiles
{
    public class SimulationProfile : Profile
    {
        public SimulationProfile()
        {
            CreateMap<Simulacao, SimulationCreatedDto>()
                .ForMember(dest => dest.idSimulacao, opt => opt.MapFrom(src => src.CoSimulacao))
                .ForMember(dest => dest.codigoProduto, opt => opt.MapFrom(src => src.CoProduto))
                .ForMember(dest => dest.resultadosSimulacao, opt => opt.MapFrom(src => src.ResultadosSimulacao));
        }
    }
}