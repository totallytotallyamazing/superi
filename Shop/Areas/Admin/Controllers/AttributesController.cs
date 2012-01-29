using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using Superi.Web.Mvc.Localization;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AttributesController : Controller
    {
        ShopStorage context = new ShopStorage();

        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                ViewData["id"] = id;
            }
            using (ShopStorage context = new ShopStorage())
            {
                List<ProductAttribute> attributes = context.ProductAttributes
                    .Localize((a, l) => new { Attribute = a, Localization = l }, context.ShopLocalResources, null)
                    .ToList()
                    .Select(i => i.Attribute.UpdateValues(i.Localization))
                    .OrderBy(pa => pa.SortOrder).ToList();
                return View(attributes);
            }
        }

        public ActionResult AddEdit(int? id)
        {
            ViewData["title"] = "Создать атрибут";
            ViewData["Context"] = context;
            ProductAttribute attribute = null;
            if (id.HasValue)
            {
                attribute = context.ProductAttributes.Where(pa => pa.Id == id.Value).First();
                ViewData["title"] = "Редактировать " + attribute.Name;
            }
            return View(attribute);
        }

        [HttpPost]
        public ActionResult AddEdit(ProductAttribute attribute, ShopLocalResource[] localizations)
        {
            using (ShopStorage context = new ShopStorage())
            {
                attribute.UpdateValues(localizations.Where(l=>l.Language == "ru-RU"));
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
                attribute.Static = true;
                if (localizations != null)
                    localizations.SaveLocalizationsTo(context.ShopLocalResources, false);
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
