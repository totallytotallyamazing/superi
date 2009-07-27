using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

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
                Response.BinaryWrite(dealer.LogoImage);
            }
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
                CategoryImage image = context.CategoryImages.Select(ci => ci).Where(ci => ci.Category.Id == id).First();
                Response.ContentType = image.ImageType;
                Response.BinaryWrite(image.Image);
            }
        }

    }
}
