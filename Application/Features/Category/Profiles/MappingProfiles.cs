using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Dtos;
using Application.Features.Category.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Category.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Domain.Entities.Category, CreatedCategoryDto>().ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<Domain.Entities.Category, UpdateCategoryCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Domain.Entities.Category, UpdatedCategoryDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id)).ReverseMap();

            CreateMap<Domain.Entities.Category, CategoryListDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.UserId)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Category>, CategoryListModel>().ReverseMap();
        }
    }
}
