using Application.Features.SiteIdentity.Dtos;
using Application.Features.Slider.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.SiteIdentity.Commands.UpdateSiteIdentity
{
    public class UpdateSiteIdentityCommand : IRequest<UpdatedSiteIdentityDto>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public bool? State { get; set; }
        public class UpdateSiteIdentityCommandHandler : IRequestHandler<UpdateSiteIdentityCommand, UpdatedSiteIdentityDto>
        {
            ISiteIdentityRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly SliderBusinessRules _businessRules;

            public UpdateSiteIdentityCommandHandler(ISiteIdentityRepository repository, IMapper mapper, IFileService imageService, SliderBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<UpdatedSiteIdentityDto> Handle(UpdateSiteIdentityCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                await _imageService.LogoImageUpload(request.File, "SiteIdentity");

                Domain.Entities.SiteIdentity siteIdentity = new Domain.Entities.SiteIdentity()
                {
                    Id = request.Id,
                    LogoUrl = "wwwroot\\Uploads\\SiteIdentity\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    Keywords = request.Keywords,
                    Description = request.Description,
                    EmendatorAdminId = request.EmendatorAdminId,
                    State = request.State,
                    Title = request.Title,
                };


                Domain.Entities.SiteIdentity mapped = _mapper.Map<Domain.Entities.SiteIdentity>(siteIdentity);
                Domain.Entities.SiteIdentity updated = await _repository.UpdateAsync(mapped);
                UpdatedSiteIdentityDto mappedDto = _mapper.Map<UpdatedSiteIdentityDto>(updated);

                return mappedDto;
            }
        }
    }
}
