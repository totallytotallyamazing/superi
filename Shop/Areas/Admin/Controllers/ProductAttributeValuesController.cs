using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ProductAttributeValuesController : Controller
    {
        public ActionResult Index(int id, int productId)
        {
            ViewData["productId"] = productId;
            ViewData["categoryId"] = id;

            using (ShopStorage context = new ShopStorage())
            {
                List<ProductAttribute> values = context.Categories.Include("ProductAttributeValues")
                    .Where(c => c.Id == id).SelectMany(c => c.ProductAttributes).ToList();
                
                foreach (var item in values)
                    item.ProductAttributeValue.Load();

                Product product = context.Products.Include("ProductAttributeValues").Where(p => p.Id == productId).First();

                int[] attributesSelected = product.ProductAttributeValues.Select(pav => pav.Id).ToArray();
                ViewData["attributesSelected"] = attributesSelected;
                
                return View(values);
            }
        }

        [HttpPost]
        public void Index(FormCollection form, int productId, int categoryId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products.Include("ProductAttributeValues").Where(p => p.Id == productId).First();

                product.ProductAttributeValues.Clear();

                PostData postData = form.ProcessPostData("productId", "categoryId");
                int[] items = (from item in postData where item.Value["attr"] == "true" select int.Parse(item.Key)).ToArray();
                foreach (int id in items)
                {
                    ProductAttributeValue val = new ProductAttributeValue();
                    
                    if (product.ProductAttributeValues.Where(pv => pv.Id == id).Count() == 0)
                    {
                        val.Id = id;
                        val.EntityKey = new System.Data.EntityKey("ShopStorage.ProductAttributeValues", "Id", id);
                        context.Attach(val);
                        product.ProductAttributeValues.Add(val);
                    }
                }
                context.SaveChanges();
                Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close()</script>");
            }
        }
    }
}
