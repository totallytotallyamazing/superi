﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace Trips.Mvc.Helpers
{
    public static class GraphicsHelper
    {
        public static Dictionary<string, int> maxDimensions = new Dictionary<string, int>();

        static GraphicsHelper()
        {
            maxDimensions.Add("mainView", 400);
            maxDimensions.Add("thumbnail1", 150);
            maxDimensions.Add("thumbnail1", 90);
        }

        public static void ScaleImage(Bitmap image, int maxDimension, Stream saveTo)
        {
            int width;
            int height;
            if (image.Width > image.Height)
            {
                width = maxDimension;
                height = (maxDimension * image.Height) / image.Width;

            }
            else if (image.Height > image.Width)
            {
                height = maxDimension;
                width = (maxDimension * image.Width) / image.Height;
            }
            else
                width = height = maxDimension;


            Bitmap thumbnailImage = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(thumbnailImage);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, 0, 0, thumbnailImage.Width, thumbnailImage.Height);
            thumbnailImage.Save(saveTo, System.Drawing.Imaging.ImageFormat.Jpeg);
            saveTo.Position = 0;
        }

        public static string GetCachedImage(string originalPath, string fileName, string cacheFolder)
        {
            string result = Path.Combine("/ImageCache/" + cacheFolder, fileName);
            string cachePath = HttpContext.Current.Server.MapPath("~/ImageCache/" + cacheFolder);
            string cachedImagePath = Path.Combine(cachePath, fileName);
            if (File.Exists(cachePath))
            {
                return result;
            }
            else
            {
                CacheImage(originalPath, fileName, cacheFolder);
                return result;
            }
        }

        public static void CacheImage(string originalPath, string fileName, string cacheFolder)
        { 
            string sourcePath = Path.Combine(HttpContext.Current.Server.MapPath(originalPath), fileName);
            Bitmap image;
            using(FileStream stream = new FileStream(sourcePath, FileMode.Open))
            {
                image= new Bitmap(stream);
            } 
            
            string cachePath = HttpContext.Current.Server.MapPath("~/ImageCache/" + cacheFolder);
            string cachedImagePath = Path.Combine(cachePath, fileName);

            using (FileStream stream = new FileStream(cachedImagePath, FileMode.CreateNew))
            {
                ScaleImage(image, maxDimensions[cacheFolder], stream);
            }
        }
    }
}