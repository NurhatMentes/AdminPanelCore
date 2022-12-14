using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Blogs.Models;
using Application.Features.Products.Models;
using Application.Features.Products.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Blogs.Queris
{
    public class GetListBlogQuery:IRequest<BlogListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListBlogQueryHandler : IRequestHandler<GetListBlogQuery, BlogListModel>
        {
            private readonly IBlogRepository _repository;
            private readonly IMapper _mapper;

            public GetListBlogQueryHandler(IBlogRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<BlogListModel> Handle(GetListBlogQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Blog> blogAsync = await _repository.GetListAsync(
                    include: m => m
                        .Include(m => m.User)
                        .Include(m => m.Categories)
                        .Include(m => m.SubCategories),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);



                BlogListModel mappedListModel = _mapper.Map<BlogListModel>(blogAsync);

                return mappedListModel;
            }
        }
    }
}
