using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.Mvc;
using System.Text;

namespace Dev.Mvc.Helpers
{
    public static class GraphicsHelper
    {
        public enum FixedDimension { Width, Height }

        private static Dictionary<string, int> maxDimensions = new Dictionary<string, int>();
        private static Dictionary<string, FixedDimension> fixDimension = new Dictionary<string, FixedDimension>();
        private static Dictionary<string, int> limitHeight = new Dictionary<string, int>();
        private static Dictionary<string, int> limitWidth = new Dictionary<string, int>();

        static GraphicsHelper()
        {
            maxDimensions.Add("mainView", 296);
            fixDimension.Add("mainView", FixedDimension.Width);
            maxDimensions.Add("thumbnail1", 82);
            fixDimension.Add("thumbnail1", FixedDimension.Width);
            limitHeight.Add("thumbnail1", 180);
            maxDimensions.Add("thumbnail2", 152);
            fixDimension.Add("thumbnail2", FixedDimension.Width);
            limitHeight.Add("thumbnail2", 195);
            maxDimensions.Add("thumbnail3", 85);
            fixDimension.Add("thumbnail3", FixedDimension.Width);
            maxDimensions.Add("cartThumb", 60);
            fixDimension.Add("cartThumb", FixedDimension.Width);
            maxDimensions.Add("dayDiscount", 76);
            fixDimension.Add("dayDiscount", FixedDimension.Width);
            limitHeight.Add("dayDiscount", 97);
        }

        private static Rectangle CalculateSourceRect(string name, Size image, Size calulatedSize)
        {
            int height = limitHeight.ContainsKey(name) ? limitHeight[name] : 0;
            int width = limitWidth.ContainsKey(name) ? limitWidth[name] : 0;
            if (height + width > 0)
            {
                int sourceHeight = image.Height;
                int sourceWidth = image.Width;
                if (height > 0 && calulatedSize.Height > height)
                {
                    double coef = (double)height / (double)calulatedSize.Height;
                    sourceHeight = (int)Math.Truncate(image.Height * coef);
                }
                if (width > 0 && calulatedSize.Width > width)
                {
                    double coef = (double)width / (double)calulatedSize.Width;
                    sourceWidth = (int)Math.Truncate(image.Width * coef);
                }
                return new Rectangle(0, 0, sourceWidth, sourceHeight);
            }
            else
                return new Rectangle(0, 0, image.Width, image.Height);
        }

        private static Rectangle CalculateDestRect(string name, Size image, Size calulatedSize)
        { 
            int height = limitHeight.ContainsKey(name) ? limitHeight[name] : 0;
            int width = limitWidth.ContainsKey(name) ? limitWidth[name] : 0;

            if (height + width > 0)
            {
                int destHeight = calulatedSize.Height;
                int destWidth = calulatedSize.Width;
                if (height > 0 && calulatedSize.Height > height)
                    destHeight = height;
                if (width > 0 && calulatedSize.Width > width)
                    destWidth = width;
                return new Rectangle(0, 0, destWidth, destHeight);
            }
            else
                return new Rectangle(0, 0, calulatedSize.Width, calulatedSize.Height);
        }

        private static Size CalculateSize(Size image, FixedDimension? fixedDimension, int maxDimension)
        {
            int width;
            int height;
            if ((fixedDimension.HasValue && fixedDimension.Value == FixedDimension.Width) || (image.Width > image.Height))
            {
                width = maxDimension;
                height = (maxDimension * image.Height) / image.Width;

            }
            else if ((fixedDimension.HasValue && fixedDimension.Value == FixedDimension.Height) || (image.Height > image.Width))
            {
                height = maxDimension;
                width = (maxDimension * image.Width) / image.Height;
            }
            else
                width = height = maxDimension;

            return new Size(width, height);
        }

        public static void ScaleImage(string name, Bitmap image, FixedDimension? fixedDimension, int maxDimension, Stream saveTo)
        {
            Size imageSize = CalculateSize(image.Size, fixedDimension, maxDimension);
            Rectangle sourceRect = CalculateSourceRect(name, image.Size, imageSize);
            Rectangle destRect = CalculateDestRect(name, image.Size, imageSize);

            Bitmap thumbnailImage = new Bitmap(destRect.Width, destRect.Height);
            Graphics graphics = Graphics.FromImage(thumbnailImage);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, destRect, sourceRect, GraphicsUnit.Pixel);
            thumbnailImage.Save(saveTo, System.Drawing.Imaging.ImageFormat.Jpeg);
            saveTo.Position = 0;
        }

        public static string GetCachedImage(string originalPath, string fileName, string cacheFolder)
        {
            if(string.IsNullOrEmpty(fileName) ||
                !File.Exists(Path.Combine(HttpContext.Current.Server.MapPath(originalPath), fileName)))
            {
                fileName = "tripsWebMvcNoCarImage.jpg";
                if (!File.Exists(Path.Combine(HttpContext.Current.Server.MapPath(originalPath), fileName)))
                {
                    return null;
                }
            }
            string result = Path.Combine("/ImageCache/" + cacheFolder + "/", fileName);
            string cachePath = HttpContext.Current.Server.MapPath("~/ImageCache/" + cacheFolder);
            
            if (!Directory.Exists(cachePath)) Directory.CreateDirectory(cachePath);

            string cachedImagePath = Path.Combine(cachePath, fileName);
            if (File.Exists(cachedImagePath))
            {
                return result;
            }
            else
            {
                try
                {
                    CacheImage(originalPath, fileName, cacheFolder);
                }
                catch
                {
                    return GetCachedImage(originalPath, "tripsWebMvcNoCarImage.jpg", cacheFolder);
                }
                return result;
            }
        }

        private static void CacheImage(string originalPath, string fileName, string cacheFolder)
        {
            string sourcePath = Path.Combine(HttpContext.Current.Server.MapPath(originalPath), fileName);
            Bitmap image;
            using (FileStream stream = new FileStream(sourcePath, FileMode.Open))
            {
                image = new Bitmap(stream);
            }

            string cachePath = HttpContext.Current.Server.MapPath("~/ImageCache/" + cacheFolder);
            string cachedImagePath = Path.Combine(cachePath, fileName);

            using (FileStream stream = new FileStream(cachedImagePath, FileMode.CreateNew))
            {
                FixedDimension? fixedDimension = null;
                if (fixDimension.ContainsKey(cacheFolder))
                    fixedDimension = fixDimension[cacheFolder];
                ScaleImage(cacheFolder, image, fixedDimension, maxDimensions[cacheFolder], stream);
            }
        }

        public static string CachedImage(this HtmlHelper helper, string originalPath, string fileName, string cacheFolder, string alt)
        {
            StringBuilder sb = new StringBuilder();
            string formatString = "<img src=\"{0}\" alt=\"{1}\" />";

            sb.AppendFormat(formatString, GetCachedImage(originalPath, fileName, cacheFolder), alt);

            return sb.ToString();
        }
    }
}