using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class ProductTagsController : Controller
    {
        public ActionResult Index(int id)
        {
            using (ShopStorage context  = new ShopStorage())
            {
                List<Tag> tags = context.Tags.ToList();
                int[] productTagsSelected = context.Products.Where(p => p.Id == id).SelectMany(p => p.Tags).Select(t => t.Id).ToArray();
                ViewData["productTagsSelected"] = productTagsSelected;
                ViewData["ProductId"] = id;
                return View(tags); 
            }
        }

        [HttpPost]
        public void Index(int id, FormCollection form)
        {
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products.Include("Tags").Where(p => p.Id == id).First();

                product.ProductAttributeValues.Clear();

                PostData postData = form.ProcessPostData("productId", "categoryId");
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
            Response.Write("<script type=\"text/javascript\">windoq.top.$fancybox.close();</script>");
        }
    }
}
