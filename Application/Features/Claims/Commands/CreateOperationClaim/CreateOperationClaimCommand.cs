using Application.Features.Claims.Dtos;
using Application.Features.Claims.Rules;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Claims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand:IRequest<CreatedOperationClaimDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1" };
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler:IRequestHandler<CreateOperationClaimCommand,CreatedOperationClaimDto>
        {
            IOperationClaimRepository _repository;
            IMapper _mapper;
            OperationClaimBusinessRules _rules;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository repository, IMapper mapper, OperationClaimBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _rules.ClaimNameCanNotBeDuplicatedWhenInserted(request.Name);

                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim createdOperationClaim = await _repository.AddAsync(mappedOperationClaim);
                CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
                return createdOperationClaimDto;
            }
        }
    }
}
