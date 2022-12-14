using Application.Features.Blogs.Commands.CreateBlog;
using Application.Features.Blogs.Commands.UpdateBlog;
using Application.Features.Blogs.Dtos;
using Application.Features.Blogs.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Blogs.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, CreatedBlogDto>().ReverseMap();

            CreateMap<Blog, UpdateBlogCommand>()
                .ForMember(p => p.BlogId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.CategoryId, opt => opt.MapFrom(c => c.Categories.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Blog, UpdatedBlogDto>()
                .ForMember(p => p.BlogId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.CategoryId, opt => opt.MapFrom(c => c.Categories.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<Blog, BlogListDto>()
                .ForMember(p => p.UserName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.EmendatorAdminName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.SubCategoryName, opt => opt.MapFrom(c => c.SubCategories.SubCategoryName))
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(c => c.Categories.CategoryName)).ReverseMap();

            CreateMap<IPaginate<Blog>, BlogListModel>().ReverseMap();
        }
    }
}
