using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace Zamov.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/

        public void ShowLogo(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer dealer = context.Dealers.Select(d => d).Where(d => d.Id == id).First();
                Response.ContentType = dealer.LogoType;
                MemoryStream stream = new MemoryStream(dealer.LogoImage);
                Bitmap image = new Bitmap(stream);
                int width = image.Width;
                int height = image.Height;
                if (width > 200)
                {
                    width = 200;
                    height = (200 * image.Height) / image.Width;
                }
                if (height > 100)
                {
                    width = (100 * width) / height;
                    height = 100;
                }
                Bitmap thumbnailImage = new Bitmap(width, height);
                Graphics graphics = Graphics.FromImage(thumbnailImage);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, width, height);
                MemoryStream imageStream = new MemoryStream();
                thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageContent = new Byte[imageStream.Length];
                imageStream.Position = 0;
                imageStream.Read(imageContent, 0, (int)imageStream.Length);
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(imageContent);
            }
        }

        public void ShowImage(string imageType, byte[] image)
        {
            Response.ContentType = imageType;
            Response.BinaryWrite(image); 
        }

        public void ProductImage(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                ProductImage image = context.ProductImages.Select(pi => pi).Where(pi => pi.Id == id).First();
                Response.ContentType = image.ImageType;
                Response.BinaryWrite(image.Image);
            }
        }

        public void CategoryImage(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                CategoryImage image = context.CategoryImages.Select(ci => ci).Where(ci => ci.Id == id).First();
                Response.ContentType = image.ImageType;
                Response.BinaryWrite(image.Image);
            }
        }

        public void CategoryImageByCategoryId(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                CategoryImage image = context.CategoryImages.Select(ci => ci).Where(ci => ci.Category.Id == id).First();
                Response.ContentType = image.ImageType;
                Response.BinaryWrite(image.Image);
            }        
        }

    }
}
