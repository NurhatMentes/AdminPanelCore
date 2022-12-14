using Application.Auth.Dtos;
using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Core.Security.JWT;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Security.Entities.User, RegisterCommand>().ReverseMap();
            CreateMap<AccessToken, RefreshedTokenDto>().ReverseMap();
        }
    }
}