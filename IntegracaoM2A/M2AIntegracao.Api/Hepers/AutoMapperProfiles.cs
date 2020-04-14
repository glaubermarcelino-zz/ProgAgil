using System.Linq;
using AutoMapper;
using M2AIntegracao.Api.Dtos;
using M2AIntegracao.Domain.Entities;
using M2AIntegracao.Domain.Identity;

namespace M2AIntegracao.Api.Helpers
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