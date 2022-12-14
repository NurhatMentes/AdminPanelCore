using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Features.Products.Rules;
using Application.Services.FileService;
using Domain.Entities;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdatedProductDto>
{
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

            var product = new Product()
            {
                Id = request.ProductId,
                ImgUrl = "wwwroot\\Uploads\\Products\\" + request.ImgFile.FileName.Split(".")[0] + ".webp",
                File = request.File is null
                    ? "Yok"
                    : "wwwroot\\Pdfs\\Products\\" + request.File.FileName.Split(".")[0] + ".pdf",
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                SubCategoryId = request.SubCategoryId ?? 1,
                EmendatorAdminId = request.EmendatorAdminId,
                State = request.State,
                Title = request.Title,
                Price = request.Price,
                OldPrice = oldProduct.Price,
                Stock = request.Stock,
                Color = request.Color,
                Content = request.Content,
                UpdateDate = DateTime.UtcNow,
                Keywords = request.Keywords
            };
          

            var updated = await _repository.UpdateAsync(product);
            var updatedDto = _mapper.Map<UpdatedProductDto>(updated);

            return updatedDto;
        }
    }
}