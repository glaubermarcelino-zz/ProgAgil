using System.Linq;
using AutoMapper;
using ProgAgil.Api.Dtos;
using ProgAgil.Domain.Entities;
using ProgAgil.Domain.Identity;

namespace ProgAgil.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>()
            .ForMember(dest => dest.Palestrantes, opt =>
            {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
            }).ReverseMap();

            CreateMap<Palestrante, PalestranteDto>().ForMember(dest => dest.Eventos, opt =>
            {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
            }).ReverseMap();

            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
        }
    }
}