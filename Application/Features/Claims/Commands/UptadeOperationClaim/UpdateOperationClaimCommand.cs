using Application.Features.Claims.Dtos;
using Application.Features.Claims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Claims.Commands.UptadeOperationClaim
{
    public class UpdateOperationClaimCommand:IRequest<UpdatedOperationClaimDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1" };
        public int Id { get; set; }
        public string Name { get; set; }


        public class UptadeOperationClaimCommandHandler:IRequestHandler<UpdateOperationClaimCommand,UpdatedOperationClaimDto>
        {
            private readonly IMapper _mapper;
            private readonly IOperationClaimRepository _repository;
            private readonly OperationClaimBusinessRules _rules;

            public UptadeOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _mapper = mapper;
                _repository = operationClaimRepository;
                _rules = operationClaimBusinessRules;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _rules.ClaimNameCanNotBeDuplicatedWhenUpdated(request.Name);
                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim updatedOperationClaim = await _repository.UpdateAsync(mappedOperationClaim);
                UpdatedOperationClaimDto mappedUptadedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
                return mappedUptadedOperationClaimDto;
            }
        }
    }
}
