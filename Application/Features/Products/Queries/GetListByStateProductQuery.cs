using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.Products.Queries
{
    public class GetListByStateProductQuery : IRequest<ProductListModel>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public PageRequest PageRequest { get; set; }
        public bool State { get; set; }


        public class GetListByStateProductQueryHandler : IRequestHandler<GetListByStateProductQuery, ProductListModel>
        {
            private readonly IProductRepository _repository;
            private readonly IMapper _mapper;

            public GetListByStateProductQueryHandler(IProductRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ProductListModel> Handle(GetListByStateProductQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Product> productAsync = await _repository.GetListAsync(product => product.State==request.State,
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
