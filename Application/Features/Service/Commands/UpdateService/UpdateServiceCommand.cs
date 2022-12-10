using Application.Features.Service.Dtos;
using Application.Features.Service.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Service.Commands.UpdateService
{
    public class UpdateServiceCommand : IRequest<UpdatedServiceDto>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public bool State { get; set; }
        public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, UpdatedServiceDto>
        {
            IServiceRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly ServiceBusinessRules _businessRules;

            public UpdateServiceCommandHandler(IServiceRepository repository, IMapper mapper, IFileService imageService, ServiceBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }   

            public async Task<UpdatedServiceDto> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                await _imageService.ImageUpload(request.File, "Services");

                Domain.Entities.Service service = new Domain.Entities.Service()
                {
                    ImgUrl = "wwwroot\\Uploads\\Services\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    Description = request.Description,
                    EmendatorAdminId = request.EmendatorAdminId,
                    State = request.State,
                    Title = request.Title,
                    Keywords = request.Keywords
                };

                Domain.Entities.Service created = await _repository.UpdateAsync(service);
                UpdatedServiceDto createdDto = _mapper.Map<UpdatedServiceDto>(created);

                return createdDto;
            }
        }
    }
}
