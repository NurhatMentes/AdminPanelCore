using MediatR;
using Application.Features.Slider.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Application.Features.Slider.Rules;
using Application.Services.FileService;

namespace Application.Features.Slider.Commands.CreateSlider
{
    public class CreateSliderCommand : IRequest<CreatedSliderDto>
    {
        public IFormFile File { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand, CreatedSliderDto>
        {
            ISliderRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly SliderBusinessRules _businessRules;

            public CreateSliderCommandHandler(ISliderRepository repository, IMapper mapper, IFileService imageService, SliderBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<CreatedSliderDto> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
            { 
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _imageService.ImageUpload(request.File, "Sliders");

                Domain.Entities.Slider slider = new Domain.Entities.Slider()
                {
                    ImgUrl = "wwwroot\\Uploads\\Sliders\\" + request.File.FileName.Split(".")[0]+".webp",
                    UserId = request.UserId,
                    Description = request.Description,
                    EmendatorAdminId = null,
                    State = true,
                    Title = request.Title,
                };

                //Domain.Entities.Slider mapped = _mapper.Map<Domain.Entities.Slider>(request);
                Domain.Entities.Slider created = await _repository.AddAsync(slider);
                CreatedSliderDto createdDto = _mapper.Map<CreatedSliderDto>(created);

                return createdDto;
            }
        }
    }
}
