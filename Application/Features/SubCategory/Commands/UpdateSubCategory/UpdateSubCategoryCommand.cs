using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Features.SubCategory.Dtos;
using Application.Features.SubCategory.Rules;

namespace Application.Features.SubCategory.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommand : IRequest<UpdatedSubCategoryDto>
    {
        public IFormFile File { get; set; }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public int? CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool State { get; set; }

        public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, UpdatedSubCategoryDto>
        {
            ISubCategoryRepository _repository;
            IMapper _mapper;
            IFileService _imageService;
            private readonly SubCategoryBusinessRules _businessRules;

            public UpdateSubCategoryCommandHandler(ISubCategoryRepository repository, IMapper mapper, IFileService imageService, SubCategoryBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
                _businessRules = businessRules;
            }

            public async Task<UpdatedSubCategoryDto> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                await _imageService.ImageUpload(request.File, "SubCategories");


                Domain.Entities.SubCategory slider = new Domain.Entities.SubCategory()
                {
                    Id = request.Id,
                    UserId = request.UserId,
                    ImgUrl = "wwwroot\\Uploads\\SubCategories\\" + request.File.FileName.Split(".")[0] + ".webp",
                    SubCategoryName = request.SubCategoryName,
                    EmendatorAdminId = request.EmendatorAdminId,
                    State = request.State,
                    CategoryId = request.CategoryId,
                };

                Domain.Entities.SubCategory mapped = _mapper.Map<Domain.Entities.SubCategory>(slider);
                Domain.Entities.SubCategory updated = await _repository.UpdateAsync(mapped);
                UpdatedSubCategoryDto mappedDto = _mapper.Map<UpdatedSubCategoryDto>(updated);

                return mappedDto;
            }
        }
    }
}
