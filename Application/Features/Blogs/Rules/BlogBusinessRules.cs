using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.Blogs.Constants;

namespace Application.Features.Blogs.Rules
{
    public class BlogBusinessRules
    {
        private readonly IBlogRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public BlogBusinessRules(IBlogRepository repository, IUserRepository userRepository, ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
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
