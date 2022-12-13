using Application.Features.ProductSlider.Dtos;
using Application.Features.ProductSlider.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProductSlider.Commands.CreateProductSlider
{
    public class CreateProductSliderCommand:IRequest<CreatedProductSliderDto>
    {
        public int ProductId { get; set; }
        public IFormFile File { get; set; }

        public class CreateProductSliderCommandHandler : IRequestHandler<CreateProductSliderCommand, CreatedProductSliderDto>
        {
            IProductSliderRepository _repository;
            IMapper _mapper;
            IFileService _imageService; 
            ProductSliderBusinessRules _businessRules;

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

                Domain.Entities.ProductSlider productSlider = new Domain.Entities.ProductSlider()
                {
                    ImgUrl = "wwwroot\\Uploads\\ProductSliders\\" + request.File.FileName.Split(".")[0] + ".webp",
                    ProductId = request.ProductId,
                    State = true
                };

                Domain.Entities.ProductSlider created = await _repository.AddAsync(productSlider);
                CreatedProductSliderDto createdDto = _mapper.Map<CreatedProductSliderDto>(created);

                return createdDto;
            }
        }
    }
}
