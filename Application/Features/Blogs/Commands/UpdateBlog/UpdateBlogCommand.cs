using Application.Features.Blogs.Dtos;
using Application.Features.Blogs.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommand:IRequest<UpdatedBlogDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool State { get; set; }
        public string Keywords { get; set; }
        public IFormFile File { get; set; }

        public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, UpdatedBlogDto>
        {
            private readonly IBlogRepository _repository;
            private readonly IMapper _mapper;
            private readonly IFileService _fileService;
            private readonly BlogBusinessRules _businessRules;

            public UpdateBlogCommandHandler(IBlogRepository repository, IMapper mapper, IFileService imageService, BlogBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _fileService = imageService;
                _businessRules = businessRules;
            }

            public async Task<UpdatedBlogDto> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _businessRules.CategoryShouldExistWhenRequested(request.CategoryId);
                if (request.SubCategoryId != null)
                    await _businessRules.SubCategoryShouldExistWhenRequested(request.SubCategoryId);
                await _fileService.ImageUpload(request.File, "Blogs");

                var entity = await _repository.GetAsync(p => p.Id == request.BlogId);

       
                entity.ImgUrl = "wwwroot\\Uploads\\Blogs\\" + request.File.FileName.Split(".")[0] + ".webp";
                entity.UserId = request.UserId;
                entity.CategoryId = request.CategoryId;
                entity.SubCategoryId = request.SubCategoryId ?? 1;
                entity.EmendatorAdminId = request.EmendatorAdminId;
                entity.State = request.State;
                entity.Title = request.Title;
                entity.Content = request.Content;
                entity.Keywords = request.Keywords;
         

                Blog updated = await _repository.UpdateAsync(entity);
                UpdatedBlogDto updatedDto = _mapper.Map<UpdatedBlogDto>(updated);

                return updatedDto;
            }
        }
    }
}