using Application.Features.Product.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Queries
{
    public class GetListProductQuery : IRequest<ProductListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, ProductListModel>
        {
             IProductRepository _repository;
             IMapper _mapper;

            public GetListProductQueryHandler(IProductRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ProductListModel> Handle(GetListProductQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.Product> productAsync =await  _repository.GetListAsync(
                    include: m => m
                        .Include(m => m.User)
                        .Include(m => m.Categories)
                        .Include(m => m.SubCategories)
                       /* .Include(m => m.Comments)*/,
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);



                ProductListModel mappedListModel = _mapper.Map<ProductListModel>(productAsync);

                return mappedListModel;
            }
        }
    }
}
