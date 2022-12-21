using Application.Features.HomeVideos.Dtos;
using Application.Features.HomeVideos.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.HomeVideos.Commands.CreateHomeVideo
{
    public class CreateHomeVideoCommand : IRequest<CreatedHomeVideoDto>
    {
        public IFormFile File { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class CreateHomeVideoCommandHandler : IRequestHandler<CreateHomeVideoCommand, CreatedHomeVideoDto>
        {
            private readonly IHomeVideoRepository _repository;
            private readonly IMapper _mapper;
            private readonly IFileService _imageService;
            private readonly HomeVideoBusinessRules _businessRules;
            private readonly ITablesLogService _logger;

            public CreateHomeVideoCommandHandler(IHomeVideoRepository repository, IMapper mapper, IFileService imageService, HomeVideoBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<CreatedHomeVideoDto> Handle(CreateHomeVideoCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _imageService.VideoUpload(request.File, "HomeVideos");

                Domain.Entities.HomeVideo homeVideo = new Domain.Entities.HomeVideo()
                {
                    VideoUrl = "wwwroot\\Uploads\\HomeVideos\\" + request.File.FileName.Split(".")[0] + ".mp4",
                    UserId = request.UserId,
                    EmendatorAdminId = null,
                    Title = request.Title,
                    Description = request.Description,
                };

                Domain.Entities.HomeVideo created = await _repository.AddAsync(homeVideo);
                CreatedHomeVideoDto createdDto = _mapper.Map<CreatedHomeVideoDto>(created);
                await _logger.CreateTablesLog(createdDto.UserId, createdDto.Id, "Kategori", createdDto.Title);
                return createdDto;
            }
        }
    }
}
