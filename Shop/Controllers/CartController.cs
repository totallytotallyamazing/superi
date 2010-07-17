using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dev.Helpers;
using Shop.Models;
using Shop.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            if (WebSession.OrderItems.Count == 0)
                return RedirectToAction("Index", "Home", null);

            float totalAmount = WebSession.OrderItems.Sum(oi => oi.Value.Price * oi.Value.Quantity);
            ViewData["totalAmount"] = totalAmount;
            return View(WebSession.OrderItems.Select(oi => oi.Value).ToList());
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
                            int valueId = int.Parse(item.Value["attr"]);
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
                        Image = product.ProductImages.Where(i => i.Default).First().ImageSource,
                        Description = product.Description
                    };
                    orderItem.SelectedAttributes.AddRange(attributeValues);
                    WebSession.OrderItems.Add(product.Id, orderItem);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            WebSession.OrderItems.Remove(id);
            if (WebSession.OrderItems.Count == 0)
                return RedirectToAction("Index", "Home", null);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Authorize(FormCollection form)
        {
            AuthorizeModel authorizeModel = null;
            if (Request.IsAuthenticated)
            {
                ProfileCommon profile = ProfileCommon.Create(User.Identity.Name);
                authorizeModel = new AuthorizeModel
                {
                    Email = User.Identity.Name,
                    Phone = profile.Phone,
                    Name = profile.Name,
                };
            }
            return View(authorizeModel);
        }

        [HttpPost]
        public ActionResult Authorize(AuthorizeModel authorizeModel)
        {
            return RedirectToAction("DeliveryAndPayment");
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int id, int quantity)
        {
            if (WebSession.OrderItems.ContainsKey(id))
            {
                WebSession.OrderItems[id].Quantity = quantity;
            }

            var result = new
            {
                items = WebSession.OrderItems.Select(oi => new
                {
                    id = oi.Value.ProductId,
                    price = CurrencyHelper.FormatPrice(oi.Value.Price * oi.Value.Quantity, WebSession.Currency, 0, ",")
                }).ToList(),
                totalAmount = CurrencyHelper.FormatPrice(WebSession.OrderItems.Sum(oi => oi.Value.Price * oi.Value.Quantity), WebSession.Currency, 0, ",")
            };
            return Json(result);
        }
    }
    
}

namespace Shop.Models
{
    public class AuthorizeModel
    {
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Неверно введен адрес почты. Формат: name@domain.com")]
        public string Email { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Обязательно!")]
        [RegularExpression(@"^(\(\d{3}\))?\s?((\d{3}(\s|-)?\d{2}(\s|-)\d{2})|(\d{3}(\s|-)?\d{4})|(\d{7}))$", ErrorMessage = "Неверно введен номер телефона. Формат: (123) 111-22-33")]
        public string Phone { get; set; }
    }
}