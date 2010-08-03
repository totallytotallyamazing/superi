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
                Product product = context.Products.Include("ProductAttributeValues.ProductAttribute").Where(p => p.Id == productId).First();

                PostData postData = form.ProcessPostData("productId", "categoryId");
                int[] dynamicItems = GetDynamicAttributeValues(postData);
                KeyValuePair<int, int>[] staticItems = GetStaticAttributeValues(postData);

                foreach (int id in dynamicItems)
                {
                    AddProductAttributeValue(product, id, context);
                }

                foreach (KeyValuePair<int, int> id in staticItems)
                {
                    AddStaticProductAttributeValue(product, id.Key, id.Value, context);
                }

                context.SaveChanges();
                Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close()</script>");
            }
        }

        private int[] GetDynamicAttributeValues(PostData postData)
        {
            int[] dynamicItems = (from item in postData
                                  where
                                      item.Value.ContainsKey("attr") 
                                      && item.Value["attr"] == "true"
                                  select int.Parse(item.Key)).ToArray();

            return dynamicItems;
        }

        private KeyValuePair<int, int>[] GetStaticAttributeValues(PostData postData)
        {
            KeyValuePair<int, int>[] staticItems = (from item in postData
                                  where item.Value.ContainsKey("static")
                                  select new KeyValuePair<int, int>(int.Parse(item.Key), int.Parse(item.Value["static"])))
                                  .ToArray();

            return staticItems;
        }

        private void AddProductAttributeValue(Product product, int valueId, ShopStorage context)
        {
            ProductAttributeValue val = new ProductAttributeValue();

            if (product.ProductAttributeValues.Where(pv => pv.Id == valueId).Count() == 0)
            {
                val.Id = valueId;
                val.EntityKey = new System.Data.EntityKey("ShopStorage.ProductAttributeValues", "Id", valueId);
                context.Attach(val);
                product.ProductAttributeValues.Add(val);
            }
        }

        private void AddStaticProductAttributeValue(Product product, int attributeId, int valueId, ShopStorage context)
        {
            ProductAttributeValue value = product.ProductAttributeValues.Where(pv => pv.Id == valueId).FirstOrDefault();

            ProductAttributeValue otherValue = product.ProductAttributeValues
                .Where(pv => pv.Id != valueId && pv.ProductAttribute != null && pv.ProductAttribute.Id == attributeId)
                .FirstOrDefault();

            //The static ProductAttributeValues should be mutually exclusive
            if (value != null)
                return;
            else if (otherValue != null)
                product.ProductAttributeValues.Remove(otherValue);

            AddProductAttributeValue(product, valueId, context);
        }
    }
}
