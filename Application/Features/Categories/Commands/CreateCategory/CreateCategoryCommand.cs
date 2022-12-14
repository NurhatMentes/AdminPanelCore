﻿using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<CreatedCategoryDto>
    {
        public int UserId { get; set; }
        public IFormFile? File { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
        {
            private readonly ICategoryRepository _repository;
            private readonly IMapper _mapper;
            private readonly IFileService _imageService;
            private readonly CategoryBusinessRules _businessRules;

            public CreateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper, IFileService imageService, CategoryBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                if (request.File != null)
                    await _imageService.ImageUpload(request.File, "Categories");

                Category category = new Category()
                {
                    ImgUrl = request.File is null ? "Yok" : "wwwroot\\Uploads\\Categories\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    Description = request.Description,
                    EmendatorAdminId = null,
                    State = true,
                    CategoryName = request.CategoryName,
                };

                Category created = await _repository.AddAsync(category);
                CreatedCategoryDto createdDto = _mapper.Map<CreatedCategoryDto>(created);

                return createdDto;
            }
        }
    }
}