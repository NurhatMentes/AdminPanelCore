using Application.Features.Categories.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries
{
    public class GetListCategoryQuery : IRequest<CategoryListModel>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public PageRequest PageRequest { get; set; }

        public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, CategoryListModel>
        {
            private readonly ICategoryRepository _repository;
            private readonly IMapper _mapper;

            public GetListCategoryQueryHandler(ICategoryRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<CategoryListModel> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Category> categoryAsync = await _repository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                //data model
                CategoryListModel mappedListModel = _mapper.Map<CategoryListModel>(categoryAsync);

                return mappedListModel;
            }
        }
    }
}
