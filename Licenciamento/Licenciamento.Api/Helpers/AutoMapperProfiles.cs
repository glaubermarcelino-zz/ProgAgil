using AutoMapper;
using Licenciamento.Api.Dtos;
using Licenciamento.domain.Identity;

namespace Licenciamento.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}