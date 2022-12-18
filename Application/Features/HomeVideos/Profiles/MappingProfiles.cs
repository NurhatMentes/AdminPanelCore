using Application.Features.HomeVideo.Models;
using Application.Features.HomeVideos.Commands.CreateHomeVideo;
using Application.Features.HomeVideos.Commands.UpdateHomeVideo;
using Application.Features.HomeVideos.Dtos;
using Application.Features.SubCategories.Commands.CreateSubCategory;
using Application.Features.SubCategories.Commands.UpdateSubCategory;
using Application.Features.SubCategories.Dtos;
using Application.Features.SubCategories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HomeVideos.Profiles
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.HomeVideo, CreateHomeVideoCommand>().ReverseMap();
            CreateMap<Domain.Entities.HomeVideo, CreatedHomeVideoDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<Domain.Entities.HomeVideo, UpdateHomeVideoCommand>()
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Domain.Entities.HomeVideo, UpdatedHomeVideoDto>().ReverseMap();

            CreateMap<Domain.Entities.HomeVideo, HomeVideoListDto>()
                .ForMember(p => p.HomeVideoId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.UserName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.EmendatorAdminName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.HomeVideo>, HomeVideoListModel>().ReverseMap();

        }
    }
}
