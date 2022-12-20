using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Application.Services.FileService
{
    public class FileManager:IFileService
    {
        private readonly IHostingEnvironment _hostingEnv;

        public FileManager(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }

        string[] allowedTypes = { "image/jpeg", "image/jpg", "image/png" };

        public async Task<string> ImageUpload(IFormFile imgUrl, string fileName)
        {
            if (imgUrl.Length < 16000000)
            {
                if (allowedTypes.Contains(imgUrl.ContentType))
                {
                    // resmin dosya yolunu belirtin
                    string FilePath = Path.GetTempFileName();

                    using (var stream = File.Create(FilePath))
                    {
                        await imgUrl.CopyToAsync(stream);
                    }

                    Directory.CreateDirectory("wwwroot\\Uploads\\" + fileName);

                    // webp resminin kaydedileceği dosya yolunu belirtin
                    string webpFilePath = "wwwroot\\Uploads\\" + fileName + "\\" + imgUrl.FileName.Split(".")[0] + ".webp";



                    // jpeg resmini ImageSharp kütüphanesi ile yükleyin
                    using (Image<Rgba32> image = Image.Load<Rgba32>(FilePath))
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

        public async Task<string> FileUpload(IFormFile file, string fileName)
        {

            if (file.ContentType != "application/pdf")
            {
                throw new Exception("Geçersiz dosya türü. PDF dosyası yükleyiniz");
            }

            if (Path.GetExtension(file.FileName) != ".pdf")
            {
                throw new InvalidOperationException("Geçersiz dosya uzantısı. Lütfen sadece pdf dosyaları yükleyin.");
            }

            //dosya adını uzantısız şekilde alır
            //var pdfName = Path.GetFileName(file.FileName);

            //dosya konumu bulunmuyorsa dosya konumu oluşturur
            Directory.CreateDirectory("wwwroot\\Pdfs\\" + fileName);

            // Dosya yolunu belirle
            var filePath = Path.Combine("wwwroot\\Pdfs\\" + fileName + "\\" + file.FileName.Split(".")[0] + ".pdf");

            //var filePath = Path.Combine(_hostingEnv.WebRootPath,"Pdfs\\"+fileName, pdfName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            // Dosyayı yükle
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            
            return "";
        }

        public async Task<string> VideoUpload(IFormFile file, string fileName)
        {
            if (file.ContentType != "video/mp4")
            {
                throw new Exception("Geçersiz dosya türü. mp4 dosyası yükleyiniz");
            }

            if (Path.GetExtension(file.FileName) != ".mp4")
            {
                throw new InvalidOperationException("Geçersiz dosya uzantısı. Lütfen sadece mp4 formatında video yükleyin.");
            }


            //dosya konumu bulunmuyorsa dosya konumu oluşturur
            Directory.CreateDirectory("wwwroot\\Videos\\" + fileName);

            // Dosya yolunu belirle
            var filePath = Path.Combine("wwwroot\\Videos\\" + fileName + "\\" + file.FileName.Split(".")[0] + ".mp4");

            //var filePath = Path.Combine(_hostingEnv.WebRootPath,"Pdfs\\"+fileName, pdfName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Dosyayı yükle
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }


            return "";
        }
    }
}
