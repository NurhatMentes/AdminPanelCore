using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Slider.Commands.CreateSlider;
using Application.Features.Slider.Dtos;
using Application.Features.Slider.Models;
using Application.Features.User.Commands.UpdateUser;
using Application.Features.User.Dtos;
using Application.Features.User.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Slider.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Slider, CreateSliderCommand>().ReverseMap();
            CreateMap<Domain.Entities.Slider, CreatedSliderDto>().ForMember(p=>p.UserId,opt=>opt.MapFrom(c=>c.User.Id)).ReverseMap();

            CreateMap<Domain.Entities.Slider, SliderListDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Slider>, SliderListModel>().ReverseMap();
        }
    }
}
