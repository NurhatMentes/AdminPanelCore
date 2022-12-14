using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.Products.Constants;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public ProductBusinessRules(IUserRepository userRepository, ICategoryRepository categoryRepository, IProductRepository repository, ISubCategoryRepository subCategoryRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _repository = repository;
            _subCategoryRepository = subCategoryRepository;
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

        public async Task SubCategoryShouldExistWhenRequested(int? subCategoryId)
        {
            var user = await _categoryRepository.GetAsync(a => a.Id == subCategoryId);
            if (user == null) throw new BusinessException(Messages.CategoryShouldExistWhenRequested);
        }
    }
}
