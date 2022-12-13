using Application.Features.SubCategories.Commands.CreateSubCategory;
using Application.Features.SubCategories.Commands.UpdateSubCategory;
using Application.Features.SubCategories.Dtos;
using Application.Features.SubCategories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.SubCategories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SubCategory, CreateSubCategoryCommand>().ReverseMap();
            CreateMap<SubCategory, CreatedSubCategoryDto>()
                .ForMember(p => p.SubCategoryId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<SubCategory, UpdateSubCategoryCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<SubCategory, UpdatedSubCategoryDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.SubCategoryId, opt => opt.MapFrom(c => c.Id)).ReverseMap();

            CreateMap<SubCategory, SubCategoryListDto>()
                .ForMember(p => p.UserName, opt => opt.MapFrom(c => c.User.FirstName+" "+c.User.LastName))
                .ForMember(p => p.EmendatorAdminName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.SubCategoryId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(c => c.Categories.CategoryName)).ReverseMap();
            CreateMap<IPaginate<SubCategory>, SubCategoryListModel>().ReverseMap();
            
        }
    }
}
