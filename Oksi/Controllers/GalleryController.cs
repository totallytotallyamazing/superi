using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Oksi.Models;
using System.Web.Script.Serialization;

namespace Oksi.Controllers
{
    public class GalleryController : Controller
    {
        public ActionResult Index()
        {
            using (DataStorage context = new DataStorage())
            {
                List<Gallery> galleries = context.Galleries.Include("Images").Select(g => g).ToList();
                long[] galleryIds = galleries.Select(g => g.Id).ToArray();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ViewData["serializedGalleriesId"] = serializer.Serialize(galleryIds);
                return View(galleries);
            }

        }

    }
}
