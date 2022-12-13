using Application.Features.ProductSlider.Dtos;
using Application.Features.ProductSlider.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProductSlider.Commands.UpdateProductSlider
{
    public class UpdateProductSliderCommand:IRequest<UpdatedProductSliderDto>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public IFormFile File { get; set; }
        public bool State { get; set; }

        public class UpdateProductSliderCommandHandler : IRequestHandler<UpdateProductSliderCommand, UpdatedProductSliderDto>
        {
            IProductSliderRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly ProductSliderBusinessRules _businessRules;

            public UpdateProductSliderCommandHandler(IProductSliderRepository repository, IMapper mapper, IFileService imageService, ProductSliderBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<UpdatedProductSliderDto> Handle(UpdateProductSliderCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ProductShouldExistWhenRequested(request.ProductId);
                await _imageService.ImageUpload(request.File, "ProductSliders");

                Domain.Entities.ProductSlider productSlider = new Domain.Entities.ProductSlider()
                {
                    ImgUrl = "wwwroot\\Uploads\\ProductSliders\\" + request.File.FileName.Split(".")[0] + ".webp",
                    ProductId = request.ProductId,
                    State = request.State,
                };

                Domain.Entities.ProductSlider updated = await _repository.UpdateAsync(productSlider);
                UpdatedProductSliderDto updatedDto = _mapper.Map<UpdatedProductSliderDto>(updated);

                return updatedDto;
            }
        }
    }
}
