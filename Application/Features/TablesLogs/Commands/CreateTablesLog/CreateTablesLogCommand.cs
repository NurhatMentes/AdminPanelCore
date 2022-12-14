using Application.Features.TablesLogs.Dtos;
using Application.Features.TablesLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TablesLogs.Commands.CreateTablesLog
{
    public class CreateTablesLogCommand:IRequest<CreatedTablesLogDto>
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string TableName { get; set; }
        public string ItemName { get; set; }
        public string Process { get; set; }
        public class CreateTablesLogCommandHandler : IRequestHandler<CreateTablesLogCommand, CreatedTablesLogDto>
        {
            private readonly ITablesLogRepository _repository;
            private readonly IMapper _mapper;
            private readonly TablesLogBusinessRules _rules;

            public CreateTablesLogCommandHandler(ITablesLogRepository repository, IMapper mapper, TablesLogBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreatedTablesLogDto> Handle(CreateTablesLogCommand request, CancellationToken cancellationToken)
            {
                await _rules.UserShouldExistWhenRequested(request.UserId);

                TablesLog mapped = _mapper.Map<TablesLog>(request);
                TablesLog created = await _repository.AddAsync(mapped);
                CreatedTablesLogDto createdDto = _mapper.Map<CreatedTablesLogDto>(created);

                return createdDto;
            }
        }
    }
}
