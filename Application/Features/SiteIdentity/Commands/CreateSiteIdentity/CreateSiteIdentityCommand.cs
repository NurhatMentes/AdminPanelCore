using Application.Features.SiteIdentity.Dtos;
using Application.Features.SiteIdentity.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.SiteIdentity.Commands.CreateSiteIdentity
{
    public class CreateSiteIdentityCommand:IRequest<CreatedSiteIdentityDto>
    {
        public int UserId { get; set; }
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public class CreateSiteIdentityCommandHandler : IRequestHandler<CreateSiteIdentityCommand, CreatedSiteIdentityDto>
        {
            ISiteIdentityRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly SiteIdentityBusinessRules _businessRules;
            private readonly ITablesLogService _logger;


            public CreateSiteIdentityCommandHandler(ISiteIdentityRepository repository, IMapper mapper, IFileService imageService, SiteIdentityBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<CreatedSiteIdentityDto> Handle(CreateSiteIdentityCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _imageService.LogoImageUpload(request.File, "SiteIdentity");

                Domain.Entities.SiteIdentity siteIdentity = new Domain.Entities.SiteIdentity()
                {
                    LogoUrl = "wwwroot\\Uploads\\SiteIdentity\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    Keywords = request.Keywords,
                    Description = request.Description,
                    EmendatorAdminId = null,
                    State = true,
                    Title = request.Title,
                };

                Domain.Entities.SiteIdentity created = await _repository.AddAsync(siteIdentity);
                CreatedSiteIdentityDto createdDto = _mapper.Map<CreatedSiteIdentityDto>(created);
                await _logger.CreateTablesLog(createdDto.UserId, createdDto.Id, "Site Kimliği", createdDto.Title);


                return createdDto;
            }
        }
    }
}
