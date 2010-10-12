using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class BrandsController : Controller
    {
        public ActionResult Index()
        {
            using (ShopStorage context = new ShopStorage())
            {
                return View(context.Brands.ToList()); 
            }
        }

    }
}
