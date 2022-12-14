﻿using Application.Features.Sliders.Dtos;
using Application.Features.Sliders.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Sliders.Commands.UpdateSlider
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


                Slider slider = new Slider()
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

                Slider mapped = _mapper.Map<Slider>(slider);
                Slider updated = await _repository.UpdateAsync(mapped);
                UpdatedSliderDto mappedDto = _mapper.Map<UpdatedSliderDto>(updated);

                return mappedDto;
            }
        }
    }
}