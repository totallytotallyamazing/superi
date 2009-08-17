using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Data;
using Zamov.Helpers;

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
            if (!string.IsNullOrEmpty(searchContext))
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    ObjectQuery<Product> productsQuery = new ObjectQuery<Product>(
                        "SELECT VALUE P FROM Products AS P WHERE P.Name LIKE '%" + searchContext + "%'", context);
                    List<Product> products = productsQuery.ToList();
                    products.ForEach(p => p.DealerReference.Load());
                    return View(products);

                    /*
                    List<Product> products =
                        (from product in context.Products.Include("Dealer")
                         where product.Name == searchContext 
                         && product.Enabled
                         && !product.Deleted
                         select product).ToList();
                    return View(products);
                    */
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddToCart(FormCollection items)
        {
            Cart cart = SystemSettings.Cart;
            Dictionary<string, Dictionary<string, string>> orderItems = items.ProcessPostData("dealerId", "groupId");
            if (orderItems.Count > 0)
            {

            }

            return RedirectToAction("SearchProduct");
        }


    }
}
