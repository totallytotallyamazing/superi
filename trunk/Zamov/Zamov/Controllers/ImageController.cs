using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Zamov.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/

        public void Show(byte[] image, string imageType)
        {
            Response.ContentType = imageType;
            Response.BinaryWrite(image);
        }

    }
}
