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

        public ProductBusinessRules(IUserRepository userRepository, ICategoryRepository categoryRepository, IProductRepository repository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _repository = repository;
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
