using Application.Features.AboutUs.Commands.CreateAboutUs;
using Application.Features.AboutUs.Commands.UpdateAboutUs;
using Application.Features.AboutUs.Dtos;
using AutoMapper;

namespace Application.Features.AboutUs.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.AboutUs, CreateAboutUsCommand>().ReverseMap();
            CreateMap<Domain.Entities.AboutUs, CreatedAboutUsDto>()
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(p => p.User.Id))
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id)).ReverseMap();

            CreateMap<Domain.Entities.AboutUs, UpdateAboutUsCommand>().ReverseMap();
            CreateMap<Domain.Entities.AboutUs, UpdatedAboutUsDto>()
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(p => p.User.Id))
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id)).ReverseMap();
        }
    }
}
