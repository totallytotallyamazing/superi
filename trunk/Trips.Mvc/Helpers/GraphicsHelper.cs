using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace Trips.Mvc.Helpers
{
    public static class GraphicsHelper
    {
        public static MemoryStream ScaleImage(Bitmap image, int maxDimension)
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
            MemoryStream imageStream = new MemoryStream();
            thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            imageStream.Position = 0;
            return imageStream;
        }
    }
}
