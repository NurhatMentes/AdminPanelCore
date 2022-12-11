using Microsoft.AspNetCore.Http;

namespace Application.Services.FileService
{
    public interface IFileService
    {
        public Task<string> ImageUpload(IFormFile imgUrl, string fileName);
        public Task<string> LogoImageUpload(IFormFile logoUrl, string fileName);
        public Task<string> FileUpload(IFormFile file, string fileName);
    }
}
