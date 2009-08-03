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
                ViewData["dealerId"] = dealerId;
                ViewData["groupId"] = groupId;
                List<Product> products = (from product in context.Products where (groupId == null) || product.Group.Id == groupId select product).ToList();
                return View(products);
            }
        }

        public ActionResult Description(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                bool hasImage = context.ProductImages.Where(pi => pi.Product.Id == id).Count() > 0;
                ViewData["hasImage"] = hasImage;
                if (hasImage)
                {
                    ViewData["imageId"] = context.ProductImages.Where(pi => pi.Product.Id == id).Select(pi => pi.Id).First();
                }
                Product product = context.Products.Select(p => p).Where(p => p.Id == id).First();
                return View(product);
            }
        }

    }
}
