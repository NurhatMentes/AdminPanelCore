using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand:IRequest<CreatedUserOperationClaimDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1" };
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }

    public class CreateUserOperationClaimCommandHandler:IRequestHandler<CreateUserOperationClaimCommand,CreatedUserOperationClaimDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserOperationClaimRepository _repository;
        private readonly UserOperationClaimBusinessRules _rules;

        public CreateUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository repository, UserOperationClaimBusinessRules rules)
        {
            _mapper = mapper;
            _repository = repository;
            _rules = rules;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _rules.ClaimShouldExistWhenRequested(request.OperationClaimId);
            await _rules.ClaimUserCanNotBeDuplicatedWhenInserted(request.UserId);
            await _rules.UserShouldExistWhenRequested(request.UserId);
       


            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim createdUserOperationClaim = await _repository.AddAsync(mappedUserOperationClaim);
            CreatedUserOperationClaimDto createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
            return createdUserOperationClaimDto;
        }
    }
}
