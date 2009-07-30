using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index(int dealerId, int? groupId)
        {
            using (ZamovStorage context =new ZamovStorage())
            {
                List<Group> groups = (from g in context.Groups.Include("Groups") where g.Dealer.Id == dealerId select g).ToList();
                ViewData["groups"] = groups;
                List<Product> products = (from product in context.Products where (groupId == null) || product.Group.Id == groupId select product).ToList();
                return View(products);
            }
        }

    }
}
