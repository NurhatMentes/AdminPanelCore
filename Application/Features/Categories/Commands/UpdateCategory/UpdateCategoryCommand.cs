using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest<UpdatedCategoryDto>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public IFormFile File { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
        {
            ICategoryRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly CategoryBusinessRules _businessRules;

            public UpdateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper, IFileService imageService, CategoryBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                await _imageService.ImageUpload(request.File, "Categories");

                Category category = new Category()
                {
                    Id = request.Id,
                    ImgUrl = "wwwroot\\Uploads\\Categories\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    Description = request.Description,
                    EmendatorAdminId = request.EmendatorAdminId,
                    State = request.State,
                    CategoryName = request.CategoryName,
                };

                Category updated = await _repository.UpdateAsync(category);
                UpdatedCategoryDto updatedDto = _mapper.Map<UpdatedCategoryDto>(updated);

                return updatedDto;
            }
        }
    }
}
