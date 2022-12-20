using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries
{
    public class GetListProductQuery : IRequest<ProductListModel>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public PageRequest PageRequest { get; set; }

        public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, ProductListModel>
        {
             private readonly IProductRepository _repository;
             private readonly IMapper _mapper;

            public GetListProductQueryHandler(IProductRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ProductListModel> Handle(GetListProductQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Product> productAsync =await  _repository.GetListAsync(
                    include: m => m
                        .Include(m => m.User)
                        .Include(m => m.Categories)
                        .Include(m => m.SubCategories),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);



                ProductListModel mappedListModel = _mapper.Map<ProductListModel>(productAsync);

                return mappedListModel;
            }
        }
    }
}
