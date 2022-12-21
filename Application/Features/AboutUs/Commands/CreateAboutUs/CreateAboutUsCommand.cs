using Application.Features.AboutUs.Dtos;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using MediatR;

namespace Application.Features.AboutUs.Commands.CreateAboutUs
{
   
    public class CreateAboutUsCommand:IRequest<CreatedAboutUsDto>
    {
        public string[] Roles => new[] { "0", "1","2" };
        public int UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public class CreateAboutUsCommandHandler : IRequestHandler<CreateAboutUsCommand, CreatedAboutUsDto>
        {
            private readonly IAboutUsRepository _repository;
            private readonly IMapper _mapper;
            private readonly ITablesLogService _logger;

            public CreateAboutUsCommandHandler(IAboutUsRepository repository, IMapper mapper, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<CreatedAboutUsDto> Handle(CreateAboutUsCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.AboutUs mapped = _mapper.Map<Domain.Entities.AboutUs>(request);
                Domain.Entities.AboutUs created = await _repository.AddAsync(mapped);
                CreatedAboutUsDto createdDto = _mapper.Map<CreatedAboutUsDto>(created);
                await _logger.CreateTablesLog(createdDto.UserId, createdDto.Id, "Hakkımızda", createdDto.Description);
                return createdDto;
            }
        }
    }
}
