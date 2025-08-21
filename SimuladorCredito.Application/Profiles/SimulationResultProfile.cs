using AutoMapper;
using SimuladorCredito.Application.Dtos.Responses;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Application.Profiles
{
    public class SimulationResultProfile : Profile
    {
        public SimulationResultProfile()
        {
            CreateMap<ResultadoSimulacao, SimulationResultDto>()
                .ForMember(dest => dest.tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.parcelas, opt => opt.MapFrom(src => src.Parcelas));
                
        }
    }
}