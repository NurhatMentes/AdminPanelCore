using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand:IRequest<UpdatedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
      
        public class UpdateUserOperationClaimCommandHandler:IRequestHandler<UpdateUserOperationClaimCommand,UpdatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _repository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _rules;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository repository, IMapper mapper, UserOperationClaimBusinessRules Rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = Rules;
            }

            public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _rules.ClaimShouldExistWhenRequested(request.OperationClaimId);
                await _rules.UserShouldExistWhenRequested(request.UserId);
                await _rules.UserCantEffectWhenClaimLowerThenSelected(request.UserId);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim userOperationClaim =  _repository.Update(mappedUserOperationClaim);
                UpdatedUserOperationClaimDto operationClaimDto = _mapper.Map<UpdatedUserOperationClaimDto>(userOperationClaim);
                return operationClaimDto;
            }
        }
    }
}
