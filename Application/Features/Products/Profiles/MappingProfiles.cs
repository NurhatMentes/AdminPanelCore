using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, CreatedProductDto>().ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<Product, UpdateProductCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Product, UpdatedProductDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id)).ReverseMap();

            CreateMap<Product, ProductListDto>()
                .ForMember(p => p.UserName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.EmendatorAdminName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.SubCategoryName, opt => opt.MapFrom(c => c.SubCategories.SubCategoryName))
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(c => c.Categories.CategoryName)).ReverseMap();

            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();

        }
    }
}
