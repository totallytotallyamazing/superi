using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MBrand.Helpers
{
    public static class GraphicsHelper
    {
        private static readonly Dictionary<string, int> LimitHeight = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> LimitWidth = new Dictionary<string, int>();

        static GraphicsHelper()
        {
            LimitWidth.Add("secret", 180);
            LimitHeight.Add("secret", 180);
        }


        private static Rectangle CalculateDestRect(string name, Size sourceImage)
        {
            int previewHeight = LimitHeight[name];
            int previewWidth = LimitWidth[name];

            int resultWidth;
            int resultHeight;

            double coef = (double)sourceImage.Width / (double)previewWidth;

            resultHeight = (int)Math.Truncate(sourceImage.Height / coef);

            resultWidth = previewWidth;

            return new Rectangle(0, 0, resultWidth, resultHeight);
        }

        private static Rectangle CalculateSourceRect(string name, Size sourceImage)
        {
            return new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
        }

        public static void ScaleImage(string name, Bitmap sourceImage, int limitWidth, int limitHeight, Stream saveTo)
        {
            Rectangle sourceRect = CalculateSourceRect(name, sourceImage.Size);

            Rectangle destRect = CalculateDestRect(name, sourceImage.Size);

            Bitmap thumbnailImage = new Bitmap(destRect.Width, destRect.Height);
            Graphics graphics = Graphics.FromImage(thumbnailImage);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(sourceImage, destRect, sourceRect, GraphicsUnit.Pixel);


            thumbnailImage.Save(saveTo, System.Drawing.Imaging.ImageFormat.Jpeg);
            saveTo.Position = 0;
        }

        public static string GetCachedImage(string originalPath, string fileName, string cacheFolder)
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
            string result = Path.Combine("/Content/images/" + cacheFolder + "/preview/", fileName);
            string cachePath = HttpContext.Current.Server.MapPath("~/Content/images/" + cacheFolder + "/preview");

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
                    return GetCachedImage(originalPath, "nophoto.gif", cacheFolder);
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

            string cachePath = HttpContext.Current.Server.MapPath("~/Content/images/" + cacheFolder + "/preview");
            string cachedImagePath = Path.Combine(cachePath, fileName);

            using (FileStream stream = new FileStream(cachedImagePath, FileMode.CreateNew))
            {
                ScaleImage(cacheFolder, image, LimitWidth[cacheFolder], LimitHeight[cacheFolder], stream);
            }
        }

        public static string CachedImage(this HtmlHelper helper, string originalPath, string fileName, string cacheFolder, string alt)
        {
            StringBuilder sb = new StringBuilder();
            string formatString = "<img src=\"{0}\" alt=\"{1}\" />";

            sb.AppendFormat(formatString, GetCachedImage(originalPath, fileName, cacheFolder), alt);

            return sb.ToString();
        }

        public static void SaveCachedImage(string originalPath, string fileName, string cacheFolder)
        {
            CacheImage(originalPath, fileName, cacheFolder);
        }


    }
}