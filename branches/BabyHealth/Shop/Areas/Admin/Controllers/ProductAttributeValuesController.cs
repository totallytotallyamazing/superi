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
            ViewData["cId"] = id;

            using (ShopStorage context = new ShopStorage())
            {
                List<ProductAttribute> values = context.Categories.Include("ProductAttributeValues")
                    .Where(c => c.Id == id).SelectMany(c => c.ProductAttributes).ToList();
                foreach (var item in values)
                    item.ProductAttributeValue.Load();
                return View(values);
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            using (ShopStorage context = new ShopStorage())
            {

                int productId = 0;
                int categotyId = 0;
                foreach (string key in form.Keys)
                {
                    if (key == "productId")
                    {
                        productId = Convert.ToInt32(form[key]);
                    }
                    if (key == "cId")
                    {
                        categotyId = Convert.ToInt32(form[key]);
                    }
                }


                Product product = context.Products.Include("ProductAttributeValues").Where(p => p.Id == productId).First();

                product.ProductAttributeValues.Clear();

                /*foreach (ProductAttributeValue value in product.ProductAttributeValues)
                {
                    product.ProductAttributeValues.Remove(value);
                }
                  */


                
                PostData postData = form.ProcessPostData("productId","cId");
                int[] items = (from item in postData where item.Value["attr"] == "true" select int.Parse(item.Key)).ToArray();
                foreach (int id in items)
                {
                    ProductAttributeValue val = context.ProductAttributeValues.Where(pav => pav.Id == id).First();
                    
                    if (product.ProductAttributeValues.Where(pv => pv.Id == val.Id).Count() == 0)
                    {
                        product.ProductAttributeValues.Add(val);
                    }
                }
                context.SaveChanges();
                return RedirectToAction("AddEdit", "Products", new { area = "Admin", id = productId, cId = categotyId });
            }
        }
    }
}
