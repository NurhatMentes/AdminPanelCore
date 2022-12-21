using Application.Features.HomeVideos.Dtos;
using Application.Features.HomeVideos.Rules;
using Application.Features.SubCategories.Commands.UpdateSubCategory;
using Application.Features.SubCategories.Dtos;
using Application.Features.SubCategories.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HomeVideos.Commands.UpdateHomeVideo
{
    public class UpdateHomeVideoCommand : IRequest<UpdatedHomeVideoDto>
    {
        public IFormFile File { get; set; }
        public int HomeVideoId { get; set; }
        public int EmendatorAdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class UpdateHomeVideoCommandHandler : IRequestHandler<UpdateHomeVideoCommand, UpdatedHomeVideoDto>
        {
            IHomeVideoRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly HomeVideoBusinessRules _businessRules;
            private readonly ITablesLogService _logger;

            public UpdateHomeVideoCommandHandler(IHomeVideoRepository repository, IMapper mapper, IFileService imageService, HomeVideoBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<UpdatedHomeVideoDto> Handle(UpdateHomeVideoCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                await _imageService.VideoUpload(request.File, "HomeVideos");

                var entity=await _repository.GetAsync(p=>p.Id==request.HomeVideoId);


                entity.VideoUrl = "wwwroot\\Uploads\\HomeVideos\\" + request.File.FileName.Split(".")[0] + ".mp4";
                entity.EmendatorAdminId = request.EmendatorAdminId;
                entity.Title = request.Title;
                entity.Description = request.Description;
                

                Domain.Entities.HomeVideo mapped = _mapper.Map<Domain.Entities.HomeVideo>(entity);
                Domain.Entities.HomeVideo updated = await _repository.UpdateAsync(mapped);
                UpdatedHomeVideoDto updatedDto = _mapper.Map<UpdatedHomeVideoDto>(updated);
                await _logger.UpdateTablesLog(updatedDto.EmendatorAdminId, updatedDto.HomeVideoId, "Ama Video", updatedDto.Title);
                return updatedDto;
            }
        }
    }
}
