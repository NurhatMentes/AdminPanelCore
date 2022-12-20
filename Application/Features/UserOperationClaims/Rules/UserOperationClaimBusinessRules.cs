using Application.Features.UserOperationClaims.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Extensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _repository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        //CreatedCommand
        public async Task ClaimUserCanNotBeDuplicatedWhenInserted(int id)
        {
            IPaginate<UserOperationClaim> result = await _repository.GetListAsync(p => p.User.Id == id);
            if (result.Items.Any()) throw new BusinessException(Messages.UserCanNotBeDuplicatedWhenInserted);
        }

        public async Task ClaimIdCanNotBeDuplicatedWhenUpdated(int id)
        {
            IPaginate<UserOperationClaim> result = await _repository.GetListAsync(p => p.User.Id == id);
            if (result.Items.Any()) throw new BusinessException(Messages.UserCanNotBeDuplicatedWhenInserted);
        }

        //DeletedCommand
        public async Task UserClaimShouldExistWhenRequested(int userId)
        {
            UserOperationClaim? operationClaim = await _repository.GetAsync(x => x.UserId == userId);
            if (operationClaim == null) throw new BusinessException(Messages.UserShouldExistWhenRequested);
        }

        //CreatedCommand
        public async Task UserShouldExistWhenRequested(int userId)
        {
            User? user = await _userRepository.GetAsync(x => x.Id == userId);
            if (user == null) throw new BusinessException(Messages.UserShouldExistWhenRequested);
        }

        //CreatedCommand
        public async Task ClaimShouldExistWhenRequested(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(p => p.Id == id);
            if (operationClaim == null) throw new BusinessException(Messages.ClaimShouldExistWhenRequested);
        }

        public async Task UserOperationClaimShouldExistWhenRequested(int id)
        {
            UserOperationClaim? operationClaim = await _repository.GetAsync(p => p.Id == id);
            if (operationClaim == null) throw new BusinessException(Messages.ClaimShouldExistWhenRequested);
        }

        public async Task UserCantEffectWhenClaimLowerThenSelected(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var auth = _httpContextAccessor.HttpContext.User.ClaimRoles().FirstOrDefault();


            if (Convert.ToInt16(auth) == 1 || Convert.ToInt16(auth) == 0)
            {
                if (Convert.ToInt16(userId) == id)
                    throw new BusinessException("Kendi Yetki seviyeni değiştiremezsin!");
                if (id == 2)
                    throw new BusinessException("Bu kullanıcının Yetki seviyesini değiştiremezsin!");
            }
            else
                throw new BusinessException("Yetki seviyesini değiştirme yetkiniz Yok!");
        }
    }
}
