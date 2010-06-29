using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles="Administrators")]
    public class TagsController : Controller
    {
        public ActionResult Index()
        {
            using (ShopStorage context= new ShopStorage())
            {
                List<Tag> tags = context.Tags.ToList();
                return View(tags); 
            }
        }

        public ActionResult Add([Bind(Exclude="Id")]Tag tag)
        {
            using (ShopStorage context = new ShopStorage())
            {
                context.AddToTags(tag);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                Tag tag = context.Tags.Where(t => t.Id == id).First();
                context.DeleteObject(tag);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
