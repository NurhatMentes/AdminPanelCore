using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Http;

namespace Application.Services.ImageService
{
    public interface IFileService
    {
        public Task<string> ImageUpload(IFormFile imgUrl, string fileName);
        public Task<string> LogoImageUpload(IFormFile logoUrl, string fileName);
    }
}
