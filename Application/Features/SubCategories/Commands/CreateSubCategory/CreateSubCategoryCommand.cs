using Application.Features.SubCategories.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Features.SubCategories.Rules;
using Application.Services.FileService;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Application.Services.TablesLogService;

namespace Application.Features.SubCategories.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommand : IRequest<CreatedSubCategoryDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public IFormFile File { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool State { get; set; }

        public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, CreatedSubCategoryDto>
        {
            ISubCategoryRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly SubCategoryBusinessRules _businessRules;
            private readonly ITablesLogService _logger;


            public CreateSubCategoryCommandHandler(ISubCategoryRepository repository, IMapper mapper, IFileService imageService, SubCategoryBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<CreatedSubCategoryDto> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _businessRules.CategoryShouldExistWhenRequested(request.CategoryId);
                await _imageService.ImageUpload(request.File, "SubCategories");

                SubCategory subCategory = new SubCategory()
                {
                    ImgUrl = "wwwroot\\Uploads\\SubCategories\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    EmendatorAdminId = null,
                    State = true,
                    SubCategoryName = request.SubCategoryName,
                };

                //Domain.Entities.Slider mapped = _mapper.Map<Domain.Entities.Slider>(request);
                SubCategory created = await _repository.AddAsync(subCategory);
                CreatedSubCategoryDto createdDto = _mapper.Map<CreatedSubCategoryDto>(created);
                await _logger.CreateTablesLog(createdDto.UserId, createdDto.SubCategoryId, "Alt Kategori", createdDto.SubCategoryName);


                return createdDto;
            }
        }
    }
}
