using Application.Features.Blogs.Models;
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
using Core.Persistence.Repositories;

namespace Application.Features.Blogs.Queris
{
    public class GetListByStateBlogQuery:IRequest<BlogListModel>
    {
        public PageRequest PageRequest { get; set; } 
        public bool State { get; set; }


        public class GetListByStateBlogQueryHandler : IRequestHandler<GetListByStateBlogQuery, BlogListModel>
        {
            private readonly IBlogRepository _repository;
            private readonly IMapper _mapper;

            public GetListByStateBlogQueryHandler(IBlogRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<BlogListModel> Handle(GetListByStateBlogQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Blog> blogAsync = await _repository.GetListAsync(blog => blog.State==request.State,
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
