using Application.Features.Comments.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Comments.Queries
{
    public class GetListByConfirmationCommentQuery : IRequest<CommentListModel>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public PageRequest PageRequest { get; set; }
        public bool Confirmation { get; set; }

        public class GetListByConfirmationCommentQueryHandler : IRequestHandler<GetListByConfirmationCommentQuery, CommentListModel>
        {
            ICommentRepository _repository;
            IMapper _mapper;

            public GetListByConfirmationCommentQueryHandler(ICommentRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CommentListModel> Handle(GetListByConfirmationCommentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Comment> commentAsync = await _repository.GetListAsync(comment => comment.Confirmation == request.Confirmation,
                    include: m => m
                        .Include(m => m.Blogs)
                        .Include(m => m.Products),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                CommentListModel mappedListModel = _mapper.Map<CommentListModel>(commentAsync);

                return mappedListModel;
            }
        }
    }
}