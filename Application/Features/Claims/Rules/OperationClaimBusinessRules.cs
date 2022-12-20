using Application.Features.Claims.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Claims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _repository;

        public OperationClaimBusinessRules(IOperationClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task ClaimNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _repository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.NameCanNotBeDuplicatedWhenInserted);
        }

        public async Task ClaimNameCanNotBeDuplicatedWhenUpdated(string name)
        {
            IPaginate<OperationClaim> result = await _repository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.NameCanNotBeDuplicatedWhenInserted);
        }

        public async Task ClaimShouldExistWhenRequested(int id)
        {
            OperationClaim? operationClaim = await _repository.GetAsync(p => p.Id == id);
            if (operationClaim == null) throw new BusinessException(Messages.ShouldExistWhenRequested);
        }
    }
}
