using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;
using MBrand.Models.ViewModel;

namespace MBrand.Controllers
{
    public class SecretController : Controller
    {
        //
        // GET: /Secret/

        public ActionResult Index()
        {
            var text = Helpers.Helpers.GetContent("Secret");
            ViewData["keywords"] = text.Keywords;
            ViewData["description"] = text.Description;

            IEnumerable<MBrand.Models2.SecretImages> images = Helpers.Helpers.GetSecretImages();

            SecretPresentation sp = new SecretPresentation {SecretText = text, Imageses = images};

            return View(sp);
        }

    }
}
