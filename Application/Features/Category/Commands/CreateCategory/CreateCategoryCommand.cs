﻿using Application.Features.Category.Dtos;
using Application.Features.Category.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<CreatedCategoryDto>
    {
        public int UserId { get; set; }
        public IFormFile File { get; set; }
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
                await _imageService.ImageUpload(request.File, "Categories");

                Domain.Entities.Category category = new Domain.Entities.Category()
                {
                    ImgUrl = "wwwroot\\Uploads\\Categories\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    Description = request.Description,
                    EmendatorAdminId = null,
                    State = true,
                    CategoryName = request.CategoryName,
                };

                Domain.Entities.Category created = await _repository.AddAsync(category);
                CreatedCategoryDto createdDto = _mapper.Map<CreatedCategoryDto>(created);

                return createdDto;
            }
        }
    }
}
