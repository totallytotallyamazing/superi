using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class DesignersController : Controller
    {
        //
        // GET: /Designers/

        public ActionResult Index(string id)
        {
            using (var context = new DesignerStorage())
            {
                Designer designer = context.Designer.Include("DesignerContent").First(d => d.Url == id);
                return View(designer);
            }
        }


        public ActionResult ViewLiving(string id, string appartaments)
        {
            using (var context = new DesignerStorage())
            {
                Designer designer = context.Designer.Include("DesignerContent").First(d => d.Url == id);
                return View("Details", designer);
            }
        }

        public ActionResult ViewNotLiving(string id, string appartaments)
        {
            using (var context = new DesignerStorage())
            {
                Designer designer = context.Designer.Include("DesignerContent").First(d => d.Url == id);
                return View("Details", designer);
            }
        }
    }
}
