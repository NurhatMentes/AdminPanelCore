using Application.Features.Category.Models;
using Application.Features.Slider.Models;
using Application.Features.Slider.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries
{
    public class GetListCategoryQuery : IRequest<CategoryListModel>
    {
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
                IPaginate<Domain.Entities.Category> categoryAsync = await _repository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                //data model
                CategoryListModel mappedListModel = _mapper.Map<CategoryListModel>(categoryAsync);

                return mappedListModel;
            }
        }
    }
}
