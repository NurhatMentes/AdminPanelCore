using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Features.Products.Rules;
using Application.Services.FileService;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdatedProductDto>, ISecuredRequest
{
    public string[] Roles => new[] { "0", "1", "2" };
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public int? UserId { get; set; }
    public IFormFile ImgFile { get; set; }
    public IFormFile? File { get; set; }
    public int EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public int? Stock { get; set; }
    public string Color { get; set; }
    public string Content { get; set; }
    public string Keywords { get; set; }
    public bool State { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ProductBusinessRules _businessRules;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper, IFileService imageService,
            ProductBusinessRules businessRules)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = imageService;
            _businessRules = businessRules;
        }

        public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
            await _businessRules.CategoryShouldExistWhenRequested(request.CategoryId);
            if (request.SubCategoryId != null)
                await _businessRules.SubCategoryShouldExistWhenRequested(request.SubCategoryId);
            await _fileService.ImageUpload(request.ImgFile, "Products");
            if (request.File != null)
                await _fileService.FileUpload(request.File, "Products");


            var oldProduct = await _repository.GetAsync(p => p.Id == request.ProductId);
            var entity = await _repository.GetAsync(p => p.Id == request.ProductId);

            entity.ImgUrl = "wwwroot\\Uploads\\Products\\" + request.ImgFile.FileName.Split(".")[0] + ".webp";
            entity.File = request.File is null
                    ? "Yok"
                    : "wwwroot\\Pdfs\\Products\\" + request.File.FileName.Split(".")[0] + ".pdf";
            entity.UserId = request.UserId;
            entity.CategoryId = request.CategoryId;
            entity.SubCategoryId = request.SubCategoryId ?? 1;
            entity.EmendatorAdminId = request.EmendatorAdminId;
            entity.State = request.State;
            entity.Title = request.Title;
            entity.Price = request.Price;
            entity.OldPrice = oldProduct.Price;
            entity.Stock = request.Stock;
            entity.Color = request.Color;
            entity.Content = request.Content;
            entity.UpdateDate = DateTime.UtcNow;
            entity.Keywords = request.Keywords;


            var updated = await _repository.UpdateAsync(entity);
            var updatedDto = _mapper.Map<UpdatedProductDto>(updated);

            return updatedDto;
        }
    }
}