using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Dev.Mvc.Helpers;

namespace MBrand.Controllers
{
    public class GraphicsController : Controller
    {
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public void ShowMain(string id, string alt)
        {
         //   Response.Write(GraphicsHelper.CachedImage(null, "~/Content/ProductImages", id, "mainView", alt));
        }
    }
}
