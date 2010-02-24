using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trips.Mvc.Models;

namespace Trips.Mvc.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEditBrand(int? id)
        {
            ViewData["id"] = id;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEditBrand(int? id, string name)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                Brand brand = null;
                if (id != null)
                {
                    brand = new Brand();
                    context.AddToBrands(brand);
                }
                brand.Name = name;
                context.SaveChanges();
            }
            return View();  
        }
    }
}
