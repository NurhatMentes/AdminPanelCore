using Application.Features.Slider.Dtos;
using Application.Features.Slider.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Slider.Commands.UpdateSlider
{
    public class UpdateSliderCommand : IRequest<UpdatedSliderDto>
    {
        public int SliderId { get; set; }
        public int UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand, UpdatedSliderDto>
        {
            ISliderRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly SliderBusinessRules _businessRules;

            public UpdateSliderCommandHandler(ISliderRepository repository, IMapper mapper, IFileService imageService, SliderBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<UpdatedSliderDto> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                await _imageService.ImageUpload(request.File, "Sliders");


                Domain.Entities.Slider slider = new Domain.Entities.Slider()
                {
                    Id = request.SliderId,
                    UserId = request.UserId,
                    ImgUrl = "wwwroot\\Uploads\\Sliders\\" + request.File.FileName.Split(".")[0] + ".webp",
                    Description = request.Description,
                    EmendatorAdminId = request.EmendatorAdminId,
                    State = request.State,
                    Title = request.Title,
                };

                //request.ImgUrl = "wwwroot\\Uploads\\Sliders\\" + request.File.FileName.Split(".")[0] + ".webp";

                Domain.Entities.Slider mapped = _mapper.Map<Domain.Entities.Slider>(slider);
                Domain.Entities.Slider updated = await _repository.UpdateAsync(mapped);
                UpdatedSliderDto mappedDto = _mapper.Map<UpdatedSliderDto>(updated);

                return mappedDto;
            }
        }
    }
}
