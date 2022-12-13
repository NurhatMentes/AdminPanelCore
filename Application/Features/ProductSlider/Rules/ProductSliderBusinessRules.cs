using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.ProductSlider.Constants;

namespace Application.Features.ProductSlider.Rules
{
    public class ProductSliderBusinessRules
    {
        private readonly IProductSliderRepository _repository;
        private readonly IProductRepository _productRepository;

        public ProductSliderBusinessRules(IProductSliderRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task ProductShouldExistWhenRequested(int productId)
        {
            var user = await _productRepository.GetAsync(a => a.Id == productId);
            if (user == null) throw new BusinessException(Messages.ProductShouldExistWhenRequested);
        }
    }
}
