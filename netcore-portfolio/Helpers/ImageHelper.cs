using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;

namespace netcore_portfolio.Helpers
{
    public static class ImageHelper
    {
        public static void SaveImageAsWebP(IFormFile imageFile, string filePath, int quality = 75, int width = 0, int height = 0)
        {
            // Dosya adı ve uzantısını al
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);

            // Görüntüyü belleğe yükle
            using (var image = System.Drawing.Image.FromStream(imageFile.OpenReadStream()))
            {
                // Boyut ayarlama
                if (width > 0 || height > 0)
                {
                    // Yeni boyutları hesapla
                    int newWidth = width > 0 ? width : image.Width * height / image.Height;
                    int newHeight = height > 0 ? height : image.Height * width / image.Width;

                    // Yeni boyutlu görüntü oluştur
                    using (var resizedImage = new Bitmap(newWidth, newHeight))
                    {
                        // Görüntüyü yeniden boyutlandır
                        using (var graphics = Graphics.FromImage(resizedImage))
                        {
                            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                            graphics.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));
                        }

                        // Yeni boyutlu görüntüyü kaydet
                        SaveWebPImage(resizedImage, filePath, quality);
                    }
                }
                else
                {
                    // Görüntüyü WebP formatına dönüştür ve kaydet
                    SaveWebPImage(image, filePath, quality);
                }
            }
        }

        private static void SaveWebPImage(System.Drawing.Image image, string filePath, int quality)
        {
            // WebP codec'ini yükle
            ImageCodecInfo webpCodecInfo = null;
            foreach (var codec in ImageCodecInfo.GetImageEncoders())
            {
                if (codec.MimeType == "image/webp")
                {
                    webpCodecInfo = codec;
                    break;
                }
            }

            // WebP codec'i bulunamadıysa hata ver
            if (webpCodecInfo == null)
            {
                throw new InvalidOperationException("WebP codec not found.");
            }

            // WebP formatında kaydet
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);

            image.Save(filePath, webpCodecInfo, encoderParameters);
        }
    }
}
