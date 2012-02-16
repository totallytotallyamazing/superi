using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/
        readonly ContentContainer _context = new ContentContainer();

        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Get(string id)
        {
            var content = _context.Contents.OfType<TextContent>().FirstOrDefault(c => c.Name == id);

            return Content(content != null ? content.Text : string.Empty);
        }

    }
}
