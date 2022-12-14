using Application.Features.ProductSliders.Commands.CreateProductSlider;
using Application.Features.ProductSliders.Commands.UpdateProductSlider;
using Application.Features.ProductSliders.Dtos;
using Application.Features.ProductSliders.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProductSliders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductSlider, CreateProductSliderCommand>().ReverseMap();
            CreateMap<ProductSlider, CreatedProductSliderDto>()
                .ForMember(p => p.ProductId, opt => opt.MapFrom(c => c.Product.Id)).ReverseMap();

            CreateMap<ProductSlider, UpdateProductSliderCommand>()
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(c => c.Product.Id)).ReverseMap();
            CreateMap<ProductSlider, UpdatedProductSliderDto>()              
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(c => c.Product.Id)).ReverseMap();

            CreateMap<ProductSlider, ProductSliderListDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id)).ReverseMap();
            CreateMap<IPaginate<ProductSlider>, ProductSliderListModel>().ReverseMap();
        }
    }
}
