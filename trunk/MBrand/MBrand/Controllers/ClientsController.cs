using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class ClientsController : Controller
    {
        //
        // GET: /Clients/

        public ActionResult Index()
        {
            var text = Helpers.Helpers.GetContent("Clients");
            ViewData["keywords"] = text.Keywords;
            ViewData["description"] = text.Description;
            return View(text);
        }

    }
}
