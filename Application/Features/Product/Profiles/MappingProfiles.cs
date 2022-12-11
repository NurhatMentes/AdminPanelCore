using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Dtos;
using Application.Features.Product.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Product.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();
            CreateMap<Domain.Entities.Product, CreatedProductDto>().ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();

            CreateMap<Domain.Entities.Product, UpdateProductCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Domain.Entities.Product, UpdatedProductDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id)).ReverseMap();

            CreateMap<Domain.Entities.Product, ProductListDto>()
                .ForMember(p => p.UserName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.EmendatorAdminName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.SubCategoryName, opt => opt.MapFrom(c => c.SubCategories.SubCategoryName))
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(c => c.Categories.CategoryName)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Product>, ProductListModel>().ReverseMap();
        }
    }
}
