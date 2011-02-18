using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dev.Mvc.Helpers;

namespace Shop.Controllers
{
    public class GraphicsController : Controller
    {
        //
        // GET: /Graphics/
        [OutputCache(NoStore=true, Duration=1, VaryByParam="*")]
        public void ShowMain(string id, string alt)
        {
            Response.Write(GraphicsHelper.CachedImage(null, "~/Content/ProductImages", id, "mainView", alt));
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public void ShowCatalogueMain(string id, string alt, int brandId, int groupId)
        {
            string path = string.Format("~/Content/CatalogueImages/Brand{0}Group{1}", brandId, groupId);
            string format = "<a class=\"fancy\" href=\"{0}\"><img src=\"{1}\" alt=\"\"/></a>";
            string imagePath = GraphicsHelper.GetCachedImage(path, id, "catalogueMain");
            Response.Write(string.Format(format, imagePath, imagePath));
        }
    }
}
