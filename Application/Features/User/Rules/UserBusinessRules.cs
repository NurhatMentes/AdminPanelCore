using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _userRepository.GetListAsync(b => b.Email == email);
            if (result.Items.Any()) throw new BusinessException(Messages.MailCanNotBeDuplicatedWhenInserted);
        }

        public async Task UserShouldExistWhenRequested(string email)
        {
            var result = await _userRepository.GetListAsync(b => b.Email == email);
            if (!result.Items.Any()) throw new BusinessException(Messages.UserShouldExistWhenRequested);
        }
    }
}