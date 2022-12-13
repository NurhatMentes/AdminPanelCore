using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProductSlider.Commands.CreateProductSlider;
using Application.Features.ProductSlider.Commands.UpdateProductSlider;
using Application.Features.ProductSlider.Dtos;
using Application.Features.ProductSlider.Models;
using Application.Features.Slider.Commands.CreateSlider;
using Application.Features.Slider.Commands.UpdateSlider;
using Application.Features.Slider.Dtos;
using Application.Features.Slider.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.ProductSlider.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.ProductSlider, CreateProductSliderCommand>().ReverseMap();
            CreateMap<Domain.Entities.ProductSlider, CreatedProductSliderDto>()
                .ForMember(p => p.ProductId, opt => opt.MapFrom(c => c.Product.Id)).ReverseMap();

            CreateMap<Domain.Entities.ProductSlider, UpdateProductSliderCommand>()
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(c => c.Product.Id)).ReverseMap();
            CreateMap<Domain.Entities.ProductSlider, UpdatedProductSliderDto>()              
                .ForMember(p => p.ImgUrl, opt => opt.MapFrom(c => c.ImgUrl))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(c => c.Product.Id)).ReverseMap();

            CreateMap<Domain.Entities.ProductSlider, ProductSliderListDto>()
                .ForMember(p => p.ProductName, opt => opt.MapFrom(c => c.Product.Title)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.ProductSlider>, ProductSliderListModel>().ReverseMap();
        }
    }
}
