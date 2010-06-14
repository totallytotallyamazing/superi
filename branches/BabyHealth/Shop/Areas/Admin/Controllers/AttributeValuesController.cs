using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;

namespace Shop.Areas.Admin.Controllers
{
    public class AttributeValuesController : Controller
    {
        [ChildActionOnly]
        public ActionResult Index(int attributeId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                ViewData["attributeId"] = attributeId;
                List<ProductAttributeValue> values = context.ProductAttributeValues.Where(pav => pav.ProductAttribute.Id == id).ToList();
                return View(values);
            }
        }

        public ActionResult AddEdit(int id, int? valueId)
        {
            ViewData["attributeId"] = id;
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
                    EntityKey entityKey = new EntityKey("ShopStorage.ProductAttributes", "Id", productAttributeValue.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyPropertyChanges(entityKey.EntitySetName, productAttributeValue);
                    }
                }
                else
                {
                    context.AddToProductAttributeValues(productAttributeValue);
                }
                context.SaveChanges();
            }
            return JavaScript("window.top.location.href = window.top.location.href");
        }

    }
}
