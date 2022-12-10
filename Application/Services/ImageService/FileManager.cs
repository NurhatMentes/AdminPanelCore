using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Application.Services.ImageService
{
    public class FileManager:IFileService
    {
        string[] allowedTypes = { "image/jpeg", "image/jpg", "image/png" };

        public async Task<string> ImageUpload(IFormFile imgUrl, string fileName)
        {
            if (imgUrl.Length > 16000000)
            {
                if (allowedTypes.Contains(imgUrl.ContentType))
                {
                    //  resmin dosya yolunu belirtin
                    string jpegFilePath = Path.GetTempFileName();

                    using (var stream = File.Create(jpegFilePath))
                    {
                        await imgUrl.CopyToAsync(stream);
                    }

                    Directory.CreateDirectory("wwwroot\\Uploads\\" + fileName);

                    // webp resminin kaydedileceği dosya yolunu belirtin
                    string webpFilePath = "wwwroot\\Uploads\\" + fileName + "\\" + imgUrl.FileName.Split(".")[0] + ".webp";



                    // jpeg resmini ImageSharp kütüphanesi ile yükleyin
                    using (Image<Rgba32> image = Image.Load<Rgba32>(jpegFilePath))
                    {
                        image.Mutate(x => x.Resize(1920, 1080));
                        // resmi webp formatına kaydedin
                        image.Save(webpFilePath, new WebpEncoder());
                    }

                    return "";
                }

                throw new BusinessException("Hatalı resim formatı ile yükleme yapmaya çalıştınız. jpeg, jpg ve png formatlarıyla yükleme yapabilirsiniz.");
            }
            throw new BusinessException("Maksimum 16 mb boyutunda yükleme yapabilirsiniz.");
        }

        public async Task<string> LogoImageUpload(IFormFile logoUrl, string fileName)
        {
            string jpegFilePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(jpegFilePath))
            {
                await logoUrl.CopyToAsync(stream);
            }

            Directory.CreateDirectory("wwwroot\\Uploads\\" + fileName);

            string webpFilePath = "wwwroot\\Uploads\\" + fileName + "\\" + logoUrl.FileName.Split(".")[0] + ".webp";



            using (Image<Rgba32> image = Image.Load<Rgba32>(jpegFilePath))
            {
                image.Mutate(x => x.Resize(50, 50));
                image.Save(webpFilePath, new SixLabors.ImageSharp.Formats.Webp.WebpEncoder());
            }

            return "";
        }
    }
}
