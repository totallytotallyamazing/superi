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
    public class AttributeValuesController : Controller
    {
        [ChildActionOnly]
        public ActionResult Index(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                ViewData["attributeId"] = id;
                List<ProductAttributeValue> values = context.ProductAttributeValues
                    .Where(pav => pav.ProductAttribute.Id == id)
                    .OrderBy(pav=>pav.SortOrder)
                    .ToList();
                return View(values);
            }
        }

        public ActionResult AddEdit(int attributeId, int? valueId)
        {
            ViewData["attributeId"] = attributeId;
            ProductAttributeValue value = null;
            if (valueId.HasValue)
            {
                using (ShopStorage context= new ShopStorage())
                {
                    value = context.ProductAttributeValues.Where(pav => pav.Id == valueId.Value).First();
                }
            }
            return View(value);
        }

        [HttpPost]
        public ActionResult AddEdit(ProductAttributeValue productAttributeValue, int attributeId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                if (productAttributeValue.Id > 0)
                {
                    object originalItem;
                    EntityKey entityKey = new EntityKey("ShopStorage.ProductAttributeValues", "Id", productAttributeValue.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyCurrentValues(entityKey.EntitySetName, productAttributeValue);
                    }
                }
                else
                {
                    context.AddToProductAttributeValues(productAttributeValue);
                    EntityKey key = new EntityKey("ShopStorage.ProductAttributes", "Id", attributeId);
                    productAttributeValue.ProductAttributeReference.EntityKey = key;
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Attributes", new { id = attributeId });
        }

        public ActionResult Delete(int id)
        { 
            using (ShopStorage context = new ShopStorage())
            {
                ProductAttributeValue value = context.ProductAttributeValues.Include("ProductAttribute").Where(pav=>pav.Id == id).First();
                int attributeId = value.ProductAttribute.Id;
                context.DeleteObject(value);
                context.SaveChanges();
                return RedirectToAction("Index", "Attributes", new { id = attributeId });
            }
        }

    }
}
