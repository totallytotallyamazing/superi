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
using System.Web.Script.Serialization;
using System.Text;
using System.Net.Mail;
using Trips.Mvc.Runtime;
using System.Data;

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
                        attributeValues = context.ProductAttributeValues.Include("ProductAttribute")
                            .Where(ContextExtension.BuildContainsExpression<ProductAttributeValue, int>(e => e.Id, ids))
                            .ToList();
                    }
                    Product product = context.Products.Include("ProductImages").Where(p => p.Id == id).First();
                    var image = product.ProductImages.Where(i => i.Default).FirstOrDefault();
                    OrderItem orderItem = new OrderItem
                    {
                        Name = product.Name,
                        Price = product.Price,
                        ProductId = product.Id,
                        Quantity = 1,
                        Image = (image != null) ? image.ImageSource : null,
                        Description = product.ShortDescription
                    };
                    if (product.ProductAttributeValues.Count > 0)
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        string serializedAttributeValues = serializer.Serialize(
                            attributeValues
                            .Select(av => new KeyValuePair<string, string>(av.ProductAttribute.Name, av.Value))
                            .ToArray());
                        orderItem.ProductAttributes = serializedAttributeValues;
                    }
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

        public ActionResult Authorize()
        {
            if (WebSession.OrderItems.Count == 0)
                return RedirectToAction("Index", "Home", null);

            AuthorizeModel authorizeModel = null;

            if (WebSession.IsBillingInfoFilled())
            {
                authorizeModel = new AuthorizeModel
                {
                    Email = WebSession.Order.BillingEmail,
                    Name = WebSession.Order.BillingName,
                    Phone = WebSession.Order.BillingPhone
                };
            }
            else if (Request.IsAuthenticated)
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
            WebSession.Order.BillingEmail = authorizeModel.Email;
            WebSession.Order.BillingName = authorizeModel.Name;
            WebSession.Order.BillingPhone = authorizeModel.Phone;
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

        public ActionResult DeliveryAndPayment()
        {
            if (WebSession.OrderItems.Count == 0)
                return RedirectToAction("Index", "Home", null);

            AuthorizeModel model = null;
            if (WebSession.IsBillingInfoFilled())
            {
                model = new AuthorizeModel
                {
                    DeliveryAddress = WebSession.Order.DeliveryAddress,
                    Name = WebSession.Order.BillingName,
                    Phone = WebSession.Order.BillingPhone,
                    AdditionalDeliveryInfo = WebSession.Order.AdditionalDeliveryInfo
                };
            }
            else if (Request.IsAuthenticated)
            {
                ProfileCommon profile = ProfileCommon.Create(User.Identity.Name);
                model = new AuthorizeModel
                {
                    DeliveryAddress = profile.DeliveryAddress,
                    Name = profile.Name,
                    Phone = profile.Phone,
                    Email = User.Identity.Name
                };
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeliveryAndPayment(AuthorizeModel model, FormCollection form)
        {
            using (OrdersStorage context = new OrdersStorage())
            {
              //  context.Attach(WebSession.Order);
                WebSession.Order.DeliveryAddress = model.DeliveryAddress;
                WebSession.Order.DeliveryName = model.Name;
                WebSession.Order.DeliveryPhone = model.Phone;
                WebSession.Order.AdditionalDeliveryInfo = model.AdditionalDeliveryInfo;


                var paymentPropertyValues = form.AllKeys.Where(ac => ac.StartsWith("pp_"));

                int[] ppIds = paymentPropertyValues.Select(fac => int.Parse(fac.Split('_')[1])).ToArray();

                List<PaymentProperty> paymentProperties = null;

                WebSession.PaymentProertyValues.Clear();

                paymentProperties = context.PaymentProperties
                    .Where(ContextExtension.BuildContainsExpression<PaymentProperty, int>(pp => pp.Id, ppIds)).ToList();
                if (paymentPropertyValues.Count() > 0)
                {
                    foreach (var item in paymentPropertyValues)
                    {
                        string[] itemSegments = item.Split('_');

                        int paymentPropertyId = int.Parse(itemSegments[1]);
                        string paymentPropertyValue = form[item];

                        PaymentProperty paymentProperty = paymentProperties.First(pp => pp.Id == paymentPropertyId);

                        PaymentPropertyValue val = new PaymentPropertyValue
                        {
                            PaymentProperty =  paymentProperty,
                            Value = paymentPropertyValue
                        };


                        //context.Attach(paymentProperty);
                        //WebSession.Order.PaymentPropertyValues.Add(val);
                        WebSession.PaymentProertyValues.Add(val);
                    }
                }
                //context.SaveChanges();
                //context.Detach(WebSession.Order);
            }

            return RedirectToAction("Approve");
        }

        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Approve()
        {
            if (WebSession.OrderItems.Count == 0)
                return RedirectToAction("Index", "Home", null);

            return View();
        }

        private void SaveOrder()
        {
            using (OrdersStorage context = new OrdersStorage())
            {
                context.AddToOrders(WebSession.Order);
                context.Attach(WebSession.DeliveryType);
                context.Attach(WebSession.PaymentType);
                foreach (var item in WebSession.PaymentProertyValues)
                {
                    PaymentPropertyValue val = new PaymentPropertyValue();
                    val.Value = item.Value;
                    val.PaymentPropertyReference.EntityKey = new EntityKey("OrdersStorage.PaymentProperties", "Id", item.PaymentProperty.Id);
                    WebSession.Order.PaymentPropertyValues.Add(val);
                }
                WebSession.Order.DeliveryType = WebSession.DeliveryType;
                WebSession.Order.PaymentType = WebSession.PaymentType;
                WebSession.Order.UniqueId = Guid.NewGuid().ToString();
                foreach (var item in WebSession.OrderItems)
                    WebSession.Order.OrderItems.Add(item.Value);
                WebSession.Order.OrderDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public ActionResult SendOrder()
        {
            SaveOrder();
            SendOrderMail();
            if(!string.IsNullOrEmpty(WebSession.Order.BillingEmail))
                SendClientMail();

            return RedirectToAction("OrderSent");
        }

        private void SendClientMail()
        {
            string link = string.Empty;
            if (WebSession.PaymentType.HasDocument)
            {
                StringBuilder sb = new StringBuilder();
                string format = "<a href=\"http://shop.baby-health.org.ua/Invoice/Show/{0}?orderId={1}&uniqueId={2}\">{3}</a>";
                link = string.Format(format, WebSession.PaymentType.DocumentName, WebSession.Order.Id, WebSession.Order.UniqueId, WebSession.PaymentType.DocumentCaption);
            }

            List<MailAddress> to = new List<MailAddress>();
            to.Add(new MailAddress(WebSession.Order.BillingEmail));
            MailHelper.SendTemplate(to, "Заказ №" + WebSession.Order.Id + " на сайте baby-health.org.ua",
                "ClientMail.htm", null, true, CreateOrderPresentation(), link);

        }

        private void SendOrderMail()
        {
            string deliveryAddress = WebSession.Order.DeliveryAddress ?? string.Empty;
            string additionalDeliveryInfo = WebSession.Order.AdditionalDeliveryInfo ?? string.Empty;
            List<MailAddress> to = new List<MailAddress>();
            to.Add(new MailAddress(Configurator.GetSetting("ReceiverMail")));
            MailHelper.SendTemplate(to, "Заказ №" + WebSession.Order.Id + " на сайте baby-health.org.ua",
                "MailTemplate.htm", null, true, WebSession.Order.BillingEmail,
                WebSession.Order.BillingName, WebSession.Order.BillingPhone,
                WebSession.Order.DeliveryName, WebSession.Order.DeliveryPhone,
                deliveryAddress.Replace("\r", "<br />"),
                additionalDeliveryInfo.Replace("\r", "<br />"),
                CreateOrderPresentation());

        }

        private string CreateOrderPresentation()
        {
            string url = Request.Url.Scheme + ":" + Request.Url.Authority + Request.ApplicationPath;
            StringBuilder result = new StringBuilder();
            foreach (var item in WebSession.OrderItems)
            {
                result.Append("<tr>");
                result.AppendFormat("<td><img src=\"{0}ImageCache/cartThumb/{1}\" /></td>",
                    url, item.Value.Image);
                result.AppendFormat("<td>{0}<br />{1}</td>", item.Value.Name, item.Value.Description);
                result.AppendFormat("<td>{0}</td>", item.Value.Quantity);
                result.Append("</tr>");
            }
            return result.ToString();
        }

        public ActionResult OrderSent()
        {
            if (WebSession.OrderItems.Count == 0)
                return RedirectToAction("Index", "Home", null);

            return View();
        }

        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult AvailablePaymentTypes(int id)
        {
            using (OrdersStorage context = new OrdersStorage())
            {
                context.PaymentTypes.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                context.DeliveryTypes.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                var result = context.DeliveryTypes.Where(dt => dt.Id == id).Select(dt => new { paymentTypes = dt.PaymentTypes, deliveryType = dt }).First();
                List<PaymentType> paymentTypes = result.paymentTypes.ToList();
                WebSession.DeliveryType = result.deliveryType;
                return View(paymentTypes);
            }
        }

        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult PaymentProperties(int id)
        {
            using (OrdersStorage context = new OrdersStorage())
            {
                context.PaymentTypes.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                context.PaymentProperties.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                var result = context.PaymentTypes.Where(pt => pt.Id == id).Select(pt => new { paymentProperties = pt.PaymentProperties, paymentType = pt }).First();
                List<PaymentProperty> paymentProperties = result.paymentProperties.ToList();
                WebSession.PaymentType = result.paymentType;
                return View(paymentProperties);
            }
        }
    }

}

namespace Shop.Models
{
    public class AuthorizeModel
    {
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Неверно введен адрес почты. Формат: name@domain.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обязательно!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обязательно!")]
        [RegularExpression(@"^(\(\d{3}\))?\s?((\d{3}(\s|-)?\d{2}(\s|-)\d{2})|(\d{3}(\s|-)?\d{4})|(\d{7}))$", ErrorMessage = "Неверно введен номер телефона. Формат: (123) 111-22-33")]
        public string Phone { get; set; }
        public string DeliveryAddress { get; set; }
        public string AdditionalDeliveryInfo { get; set; }
    }
}