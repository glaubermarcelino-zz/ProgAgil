using System.Linq;
using AutoMapper;
using ProgAgil.Api.Dtos;
using ProgAgil.Domain.Entities;

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
            });
            CreateMap<EventoDto, Evento>();
            CreateMap<PalestranteDto, Palestrante>();
            CreateMap<Palestrante, PalestranteDto>().ForMember(dest => dest.Eventos, opt =>
            {
                opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
            });
            CreateMap<RedeSocial, RedeSocialDto>();
            CreateMap<RedeSocialDto, RedeSocial>();
            CreateMap<Lote, LoteDto>();
            CreateMap<LoteDto, Lote>();
        }
    }
}