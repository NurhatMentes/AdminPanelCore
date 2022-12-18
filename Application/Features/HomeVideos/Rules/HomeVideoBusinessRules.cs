using Application.Features.HomeVideos.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.HomeVideos.Rules
{
    public class HomeVideoBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public HomeVideoBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var user = await _userRepository.GetAsync(a => a.Id == userId);
            if (user == null) throw new BusinessException(Messages.UserShouldExistWhenRequested);
        }

        
    }
}
