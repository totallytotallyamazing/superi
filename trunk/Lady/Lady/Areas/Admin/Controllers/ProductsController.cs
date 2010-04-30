using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Models;

namespace Lady.Areas.Admin.Controllers
{
    [Authorize(Roles="Administrators")]
    public class ProductsController : Controller
    {
        //
        // GET: /Admin/Products/

        public ActionResult Index(int categoryId, int? brandId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                List<Product> products = context.Products.Where(p => p.Category.Id == categoryId)
                    .Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value)).ToList();
                return View(products); 
            }
        }

        public ActionResult AddEdit(int? id)
        {

            return View();
        }
    }
}
