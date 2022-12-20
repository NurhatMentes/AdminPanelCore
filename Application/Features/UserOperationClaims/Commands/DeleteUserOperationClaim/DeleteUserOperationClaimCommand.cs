using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand:IRequest<DeletedUserOperationClaimDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0","1"};
        public int Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler:IRequestHandler<DeleteUserOperationClaimCommand,DeletedUserOperationClaimDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserOperationClaimRepository _repository;
            private readonly UserOperationClaimBusinessRules _rules;

            public DeleteUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository repository, UserOperationClaimBusinessRules rules)
            {
                _mapper = mapper;
                _repository = repository;
                _rules = rules;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _rules.UserClaimShouldExistWhenRequested(request.Id);
                await _rules.UserCantEffectWhenClaimLowerThenSelected(request.Id);

                UserOperationClaim? userOperationClaim = await _repository.GetAsync(x => x.Id == request.Id);
                UserOperationClaim deletedUserOperationClaim = await _repository.DeleteAsync(userOperationClaim);
                DeletedUserOperationClaimDto mappedUserOperation = _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
                return mappedUserOperation;
            }
        }
    }
}
