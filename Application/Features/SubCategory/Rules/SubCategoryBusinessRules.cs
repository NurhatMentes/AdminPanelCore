using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.SubCategory.Constants;

namespace Application.Features.SubCategory.Rules
{
    public class SubCategoryBusinessRules
    {
        ISubCategoryRepository _repository;
        private IUserRepository _userRepository;

        public SubCategoryBusinessRules(ISubCategoryRepository subCategoryRepository, IUserRepository userRepository)
        {
            _repository = subCategoryRepository;
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var user = await _userRepository.GetAsync(a => a.Id == userId);
            if (user == null) throw new BusinessException(Messages.ShouldExistWhenRequested);
        }
    }
}
