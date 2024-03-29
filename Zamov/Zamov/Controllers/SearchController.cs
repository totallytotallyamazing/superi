using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Data;
using Zamov.Helpers;
using System.Collections;
using System.Web.UI.WebControls;

namespace Zamov.Controllers
{
    public enum SortFieldNames
    {
        Name,
        Price,
        Dealer
    }
    /*
    public enum SortDirection
    {
        Ascending,
        Descending
    }
    */
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(SystemSettings.SearchContext))
                SearchProduct(SystemSettings.SearchContext, null, null);
            return View();
        }

        [BreadCrumb( ResourceName = "Search", Url = "/Search")]
        public ActionResult SearchProduct(string searchContext, SortFieldNames? sortField, SortDirection? sortOrder)
        {

            ViewData["sortDirection"] = sortOrder;
            ViewData["sortField"] = (sortField != null) ? sortField.ToString() : null;
            ViewData["searchContext"] = HttpUtility.UrlPathEncode(searchContext);
            if (string.IsNullOrEmpty(searchContext))
                searchContext = SystemSettings.SearchContext;
            if (!string.IsNullOrEmpty(searchContext))
            {
                SystemSettings.SearchContext = searchContext;
                using (ZamovStorage context = new ZamovStorage())
                {
                    ObjectQuery<Product> productsQuery = new ObjectQuery<Product>(
                        "SELECT VALUE P FROM Products AS P WHERE P.Name LIKE '%" + searchContext + "%'", context);
                    List<ProductSearchPresentation> products = (from product in productsQuery
                                                                join dealerName in context.Translations on product.Dealer.Id equals dealerName.ItemId
                                                                where dealerName.TranslationItemTypeId == (int)ItemTypes.DealerName
                                                                && dealerName.Language == SystemSettings.CurrentLanguage
                                                                && product.Group.Enabled && !product.Group.Deleted
                                                                let description =
                                                                    (from d in context.Translations
                                                                     where d.Language == SystemSettings.CurrentLanguage
                                                                         && d.TranslationItemTypeId == (int)ItemTypes.ProductDescription
                                                                         && d.ItemId == product.Id
                                                                     select d.Text).FirstOrDefault()
                                                                select new ProductSearchPresentation
                                                                {
                                                                    DealerNameId = product.Dealer.Name,
                                                                    DealerId = product.Dealer.Id,
                                                                    DealerName = dealerName.Text,
                                                                    Name = product.Name,
                                                                    Price = product.Price,
                                                                    Id = product.Id,
                                                                    Unit = product.Unit,
                                                                    Description = description
                                                                }
                                                                    ).ToList();

                    if (sortField != null && sortOrder != null)
                        switch (sortField)
                        {
                            case SortFieldNames.Name:
                                if (sortOrder == SortDirection.Ascending)
                                    products.Sort(new SortByProductNameAsc());
                                else
                                    products.Sort(new SortByProductNameDesc());
                                break;
                            case SortFieldNames.Price:
                                if (sortOrder == SortDirection.Ascending)
                                    products.Sort(new SortByPriceAsc());
                                else
                                    products.Sort(new SortByPriceDesc());
                                break;
                            case SortFieldNames.Dealer:
                                if (sortOrder == SortDirection.Ascending)
                                    products.Sort(new SortByDealerNameAsc());
                                else
                                    products.Sort(new SortByDealerNameDesc());
                                break;
                        }
                    
                    return View(products);
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddToCart(FormCollection items)
        {
            Cart cart = SystemSettings.Cart;
            PostData orderItems = items.ProcessPostData("X-Requested-With");
            if (orderItems.Count > 0)
            {
                var orderItemList =
                   (from oi in orderItems
                    where oi.Value["order"].ToLowerInvariant().Contains("true")
                    select new { Id = int.Parse(oi.Key), Dealer = int.Parse(oi.Value["dealer"]), Quantity = int.Parse(oi.Value["quantity"]) })
                    .ToList();

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
                        Order order = (from o in cart.Orders where o.DealerReference.EntityKey != null && (int)o.DealerReference.EntityKey.EntityKeyValues[0].Value == orderItem.Dealer select o).SingleOrDefault();
                        if (order == null)
                        {
                            order = new Order();
                            order.HashCode = order.GetHashCode();
                            IEnumerable<KeyValuePair<string, object>> dealerKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", orderItem.Dealer) };
                            EntityKey dealer = new EntityKey("OrderStorage.OrderDealers", dealerKeyValues);
                            order.DealerReference.EntityKey = dealer;
                            cart.Orders.Add(order);
                        }
                        Product product = products[orderItem.Id];
                        OrderItem item = null;
                        if (order.OrderItems != null && order.OrderItems.Count > 0)
                            item = (from i in order.OrderItems where i.PartNumber == product.PartNumber select i).SingleOrDefault();
                        if (item == null)
                        {
                            item = new OrderItem();
                            item.HashCode = item.GetHashCode();
                        }
                        item.PartNumber = product.PartNumber;
                        item.Name = product.Name;
                        item.Price = product.Price;
                        item.ProductId = product.Id;
                        item.Quantity = orderItem.Quantity;
                        item.Unit = product.Unit;
                        order.OrderItems.Add(item);
                    }
                }
            }
            int totalCartItems = cart.Orders.Sum(o => o.OrderItems.Sum(oi=>oi.Quantity));
            decimal totalCartPrice = cart.Orders.Sum(o => o.OrderItems.Sum(oi => oi.Quantity * oi.Price));
            return Json(new { TotalCartPrice = totalCartPrice, TotalCartItems = totalCartItems });
        }


    }
}
