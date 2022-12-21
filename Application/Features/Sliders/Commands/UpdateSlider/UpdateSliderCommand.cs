using Application.Features.Sliders.Dtos;
using Application.Features.Sliders.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Sliders.Commands.UpdateSlider
{
    public class UpdateSliderCommand : IRequest<UpdatedSliderDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
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
            private readonly ITablesLogService _logger;


            public UpdateSliderCommandHandler(ISliderRepository repository, IMapper mapper, IFileService imageService, SliderBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<UpdatedSliderDto> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                await _imageService.ImageUpload(request.File, "Sliders");

                var entity = await _repository.GetAsync(p => p.Id == request.SliderId);

                entity.Id = request.SliderId;
                entity.UserId = request.UserId;
                entity.ImgUrl = "wwwroot\\Uploads\\Sliders\\" + request.File.FileName.Split(".")[0] + ".webp";
                entity.Description = request.Description;
                entity.EmendatorAdminId = request.EmendatorAdminId;
                entity.State = request.State;
                entity.Title = request.Title;

                Slider mapped = _mapper.Map<Slider>(entity);
                Slider updated = await _repository.UpdateAsync(mapped);
                UpdatedSliderDto mappedDto = _mapper.Map<UpdatedSliderDto>(updated);
                await _logger.UpdateTablesLog(mappedDto.EmendatorAdminId, mappedDto.SliderId, "Alt Kategori", mappedDto.Title);

                return mappedDto;
            }
        }
    }
}
