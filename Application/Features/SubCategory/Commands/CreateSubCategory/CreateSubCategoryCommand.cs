using Application.Features.SubCategory.Dtos;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Features.SubCategory.Rules;

namespace Application.Features.SubCategory.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommand : IRequest<CreatedSubCategoryDto>
    {
        public IFormFile File { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool State { get; set; }

        public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, CreatedSubCategoryDto>
        {
            ISubCategoryRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly SubCategoryBusinessRules _businessRules;

            public CreateSubCategoryCommandHandler(ISubCategoryRepository repository, IMapper mapper, IFileService imageService, SubCategoryBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<CreatedSubCategoryDto> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _imageService.ImageUpload(request.File, "SubCategories");

                Domain.Entities.SubCategory subCategory = new Domain.Entities.SubCategory()
                {
                    ImgUrl = "wwwroot\\Uploads\\SubCategories\\" + request.File.FileName.Split(".")[0] + ".webp",
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    EmendatorAdminId = null,
                    State = true,
                    SubCategoryName = request.SubCategoryName,
                };

                //Domain.Entities.Slider mapped = _mapper.Map<Domain.Entities.Slider>(request);
                Domain.Entities.SubCategory created = await _repository.AddAsync(subCategory);
                CreatedSubCategoryDto createdDto = _mapper.Map<CreatedSubCategoryDto>(created);

                return createdDto;
            }
        }
    }
}
