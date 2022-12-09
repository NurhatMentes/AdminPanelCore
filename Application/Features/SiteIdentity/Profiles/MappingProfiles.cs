using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SiteIdentity.Commands.CreateSiteIdentity;
using Application.Features.SiteIdentity.Commands.UpdateSiteIdentity;
using Application.Features.SiteIdentity.Dtos;
using Application.Features.Slider.Commands.CreateSlider;
using Application.Features.Slider.Commands.UpdateSlider;
using Application.Features.Slider.Dtos;
using AutoMapper;

namespace Application.Features.SiteIdentity.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.SiteIdentity, CreateSiteIdentityCommand>().ReverseMap();
            CreateMap<Domain.Entities.SiteIdentity, CreatedSiteIdentityDto>().ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<Domain.Entities.SiteIdentity, UpdateSiteIdentityCommand>()
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id)).ReverseMap()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.UserId))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.EmendatorAdminId)).ReverseMap();
            CreateMap<Domain.Entities.SiteIdentity, UpdatedSiteIdentityDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.LogoUrl, opt => opt.MapFrom(c => c.LogoUrl))
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id)).ReverseMap();
        }
    }
}
