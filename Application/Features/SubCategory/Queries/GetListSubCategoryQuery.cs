using Application.Features.SubCategory.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SubCategory.Queries
{
    public class GetListSubCategoryQuery : IRequest<SubCategoryListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSubCategoryQueryHandler : IRequestHandler<GetListSubCategoryQuery, SubCategoryListModel>
        {
            private readonly ISubCategoryRepository _repository;
            private readonly IMapper _mapper;

            public GetListSubCategoryQueryHandler(ISubCategoryRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<SubCategoryListModel> Handle(GetListSubCategoryQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.SubCategory> subCategoryAsync = await _repository.GetListAsync(
                    include: m => m.Include(m => m.Categories).Include(m=>m.User),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                //data model
                SubCategoryListModel mappedListModel = _mapper.Map<SubCategoryListModel>(subCategoryAsync);

                return mappedListModel;
            }
        }
    }
}
