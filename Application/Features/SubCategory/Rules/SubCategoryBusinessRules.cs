using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.SubCategory.Constants;

namespace Application.Features.SubCategory.Rules
{
    public class SubCategoryBusinessRules
    {
        private readonly ISubCategoryRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public SubCategoryBusinessRules(ISubCategoryRepository subCategoryRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _repository = subCategoryRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var user = await _userRepository.GetAsync(a => a.Id == userId);
            if (user == null) throw new BusinessException(Messages.UserShouldExistWhenRequested);
        }

        public async Task CategoryShouldExistWhenRequested(int categoryId)
        {
            var user = await _categoryRepository.GetAsync(a => a.Id == categoryId);
            if (user == null) throw new BusinessException(Messages.CategoryShouldExistWhenRequested);
        }
    }
}
