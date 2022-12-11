using Application.Features.Product.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Features.Product.Rules;
using Application.Services.FileService;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdatedProductDto>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? UserId { get; set; }
        public IFormFile ImgFile { get; set; }
        public IFormFile File { get; set; }
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
            IProductRepository _repository;
            IMapper _mapper;
            IFileService _fileService;
            private readonly ProductBusinessRules _businessRules;

            public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper, IFileService imageService, ProductBusinessRules businessRules)
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
                await _fileService.ImageUpload(request.ImgFile, "Products");
                await _fileService.FileUpload(request.File, "Products");

                var oldProduct= await _repository.GetAsync(p => p.Id == request.Id);

                Domain.Entities.Product product = new Domain.Entities.Product()
                {
                    Id = request.Id,
                    ImgUrl = "wwwroot\\Uploads\\Products\\" + request.ImgFile.FileName.Split(".")[0] + ".webp",
                    File = "wwwroot\\Pdfs\\Products\\" + request.File.FileName.Split(".")[0] + ".pdf",
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    SubCategoryId = request.SubCategoryId,
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

                Domain.Entities.Product updated = await _repository.UpdateAsync(product);
                UpdatedProductDto updatedDto = _mapper.Map<UpdatedProductDto>(updated);

                return updatedDto;
            }
        }
    }
}
