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
        public ActionResult Index(int? id)
        {
            using (DataStorage context = new DataStorage())
            {
                List<Gallery> galleries = context.Galleries.Include("Images").Where(g => !id.HasValue || g.Id == id.Value).Select(g => g).OrderByDescending(g => g.Id).ToList();
                long[] galleryIds = galleries.OrderByDescending(g => g.Id).Select(g => g.Id).ToArray();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ViewData["serializedGalleriesId"] = serializer.Serialize(galleryIds);
                return View(galleries);
            }

        }

    }
}
