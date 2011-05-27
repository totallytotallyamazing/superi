using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class EugeneController : Controller
    {
        //
        // GET: /Eugene/

        public ActionResult Index()
        {
            Text text = Helpers.Helpers.GetContent("Eugene");
            ViewData["keywords"] = text.Keywords;
            ViewData["description"] = text.Description;
            return View(text);
        }

    }
}
