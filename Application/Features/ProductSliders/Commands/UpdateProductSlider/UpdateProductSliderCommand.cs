using Application.Features.ProductSliders.Dtos;
using Application.Features.ProductSliders.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProductSliders.Commands.UpdateProductSlider
{
    public class UpdateProductSliderCommand : IRequest<UpdatedProductSliderDto>
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
            private readonly ITablesLogService _logger;


            public UpdateProductSliderCommandHandler(IProductSliderRepository repository, IMapper mapper, IFileService imageService, ProductSliderBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<UpdatedProductSliderDto> Handle(UpdateProductSliderCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ProductShouldExistWhenRequested(request.ProductId);
                await _imageService.ImageUpload(request.File, "ProductSliders");


                var entity = await _repository.GetAsync(p => p.Id == request.Id);

                entity.ImgUrl = "wwwroot\\Uploads\\ProductSliders\\" + request.File.FileName.Split(".")[0] + ".webp";
                entity.ProductId = request.ProductId;
                entity.State = request.State;

                ProductSlider updated = await _repository.UpdateAsync(entity);
                UpdatedProductSliderDto updatedDto = _mapper.Map<UpdatedProductSliderDto>(updated);
                await _logger.UpdateTablesLog(0, updatedDto.Id, "Ürün Slider", updatedDto.ImgUrl);


                return updatedDto;
            }
        }
    }
}
