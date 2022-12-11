using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.Category.Constants;

namespace Application.Features.Category.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _repository;
        private readonly IUserRepository _userRepository;

        public CategoryBusinessRules(ICategoryRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var user = await _userRepository.GetAsync(a => a.Id == userId);
            if (user == null) throw new BusinessException(Messages.UserShouldExistWhenRequested);
        }
    }
}
