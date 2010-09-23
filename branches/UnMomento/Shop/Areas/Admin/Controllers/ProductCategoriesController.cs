using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Collections;
using Dev.Helpers;

namespace Shop.Areas.Admin.Controllers
{
    public class ProductCategoriesController : Controller
    {
        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Index(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                context.Categories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                IEnumerable categories = context.Categories.ToList();
                int[] productCategoriesSelected = context.Products.Where(p => p.Id == id).SelectMany(p => p.Categories).Select(c => c.Id).ToArray();
                ViewData["productCategoriesSelected"] = productCategoriesSelected;
                ViewData["ProductId"] = id;
                return View(categories);
            }
        }

        [HttpPost]
        public void Index(int id, FormCollection form)
        {
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products.Include("Categories").Where(p => p.Id == id).First();

                PostData postData = form.ProcessPostData("id");
                int[] items = (from item in postData where item.Value["category"] == "true" select int.Parse(item.Key)).ToArray();
                int[] itemsToRemove = (from item in postData where item.Value["category"] == "false" select int.Parse(item.Key)).ToArray();
                foreach (int categoryId in items)
                {
                    Category val = new Category();
                    if (product.Categories.Where(t => t.Id == categoryId).Count() == 0)
                    {
                        val.Id = categoryId;
                        val.EntityKey = new System.Data.EntityKey("ShopStorage.Categories", "Id", categoryId);
                        context.Attach(val);
                        product.Categories.Add(val);
                    }
                }

                foreach (int categoryId in itemsToRemove)
                {
                    Category val = product.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

                    if (val != null)
                        product.Categories.Remove(val);
                }
                context.SaveChanges();
            }
            Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close();</script>");
        }
    }
}
