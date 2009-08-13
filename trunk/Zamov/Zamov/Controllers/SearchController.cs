using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SearchProduct(string searchContext)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Product> products =
                    (from product in context.Products.Include("Dealer")
                     where product.Name == searchContext 
                     && product.Enabled
                     && !product.Deleted
                     select product).ToList();
                return View(products);
            }

        }


    }
}
