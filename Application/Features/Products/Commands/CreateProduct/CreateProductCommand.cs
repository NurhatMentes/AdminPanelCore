using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using Application.Services.TablesLogService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreatedProductDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int? Stock { get; set; }
        public string Color { get; set; }
        public string Content { get; set; }
        public string Keywords { get; set; }
        public IFormFile ImgFile { get; set; }
        public IFormFile? File { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
        {
            IProductRepository _repository;
            IMapper _mapper;
            IFileService _fileService;
            private readonly ProductBusinessRules _businessRules;
            private readonly ITablesLogService _logger;

            public CreateProductCommandHandler(IProductRepository repository, IMapper mapper, IFileService imageService, ProductBusinessRules businessRules, ITablesLogService logger)
            {
                _repository = repository;
                _mapper = mapper;
                _fileService = imageService;
                _businessRules = businessRules;
                _logger = logger;
            }

            public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.UserId);
                await _businessRules.CategoryShouldExistWhenRequested(request.CategoryId);
                if (request.SubCategoryId != null)
                    await _businessRules.SubCategoryShouldExistWhenRequested(request.SubCategoryId);
                await _fileService.ImageUpload(request.ImgFile, "Products");
                if (request.File != null)
                    await _fileService.FileUpload(request.File, "Products");


                Product product = new Product()
                {
                    ImgUrl = "wwwroot\\Uploads\\Products\\" + request.ImgFile.FileName.Split(".")[0] + ".webp",
                    File = request.File is null ? "Yok" : "wwwroot\\Pdfs\\Products\\" + request.File.FileName.Split(".")[0] + ".pdf",
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    EmendatorAdminId = null,
                    State = true,
                    SubCategoryId = request.SubCategoryId ?? 1,
                    Title = request.Title,
                    Price = request.Price,
                    Stock = request.Stock,
                    Color = request.Color,
                    Content = request.Content,
                    Keywords = request.Keywords
                };

                Product created = await _repository.AddAsync(product);
                CreatedProductDto createdDto = _mapper.Map<CreatedProductDto>(created);
                await _logger.CreateTablesLog(createdDto.UserId, createdDto.Id, "Ürün", createdDto.Title);
                return createdDto;
            }
        }
    }
}