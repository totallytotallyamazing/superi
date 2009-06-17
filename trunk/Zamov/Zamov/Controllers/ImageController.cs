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

    }
}
