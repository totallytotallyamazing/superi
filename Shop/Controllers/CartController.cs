using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dev.Helpers;
using Shop.Models;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int id, FormCollection form)
        {
            if (WebSession.OrderItems.ContainsKey(id))
                WebSession.OrderItems[id].Quantity++;
            else
            {
                using (ShopStorage context = new ShopStorage())
                {
                    PostData postData = form.ProcessPostData();
                    List<ProductAttributeValue> attributeValues = null;
                    if (postData.Count > 0)
                    {
                        attributeValues = new List<ProductAttributeValue>();
                        List<int> ids = new List<int>();
                        foreach (var item in postData)
                        {
                            int attributeId = int.Parse(item.Key);
                            int valueId = int.Parse(item.Value[item.Key]);
                            ids.Add(valueId);
                        }
                        attributeValues = context.ProductAttributeValues
                            .Where(ContextExtension.BuildContainsExpression<ProductAttributeValue, int>(e => e.Id, ids))
                            .ToList();
                    }
                    Product product = context.Products.Include("ProductImages").Where(p => p.Id == id).First();
                    OrderItem orderItem = new OrderItem
                    {
                        Name = product.Name,
                        Price = product.Price,
                        ProductId = product.Id,
                        Quantity = 1,
                        Image = product.ProductImages.Where(i=>i.Default).First().ImageSource,
                        Description = product.Description
                    };
                    orderItem.SelectedAttributes.AddRange(attributeValues);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
