using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Shop.Helpers
{
    public static class MyGraphicsHelper
    {

        public enum FixedDimension { Width, Height }

        //private static Dictionary<string, int> maxDimensions = new Dictionary<string, int>();
        //private static Dictionary<string, FixedDimension> fixDimension = new Dictionary<string, FixedDimension>();
        private static Dictionary<string, int> limitHeight = new Dictionary<string, int>();
        private static Dictionary<string, int> limitWidth = new Dictionary<string, int>();

        static MyGraphicsHelper()
        {
            //maxDimensions.Add("thumbnail", 360);
            //fixDimension.Add("thumbnail", FixedDimension.Width);
            limitHeight.Add("reviewImagesThumb", 175);
            limitWidth.Add("reviewImagesThumb", 175);

            limitHeight.Add("reviewImagesDetailsThumb", 150);
            limitWidth.Add("reviewImagesDetailsThumb", 215);
        }

        private static Rectangle CalculateDestRect(int limWidth, int limHeight, Size imageSize)
        {
            return imageSize.Width< imageSize.Height ? new Rectangle(0, 0, limHeight, limWidth) : new Rectangle(0, 0, limWidth, limHeight);
        }

        private static Rectangle CalculateSourceRect(string name, Size sourceImage)
        {
            int previewHeight;
            int previewWidth;

            if (sourceImage.Width > sourceImage.Height)
            {
                previewHeight = limitHeight.ContainsKey(name) ? limitHeight[name] : 0;
                previewWidth = limitWidth.ContainsKey(name) ? limitWidth[name] : 0;
            }
            else
            {
                previewWidth = limitHeight.ContainsKey(name) ? limitHeight[name] : 0;
                previewHeight = limitWidth.ContainsKey(name) ? limitWidth[name] : 0;
            }

            int resultWidth;
            int resultHeight;

            double wRatio = (double)sourceImage.Width / (double)previewWidth;
            double hRatio = (double)sourceImage.Height / (double)previewHeight;

            double coef = (double)previewHeight / (double)previewWidth;

            if (wRatio < hRatio)
            {
                resultWidth = sourceImage.Width;
                resultHeight = (int)Math.Truncate(sourceImage.Width * coef);
            }
            else
            {
                resultHeight = sourceImage.Height;
                resultWidth = (int)Math.Truncate(sourceImage.Height / coef);
            }

            return new Rectangle(0, 0, resultWidth, resultHeight);
        }

        public static void ScaleImage(string name, Bitmap image, int limWidth, int limHeight, Stream saveTo)
        {
            Rectangle sourceRect = CalculateSourceRect(name, image.Size);

            Rectangle destRect = CalculateDestRect(limWidth, limHeight, image.Size);

            Bitmap thumbnailImage = new Bitmap(destRect.Width, destRect.Height);
            Graphics graphics = Graphics.FromImage(thumbnailImage);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, destRect, sourceRect, GraphicsUnit.Pixel);


            ////
            //Watermark watermark = new Watermark();
            //string waterMarkText = "© Клафс Украина | www.klafs.in.ua";
            //watermark.WaterMarkToImage(thumbnailImage, waterMarkText);
            ////
            thumbnailImage.Save(saveTo, System.Drawing.Imaging.ImageFormat.Jpeg);
            saveTo.Position = 0;
        }

        public static string GetCachedImage(string originalPath, string fileName, string cacheFolder, bool forDesigners = false)
        {
            if (string.IsNullOrEmpty(fileName) ||
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
                    CacheImage(originalPath, fileName, cacheFolder, forDesigners);
                }
                catch
                {
                    return GetCachedImage(originalPath, "tripsWebMvcNoCarImage.jpg", cacheFolder);
                }
                return result;
            }
        }

        private static void CacheImage(string originalPath, string fileName, string cacheFolder, bool forDesigners)
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
                ScaleImage(cacheFolder, image, limitWidth[cacheFolder], limitHeight[cacheFolder], stream);
            }
        }

        public static string CachedImage(this HtmlHelper helper, string originalPath, string fileName, string cacheFolder, string alt, bool forDesigners = false)
        {
            StringBuilder sb = new StringBuilder();
            string formatString = "<img src=\"{0}\" alt=\"{1}\" />";

            sb.AppendFormat(formatString, GetCachedImage(originalPath, fileName, cacheFolder, forDesigners), alt);

            return sb.ToString();
        }

    }
}