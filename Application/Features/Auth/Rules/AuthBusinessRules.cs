using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserCanNotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<ExtendedUser> result = await _userRepository.GetListAsync(u => u.Email == email);
            if (result.Items.Any()) throw new BusinessException(Messages.MailCanNotBeDuplicatedWhenInserted);
        }

        public void UserShouldExistWhenRequested(ExtendedUser user)
        {
            if (user == null) throw new BusinessException(Messages.UserShouldExistWhenRequested);
        }
    }
}