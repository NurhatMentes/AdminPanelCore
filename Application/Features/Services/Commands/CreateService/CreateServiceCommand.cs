using Application.Features.Services.Dtos;
using Application.Features.Services.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Services.Commands.CreateService
{
    public class CreateServiceCommand:IRequest<CreatedServiceDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0","1" };
        public int UserId { get; set; }
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public bool State { get; set; }
        public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, CreatedServiceDto>
        {
            IServiceRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly ServiceBusinessRules _businessRules;
            private readonly ITablesLogService _logger;


            public CreateServiceCommandHandler(IServiceRepository repository, IMapper mapper, IFileService imageService, ServiceBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<CreatedServiceDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _imageService.ImageUpload(request.File, "Services");

                Service service = new Service()
                {
                    ImgUrl = "wwwroot\\Uploads\\Services\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    Description = request.Description,
                    EmendatorAdminId = null,
                    State = true,
                    Title = request.Title,
                    Keywords = request.Keywords
                };

                Service created = await _repository.AddAsync(service);
                CreatedServiceDto createdDto = _mapper.Map<CreatedServiceDto>(created);
                await _logger.CreateTablesLog(createdDto.UserId, createdDto.Id, "Hizmet", createdDto.Title);


                return createdDto;
            }
        }
    }
}
