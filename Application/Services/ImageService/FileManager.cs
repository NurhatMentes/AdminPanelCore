﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Http.Internal;
using SixLabors.ImageSharp.Processing;

namespace Application.Services.ImageService
{
    public class FileManager:IFileService
    {
        public async Task<string> ImageUpload(IFormFile imgUrl, string fileName)
        {
            // jpeg resminin dosya yolunu belirtin
            string jpegFilePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(jpegFilePath))
            {
                // The formFile is the method parameter which type is IFormFile
                // Saves the files to the local file system using a file name generated by the app.
                await imgUrl.CopyToAsync(stream);
            }

            Directory.CreateDirectory("wwwroot\\Uploads\\" + fileName);

            // webp resminin kaydedileceği dosya yolunu belirtin
            string webpFilePath = "wwwroot\\Uploads\\" + fileName+"\\" + imgUrl.FileName.Split(".")[0] + ".webp";

          

            // jpeg resmini ImageSharp kütüphanesi ile yükleyin
            using (Image<Rgba32> image = Image.Load<Rgba32>(jpegFilePath))
            {
                image.Mutate(x => x.Resize(1920, 1080));
                // resmi webp formatına kaydedin
                image.Save(webpFilePath, new SixLabors.ImageSharp.Formats.Webp.WebpEncoder());
            }

            return "";
        }
    }
}
