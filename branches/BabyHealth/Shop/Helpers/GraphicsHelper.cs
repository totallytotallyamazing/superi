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

        static GraphicsHelper()
        {
            maxDimensions.Add("mainView", 358);
            fixDimension.Add("mainView", FixedDimension.Width);
            maxDimensions.Add("thumbnail1", 79);
            fixDimension.Add("thumbnail1", FixedDimension.Width);
            maxDimensions.Add("thumbnail2", 152);
            fixDimension.Add("thumbnail2", FixedDimension.Width);
            maxDimensions.Add("thumbnail3", 85);
            fixDimension.Add("thumbnail3", FixedDimension.Width);
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

        public static void ScaleImage(Bitmap image, FixedDimension? fixedDimension, int maxDimension, Stream saveTo)
        {
            Size imageSize = CalculateSize(image.Size, fixedDimension, maxDimension);

            Bitmap thumbnailImage = new Bitmap(imageSize.Width, imageSize.Height);
            Graphics graphics = Graphics.FromImage(thumbnailImage);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, 0, 0, thumbnailImage.Width, thumbnailImage.Height);
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
                ScaleImage(image, fixedDimension, maxDimensions[cacheFolder], stream);
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