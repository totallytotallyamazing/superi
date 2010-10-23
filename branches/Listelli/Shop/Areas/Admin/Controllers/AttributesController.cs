using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles="Administrators")]
    public class AttributesController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                ViewData["id"] = id;
            }
            using (ShopStorage context = new ShopStorage())
            {
                List<ProductAttribute> attributes = context.ProductAttributes.OrderBy(pa=>pa.SortOrder).ToList();
                return View(attributes);
            }
        }

        public ActionResult AddEdit(int? id)
        {
            ViewData["title"] = "Создать атрибут";
            ProductAttribute attribute = null;
            if (id.HasValue)
            {
                using (ShopStorage context = new ShopStorage())
                {
                    attribute = context.ProductAttributes.Where(pa => pa.Id == id.Value).First();
                    ViewData["title"] = "Редактировать " + attribute.Name;
                }
            }
            return View(attribute);
        }

        [HttpPost]
        public ActionResult AddEdit(ProductAttribute attribute)
        {
            using (ShopStorage context = new ShopStorage())
            {
                if (attribute.Id > 0)
                {
                    object originalItem;
                    EntityKey entityKey = new EntityKey("ShopStorage.ProductAttributes", "Id", attribute.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyCurrentValues(entityKey.EntitySetName, attribute);
                    }
                }
                else
                {
                    context.AddToProductAttributes(attribute);
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Attributes", new { id = attribute.Id, area = "Admin" });
        }

        public ActionResult Delete(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                ProductAttribute attribute = context.ProductAttributes.First(pa => pa.Id == id);
                context.DeleteObject(attribute);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
