using Application.Features.Blogs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Blogs.Queries;

public class GetListBlogQuery : IRequest<BlogListModel>, ISecuredRequest
{
    public string[] Roles => new[] { "0", "1", "2" };
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
            var blogAsync = await _repository.GetListAsync(
                include: m => m
                    .Include(m => m.User)
                    .Include(m => m.Categories)
                    .Include(m => m.SubCategories),
                index: request.PageRequest.Page, size: request.PageRequest.PageSize);


            var mappedListModel = _mapper.Map<BlogListModel>(blogAsync);

            return mappedListModel;
        }
    }
}