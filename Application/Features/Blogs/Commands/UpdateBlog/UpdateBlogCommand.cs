using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Blogs.Commands.CreateBlog;
using Application.Features.Blogs.Dtos;
using Application.Features.Blogs.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommand:IRequest<UpdatedBlogDto>
    {
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



                Blog blog = new Blog()
                {
                    Id = request.BlogId,
                    ImgUrl = "wwwroot\\Uploads\\Blogs\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    SubCategoryId = request.SubCategoryId ?? 1,
                    EmendatorAdminId = request.EmendatorAdminId,
                    State = request.State,
                    Title = request.Title,
                    Content = request.Content,
                    Keywords = request.Keywords
                };

                Blog updated = await _repository.UpdateAsync(blog);
                UpdatedBlogDto updatedDto = _mapper.Map<UpdatedBlogDto>(updated);

                return updatedDto;
            }
        }
    }
}