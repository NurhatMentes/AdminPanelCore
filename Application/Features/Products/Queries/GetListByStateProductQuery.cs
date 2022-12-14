using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries
{
    public class GetListByStateProductQuery : IRequest<ProductListModel>
    {
        public PageRequest PageRequest { get; set; }
        public bool ProductState { get; set; }


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
                IPaginate<Product> productAsync = await _repository.GetListAsync(product => product.State==request.ProductState,
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
