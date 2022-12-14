using Application.Features.Blogs.Dtos;
using Application.Features.Blogs.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand:IRequest<CreatedBlogDto>
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Keywords { get; set; }
        public bool State { get; set; }
        public IFormFile File { get; set; }

        public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreatedBlogDto>
        {
            private readonly IBlogRepository _repository;
            private readonly IMapper _mapper;
            private readonly IFileService _fileService;
            private readonly BlogBusinessRules _businessRules;

            public CreateBlogCommandHandler(IBlogRepository repository, IMapper mapper, IFileService imageService, BlogBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _fileService = imageService;
                _businessRules = businessRules;
            }

            public async Task<CreatedBlogDto> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _businessRules.CategoryShouldExistWhenRequested(request.CategoryId);
                if (request.SubCategoryId != null)
                    await _businessRules.SubCategoryShouldExistWhenRequested(request.SubCategoryId);
                await _fileService.ImageUpload(request.File, "Blogs");



                Blog blog = new Blog()
                {
                    ImgUrl = "wwwroot\\Uploads\\Blogs\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    EmendatorAdminId = null,
                    State = true,
                    SubCategoryId = request.SubCategoryId ?? 1,
                    Title = request.Title,
                    Content = request.Content,
                    Keywords = request.Keywords
                };

                Blog created = await _repository.AddAsync(blog);
                CreatedBlogDto createdDto = _mapper.Map<CreatedBlogDto>(created);

                return createdDto;
            }
        }
    }
}