using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class ValidationController : Controller
    {
        //
        // GET: /Validation/

        public ActionResult IsNameAvailable(string name)
        {
            using (var context = new ContentContainer())
            {
                bool result = context.Contents.Any(c => c.Name == name);
                return Json(result ? (object) "Страница с таким именем уже существует" : true
                    , JsonRequestBehavior.AllowGet);
            }
        }

    }
}
