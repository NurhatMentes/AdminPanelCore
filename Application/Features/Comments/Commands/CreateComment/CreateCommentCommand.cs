using Application.Features.Comments.Dtos;
using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommand:IRequest<CreatedCommentDto>
    {
        public int? BlogId { get; set; }
        public int? ProductId { get; set; }
        public string FirstLastName { get; set; }
        public string Email { get; set; }
        public string CommentContent { get; set; }


        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreatedCommentDto>
        {
            ICommentRepository _repository;
            IMapper _mapper;
            private readonly CommentBusinessRules _businessRules;

            public CreateCommentCommandHandler(ICommentRepository repository, IMapper mapper, CommentBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatedCommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
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
                Comment created = await _repository.AddAsync(mapped);
                CreatedCommentDto createdDto = _mapper.Map<CreatedCommentDto>(created);

                return createdDto;
            }
        }
    }
}
