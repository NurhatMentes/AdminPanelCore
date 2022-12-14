using Application.Features.AboutUs.Dtos;
using Application.Features.AboutUs.Rules;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.AboutUs.Commands.UpdateAboutUs
{
    public class UpdateAboutUsCommand:IRequest<UpdatedAboutUsDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public class UpdateAboutUsCommandHandler : IRequestHandler<UpdateAboutUsCommand, UpdatedAboutUsDto>
        {
            private readonly IAboutUsRepository _repository;
            private readonly IMapper _mapper;
            private readonly AboutUsBusinessRules _rules;
            private readonly ITablesLogService _logger;



            public UpdateAboutUsCommandHandler(IAboutUsRepository repository, IMapper mapper, AboutUsBusinessRules rules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
                _logger = logger;
            }

            public async Task<UpdatedAboutUsDto> Handle(UpdateAboutUsCommand request, CancellationToken cancellationToken)
            {
                await _rules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                Domain.Entities.AboutUs mapped = _mapper.Map<Domain.Entities.AboutUs>(request);
                Domain.Entities.AboutUs updated = await _repository.UpdateAsync(mapped);
                UpdatedAboutUsDto uptadedDto = _mapper.Map<UpdatedAboutUsDto>(updated);
                await _logger.UpdateTablesLog(uptadedDto.EmendatorAdminId, uptadedDto.Id, "Hakkımızda", uptadedDto.Description);


                return uptadedDto;
            }
        }
    }
}
