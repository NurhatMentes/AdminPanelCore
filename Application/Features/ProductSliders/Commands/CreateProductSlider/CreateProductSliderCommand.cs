using Application.Features.ProductSliders.Dtos;
using Application.Features.ProductSliders.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProductSliders.Commands.CreateProductSlider
{
    public class CreateProductSliderCommand:IRequest<CreatedProductSliderDto>
    {
        public int ProductId { get; set; }
        public IFormFile File { get; set; }

        public class CreateProductSliderCommandHandler : IRequestHandler<CreateProductSliderCommand, CreatedProductSliderDto>
        {
            private readonly IProductSliderRepository _repository;
            private readonly IMapper _mapper;
            private readonly IFileService _imageService; 
            private readonly ProductSliderBusinessRules _businessRules;

            public CreateProductSliderCommandHandler(IProductSliderRepository repository, IMapper mapper, IFileService imageService, ProductSliderBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<CreatedProductSliderDto> Handle(CreateProductSliderCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ProductShouldExistWhenRequested(request.ProductId);
                await _imageService.ImageUpload(request.File, "ProductSliders");

                ProductSlider productSlider = new ProductSlider()
                {
                    ImgUrl = "wwwroot\\Uploads\\ProductSliders\\" + request.File.FileName.Split(".")[0] + ".webp",
                    ProductId = request.ProductId,
                    State = true
                };

                ProductSlider created = await _repository.AddAsync(productSlider);
                CreatedProductSliderDto createdDto = _mapper.Map<CreatedProductSliderDto>(created);

                return createdDto;
            }
        }
    }
}
