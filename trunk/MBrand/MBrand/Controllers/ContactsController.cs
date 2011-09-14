using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class ContactsController : Controller
    {
        //
        // GET: /Contacts/

        public ActionResult Index()
        {
            var text = Helpers.Helpers.GetContent("Contacts");
            ViewData["keywords"] = text.Keywords;
            ViewData["description"] = text.Description;
            return View(text);
        }

    }
}
