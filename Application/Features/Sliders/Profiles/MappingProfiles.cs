using Application.Features.Sliders.Commands.CreateSlider;
using Application.Features.Sliders.Commands.UpdateSlider;
using Application.Features.Sliders.Dtos;
using Application.Features.Sliders.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Sliders.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Slider, CreateSliderCommand>().ReverseMap();
            CreateMap<Slider, CreatedSliderDto>().ForMember(p=>p.UserId,opt=>opt.MapFrom(c=>c.User.Id)).ReverseMap();

            CreateMap<Slider, UpdateSliderCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Slider, UpdatedSliderDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.SliderId, opt => opt.MapFrom(c => c.Id)).ReverseMap();

            CreateMap<Slider, SliderListDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.UserId)).ReverseMap();
            CreateMap<IPaginate<Slider>, SliderListModel>().ReverseMap();
        }
    }
}
