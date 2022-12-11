using Application.Features.SubCategory.Commands.CreateSubCategory;
using Application.Features.SubCategory.Commands.UpdateSubCategory;
using Application.Features.SubCategory.Dtos;
using Application.Features.SubCategory.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.SubCategory.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.SubCategory, CreateSubCategoryCommand>().ReverseMap();
            CreateMap<Domain.Entities.SubCategory, CreatedSubCategoryDto>()
                .ForMember(p => p.SubCategoryId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<Domain.Entities.SubCategory, UpdateSubCategoryCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Domain.Entities.SubCategory, UpdatedSubCategoryDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.SubCategoryId, opt => opt.MapFrom(c => c.Id)).ReverseMap();

            CreateMap<Domain.Entities.SubCategory, SubCategoryListDto>()
                .ForMember(p => p.UserName, opt => opt.MapFrom(c => c.User.FirstName+" "+c.User.LastName))
                .ForMember(p => p.EmendatorAdminName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.SubCategoryId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(c => c.Categories.CategoryName)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.SubCategory>, SubCategoryListModel>().ReverseMap();
            
        }
    }
}
