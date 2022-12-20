using Core.Application.Requests;
using Application.Features.Comments.Models;
using MediatR;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.Comments.Queries
{
    public class GetListCommentQuery:IRequest<CommentListModel>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public PageRequest PageRequest { get; set; }

        public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, CommentListModel>
        {
            ICommentRepository _repository;
            IMapper _mapper;

            public GetListCommentQueryHandler(ICommentRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CommentListModel> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Comment> commentAsync = await _repository.GetListAsync(
                    include:m=>m
                        .Include(m=>m.Blogs)
                        .Include(m=>m.Products),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                CommentListModel mappedListModel = _mapper.Map<CommentListModel>(commentAsync);

                return mappedListModel;
            }
        }
    }
}