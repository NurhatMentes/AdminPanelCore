using Application.Features.Service.Commands.CreateService;
using Application.Features.Service.Commands.UpdateService;
using Application.Features.Service.Dtos;
using Application.Features.Service.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Service.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Service, CreateServiceCommand>().ReverseMap();
            CreateMap<Domain.Entities.Service, CreatedServiceDto>().ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<Domain.Entities.Service, UpdateServiceCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Domain.Entities.Service, UpdatedServiceDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id)).ReverseMap();

            CreateMap<Domain.Entities.Service, ServiceListDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.UserId)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Service>, ServiceListModel>().ReverseMap();
        }
    }
}
