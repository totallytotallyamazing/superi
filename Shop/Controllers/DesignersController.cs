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
                /*
                Designer designer = context.Designer.Include("DesignerContent").First(d => d.Url == id);
                foreach (var item in designer.DesignerContent)
                {
                    //item.DesignerRoomReference.Load();
                }
                return View(designer);*/

                Designer designer = context.Designer.Where(d => d.Url == id).First();

                ViewData["designer"] = designer;

                var dcList = context.DesignerContent.Include("Designer").Include("DesignerRoom").Include("DesignerContentImages").Where(d => d.Designer.Url == id).ToList();
                return View(dcList);
            }
        }

        
    }
}
