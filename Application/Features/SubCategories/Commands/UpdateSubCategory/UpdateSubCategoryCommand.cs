using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Features.SubCategories.Dtos;
using Application.Features.SubCategories.Rules;
using Application.Services.FileService;
using Domain.Entities;

namespace Application.Features.SubCategories.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommand : IRequest<UpdatedSubCategoryDto>
    {
        public IFormFile File { get; set; }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public int CategoryId { get; set; }
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
                await _businessRules.CategoryShouldExistWhenRequested(request.CategoryId);
                await _imageService.ImageUpload(request.File, "SubCategories");

                var entity = await _repository.GetAsync(p => p.Id == request.Id);

                entity.ImgUrl = "wwwroot\\Uploads\\SubCategories\\" + request.File.FileName.Split(".")[0] + ".webp";
                entity.SubCategoryName = request.SubCategoryName;
                entity.EmendatorAdminId = request.EmendatorAdminId;
                entity.State = request.State;
                entity.CategoryId = request.CategoryId;


                SubCategory mapped = _mapper.Map<SubCategory>(entity);
                SubCategory updated = await _repository.UpdateAsync(mapped);
                UpdatedSubCategoryDto mappedDto = _mapper.Map<UpdatedSubCategoryDto>(updated);

                return mappedDto;
            }
        }
    }
}
