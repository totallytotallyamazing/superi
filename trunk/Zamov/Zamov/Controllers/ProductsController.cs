using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Script.Serialization;
using System.Data.Objects;
using System.Data;

namespace Zamov.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index(int dealerId, int? groupId)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Group> groups = (from g in context.Groups.Include("Groups") where g.Dealer.Id == dealerId select g).ToList();
                ViewData["groups"] = groups;
                ViewData["dealerId"] = dealerId;
                ViewData["groupId"] = groupId;
                List<Product> products = new List<Product>();
                if (groupId != null)
                {
                    Group currentGroup = groups.Where(g => g.Id == groupId.Value).Select(g => g).SingleOrDefault();
                    CollectProducts(products, currentGroup);
                }
                else
                    products = (from product in context.Products where ((groupId == null) || product.Group.Id == groupId) && product.Dealer.Id == dealerId select product).ToList();
                return View(products);
            }
        }

        //TODO: not finished yet
        private Dictionary<string, Dictionary<string, string>> ProcessPostData(FormCollection form, params string[] excludeFields)
        {
            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
            foreach (string key in form.Keys)
            {
                if (excludeFields == null || !excludeFields.Contains(key))
                {
                    string[] item = key.Split('_');
                    string itemId = item[1];
                    string fieldName = item[0];
                }
            }
            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddToCart(int dealerId, int? groupId, FormCollection items)
        {
            Cart cart = SystemSettings.Cart;
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, Dictionary<string, string>> orderItems = ProcessPostData(items, "dealerId", "groupId");
            //serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(items);

            Order order = (from o in cart.Orders where o.Dealer != null && o.Dealer.Id == dealerId select o).SingleOrDefault();
            var orderItemList =
                (from oi in orderItems
                 where oi.Value["order"].ToLowerInvariant() == "true"
                 select new { Id = int.Parse(oi.Key), Quantity = int.Parse(oi.Value["quantity"]) })
                 .ToList();
            if (order == null)
                order = new Order();
            IEnumerable<KeyValuePair<string, object>> dealerKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", dealerId) };
            EntityKey dealer = new EntityKey("OrderStorage.OrderDealers", dealerKeyValues);
            order.DealerReference.EntityKey = dealer;
            Dictionary<int, Product> products = null;
            using (ZamovStorage context = new ZamovStorage())
            {
                string productIds = string.Join(",", orderItemList.Select(oil => oil.Id.ToString()).ToArray());
                ObjectQuery<Product> productsQuery = new ObjectQuery<Product>(
                            "SELECT VALUE P FROM Products AS P WHERE P.Id IN {" + productIds + "}",
                            context);
                products = productsQuery.ToDictionary(pr => pr.Id);
            }
            if (products != null && products.Count > 0)
            {
                foreach (var orderItem in orderItemList)
                {
                    Product product = products[orderItem.Id];
                    OrderItem item = null;
                    if (order.OrderItems != null && order.OrderItems.Count > 0)
                        item = (from i in order.OrderItems where i.PartNumber == product.PartNumber select i).SingleOrDefault();
                    if (item == null)
                        item = new OrderItem();
                    item.PartNumber = product.PartNumber;
                    item.Name = product.Name;
                    item.Price = product.Price;
                    item.ProductId = product.Id;
                    item.Quantity = orderItem.Quantity;
                    IEnumerable<KeyValuePair<string, object>> unitKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", 1) };
                    EntityKey unit = new EntityKey("OrderStorage.Units", unitKeyValues);
                    item.UnitReference.EntityKey = unit;
                    order.OrderItems.Add(item);
                }
                cart.Orders.Add(order);
            }
            return RedirectToAction("Index", new { dealerId = dealerId, groupId = groupId });
        }

        private void CollectProducts(List<Product> products, Group currentGroup)
        {
            if (!currentGroup.Products.IsLoaded)
                currentGroup.Products.Load();
            products.AddRange(currentGroup.Products);
            if (!currentGroup.Groups.IsLoaded)
                currentGroup.Groups.Load();
            if (currentGroup.Groups.Count > 0)
                foreach (var g in currentGroup.Groups)
                    CollectProducts(products, g);
        }

        public ActionResult Description(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                bool hasImage = context.ProductImages.Where(pi => pi.Product.Id == id).Count() > 0;
                ViewData["hasImage"] = hasImage;
                if (hasImage)
                {
                    ViewData["imageId"] = context.ProductImages.Where(pi => pi.Product.Id == id).Select(pi => pi.Id).First();
                }
                Product product = context.Products.Select(p => p).Where(p => p.Id == id).First();
                return View(product);
            }
        }
    }
}
