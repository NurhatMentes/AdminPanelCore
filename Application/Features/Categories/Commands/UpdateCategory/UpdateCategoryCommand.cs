using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdatedCategoryDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public IFormFile? File { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
        {
            ICategoryRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly CategoryBusinessRules _businessRules;
            private readonly ITablesLogService _logger;

            public UpdateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper, IFileService imageService, CategoryBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                if (request.File != null)
                    await _imageService.ImageUpload(request.File, "Categories");

                var entity = await _repository.GetAsync(p => p.Id == request.Id);

                entity.ImgUrl = request.File is null ? "Yok" : "wwwroot\\Uploads\\Categories\\" + request.File.FileName.Split(".")[0] + ".webp";
                entity.UserId = request.UserId;
                entity.Description = request.Description;
                entity.EmendatorAdminId = request.EmendatorAdminId;
                entity.State = request.State;
                entity.CategoryName = request.CategoryName;


                Category updated = await _repository.UpdateAsync(entity);
                UpdatedCategoryDto updatedDto = _mapper.Map<UpdatedCategoryDto>(updated);
                await _logger.UpdateTablesLog(updatedDto.EmendatorAdminId, updatedDto.Id, "Kategori", updatedDto.CategoryName);
                return updatedDto;
            }
        }
    }
}
