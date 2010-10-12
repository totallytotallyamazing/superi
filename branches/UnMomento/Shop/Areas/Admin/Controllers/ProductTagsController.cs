using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Helpers;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ProductTagsController : Controller
    {
        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Index(int id)
        {
            using (ShopStorage context = new ShopStorage())
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

                PostData postData = form.ProcessPostData("id");
                int[] items = (from item in postData where item.Value["tag"] == "true" select int.Parse(item.Key)).ToArray();
                int[] itemsToRemove = (from item in postData where item.Value["tag"] == "false" select int.Parse(item.Key)).ToArray();
                foreach (int tagId in items)
                {
                    Tag val = new Tag();
                    if (product.Tags.Where(t => t.Id == tagId).Count() == 0)
                    {
                        val.Id = tagId;
                        val.EntityKey = new System.Data.EntityKey("ShopStorage.Tags", "Id", tagId);
                        context.Attach(val);
                        product.Tags.Add(val);
                    }
                }

                foreach (int tagId in itemsToRemove)
                {
                    Tag val = product.Tags.Where(t => t.Id == tagId).FirstOrDefault();
                    if (val != null)
                        product.Tags.Remove(val);
                }
                context.SaveChanges();
            }
            Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close();</script>");
        }
    }
}
