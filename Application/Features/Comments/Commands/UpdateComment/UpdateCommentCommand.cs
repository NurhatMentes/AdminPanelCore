using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Comments.Commands.CreateComment;
using Application.Features.Comments.Dtos;
using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand:IRequest<UpdatedCommentDto>
    {
        public int CommentId { get; set; }
        public int? BlogId { get; set; }
        public int? ProductId { get; set; }
        public bool Confirmation { get; set; }

        public UpdateCommentCommand()
        {
            
        }
        public UpdateCommentCommand(int? BlogId, int? ProductId)
        {
            this.BlogId = BlogId ?? 3;
            this.ProductId = ProductId ?? 1;
        }

        public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdatedCommentDto>
        {
            ICommentRepository _repository;
            IMapper _mapper;
            private readonly CommentBusinessRules _businessRules;

            public UpdateCommentCommandHandler(ICommentRepository repository, IMapper mapper, CommentBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedCommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                if (request.ProductId != null)
                    await _businessRules.ProductShouldExistWhenRequested(request.ProductId);
                if (request.BlogId != null)
                    await _businessRules.BlogShouldExistWhenRequested(request.BlogId);
                if (request.ProductId == null)
                    request.ProductId = 1;
                if (request.BlogId == null)
                    request.BlogId = 1;

                Comment mapped = _mapper.Map<Comment>(request);
                Comment updated = await _repository.UpdateAsync(mapped);
                UpdatedCommentDto updatedDto = _mapper.Map<UpdatedCommentDto>(updated);

                return updatedDto;
            }
        }
    }
}