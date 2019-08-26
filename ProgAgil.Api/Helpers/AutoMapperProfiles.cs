namespace ProgAgil.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento,EventoDto>();
            CreateMap<Palestra,PlaestraDto>();
            CreateMap<Redesocial,RedeSocialDto>();
            CreateMap<Lote,LoteDto>();
        }
    }
}