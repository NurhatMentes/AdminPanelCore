using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.Comments.Constants;

namespace Application.Features.Comments.Rules
{
    public class CommentBusinessRules
    {
        private ICommentRepository _repository;
        private IProductRepository _productRepository;
        private IBlogRepository? _blogRepository;

        public CommentBusinessRules(ICommentRepository repository, IProductRepository productRepository, IBlogRepository? blogRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _blogRepository = blogRepository;
        }
        public async Task ProductShouldExistWhenRequested(int? productId)
        {
            var product = await _productRepository.GetAsync(a => a.Id == productId);
            if (product == null) throw new BusinessException(Messages.ProductShouldExistWhenRequested);
        }
        public async Task BlogShouldExistWhenRequested(int? blogId)
        {
            var product = await _blogRepository.GetAsync(a => a.Id == blogId);
            if (product == null) throw new BusinessException(Messages.BlogShouldExistWhenRequested);
        }
    }
}
