using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zamov.Models;
using System.Data.Objects;
using System.Data;
using Zamov.Helpers;
using System;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace Zamov.Controllers
{
    [BreadCrumb(CategoryId = true)]
    public class ProductsController : Controller
    {

        private const int MaxTopProductsNumber = 5;
        //TODO: ��� ������ � ��������������
        [BreadCrumb(SubCategoryId = true)]
        public ActionResult Index(string dealerId, int? groupId, SortFieldNames? sortField, SortDirection? sortOrder)
        {
            ViewData["sortDirection"] = sortOrder;
            ViewData["sortField"] = (sortField != null) ? sortField.ToString() : null;
            ViewData["sortDealerId"] = dealerId;
            string sortFieldPart = (sortField!=null) ? sortField.ToString() : "NoSort";
            string sortOrderPart = (sortOrder != null) ? sortOrder.ToString() : "NoSort";
            string productsCacheKey = "ProductsPage_" + dealerId + "_" + groupId + "_" + sortFieldPart + "_" + sortOrderPart;
            using (ZamovStorage context = new ZamovStorage())
            {
                int dealer = context.Dealers.Where(d => d.Name == dealerId).Select(d => d.Id).First();
                BreadCrumbsExtensions.AddBreadCrumb(HttpContext, BreadCrumbAttribute.DealerName(dealer), "/Dealers/SelectDealer/" + dealer);
                if (groupId != null)
                    BreadCrumbAttribute.ProcessGroup(groupId.Value, HttpContext);

                List<Group> groups = (from g in context.Groups.Include("Groups").Include("Dealer") where g.Dealer.Id == dealer && !g.Deleted && g.Enabled select g).ToList();
                ViewData["groups"] = groups;
                ViewData["dealerId"] = dealer;
                ViewData["groupId"] = groupId;

                bool displayGroupImages = false;
                
                Group currentGroup = null;
                if (groupId != null)
                {
                    currentGroup = groups.Where(g => g.Id == groupId.Value).Select(g => g).SingleOrDefault();
                    displayGroupImages = currentGroup.DisplayProductImages;
                }
                else
                {
                    displayGroupImages = false;
                }

                ViewData["displayGroupImages"] = displayGroupImages;

                if (HttpContext.Cache[productsCacheKey] == null)
                {
                    List<Product> products = new List<Product>();
                    if (groupId != null)
                    {
                        CollectProducts(products, currentGroup);
                        products = products.Where(p => !p.Deleted && p.Group.Enabled && p.Enabled && !p.Group.Deleted).ToList();
                    }
                    else
                        products = (from product in context.Products where ((groupId == null) || product.Group.Id == groupId) && product.Dealer.Id == dealer && !product.Deleted && product.Group.Enabled && !product.Group.Deleted && product.Enabled select product).ToList();

                    
                    products.ForEach(p => p.LoadDescriptions());



                    if (sortField != null && sortOrder != null)
                        switch (sortField)
                        {
                            case SortFieldNames.Name:
                                if (sortOrder == SortDirection.Ascending)
                                    products.Sort(new PSortByProductNameAsc());
                                else
                                    products.Sort(new PSortByProductNameDesc());
                                break;
                            case SortFieldNames.Price:
                                if (sortOrder == SortDirection.Ascending)
                                    products.Sort(new PSortByPriceAsc());
                                else
                                    products.Sort(new PSortByPriceDesc());
                                break;
                        }
                    HttpContext.Cache.Add(productsCacheKey, products, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0), CacheItemPriority.Default, null);
                }
            }

            List<Product> result = (List<Product>)HttpContext.Cache[productsCacheKey];
            ViewData["topProducts"] = GetTopProducts(result);
            result = RemoveTopProducts(result);

            return View(result);
        }

        private List<Product> GetTopProducts(List<Product> source)
        {
            List<Product> allTops = source.Where(p => p.TopProduct).Select(p => p).ToList();

            if (allTops.Count < MaxTopProductsNumber + 1)
                return allTops;

            List<Product> result = new List<Product>();
            Random random = new Random();

            int topCount = allTops.Count;
            for (int i = 0; i < MaxTopProductsNumber; i++)
            {
                Product item = allTops[random.Next(topCount)];
                result.Add(item);
                allTops.Remove(item);
                topCount--;
            }
            return result;
        }

        private List<Product> RemoveTopProducts(List<Product> source)
        {
            return source.Where(p => !p.TopProduct).Select(p => p).ToList();
        }

        public ActionResult ProductGroups(string dealerId, int? groupId)
        {
            List<GroupResentation> groups = null;
            using (ZamovStorage context = new ZamovStorage())
            {
                groups = (from gr in context.Groups
                          join translation in context.Translations on gr.Id equals translation.ItemId
                          where translation.TranslationItemTypeId == (int)ItemTypes.Group
                             && translation.Language == SystemSettings.CurrentLanguage
                             && gr.Enabled
                             && !gr.Deleted
                             && gr.Dealer.Name == dealerId
                          select new GroupResentation
                              {
                                  Id = gr.Id,
                                  Name = translation.Text,
                                  ParentId = (gr.Parent != null) ? (int?)gr.Parent.Id : null,
                                  DealerName = gr.Dealer.Name
                              }
                              ).ToList();
            }
            int groupToExpand = int.MinValue;
            groups.ForEach(ac => { ac.PickChildren(groups); ac.PickParent(groups); });
            if (groupId != null)
            {
                GroupResentation currentGroup = groups.Where(g => g.Id == groupId.Value).SingleOrDefault();
                while (currentGroup != null)
                {
                    groupToExpand = currentGroup.Id;
                    currentGroup = currentGroup.Parent;
                }
            }
            ViewData["groupToExpand"] = groupToExpand;
            ViewData["dealerId"] = dealerId;
            ViewData["groupId"] = groupId;
            List<GroupResentation> sortedGroups = groups.Select(c => c).Where(c => c.ParentId == null).ToList();
            return View(sortedGroups);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddToCart(int dealerId, int? groupId, FormCollection items)
        {

            string dealerName = "";
            using (ZamovStorage str = new ZamovStorage())
            {
                dealerName = str.Dealers.Where(d => d.Id == dealerId).Select(d => d.Name).FirstOrDefault();
            }

            Cart cart = SystemSettings.Cart;
            PostData orderItems = items.ProcessPostData("dealerId", "groupId");
            if (orderItems.Count > 0)
            {
                Order order = (from o in cart.Orders where o.DealerReference.EntityKey != null && (int)o.DealerReference.EntityKey.EntityKeyValues[0].Value == dealerId select o).SingleOrDefault();
                var orderItemList =
                    (from oi in orderItems
                     where oi.Value["order"].ToLowerInvariant().Contains("true")
                     select new { Id = int.Parse(oi.Key), Quantity = int.Parse(oi.Value["quantity"].Replace("_", string.Empty)) })
                     .ToList();
                if (order == null)
                {
                    order = new Order();
                    order.HashCode = order.GetHashCode();
                    IEnumerable<KeyValuePair<string, object>> dealerKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", dealerId) };
                    EntityKey dealer = new EntityKey("OrderStorage.OrderDealers", dealerKeyValues);
                    order.DealerReference.EntityKey = dealer;
                }
                Dictionary<int, Product> products = null;
                string productIds = string.Join(",", orderItemList.Select(oil => oil.Id.ToString()).ToArray());
                if (!string.IsNullOrEmpty(productIds))
                {
                    using (ZamovStorage context = new ZamovStorage())
                    {
                        ObjectQuery<Product> productsQuery = new ObjectQuery<Product>(
                                    "SELECT VALUE P FROM Products AS P WHERE P.Id IN {" + productIds + "}",
                                    context);
                        products = productsQuery.ToDictionary(pr => pr.Id);
                    }
                    if (products != null && products.Count > 0)
                    {
                        foreach (var orderItem in orderItemList)
                        {
                            bool hasItem = false;
                            Product product = products[orderItem.Id];
                            OrderItem item = null;
                            if (order.OrderItems != null && order.OrderItems.Count > 0)
                                item = (from i in order.OrderItems where i.PartNumber == product.PartNumber select i).SingleOrDefault();
                            if (item == null)
                            {
                                item = new OrderItem();
                                item.HashCode = item.GetHashCode();
                            }
                            else
                                hasItem = true;
                            if (!hasItem)
                            {
                                item.PartNumber = product.PartNumber;
                                item.Name = product.Name;
                                item.Price = product.Price;
                                item.ProductId = product.Id;
                                item.Unit = product.Unit;
                                item.Quantity = orderItem.Quantity;
                                order.OrderItems.Add(item);
                            }
                            else
                                item.Quantity += orderItem.Quantity;
                        }
                        cart.Orders.Add(order);
                    }
                }
            }
            return RedirectToAction("Index", new { dealerId = dealerName, groupId = groupId });
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

        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Description(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                ProductPresentation product = (from item in context.Products.Include("ProductImages")
                                               where 
                                               item.Id == id
                                               let hasImage = item.ProductImages.Count > 0
                                               let imageId = (hasImage) ? item.ProductImages.FirstOrDefault().Id : 0
                                               let description = 
                                                (from d in context.Translations where d.Language == SystemSettings.CurrentLanguage 
                                                     && d.TranslationItemTypeId == (int)ItemTypes.ProductDescription 
                                                     && d.ItemId == item.Id
                                                     select d.Text).FirstOrDefault()
                                               select new ProductPresentation
                                               {
                                                   Name = item.Name,
                                                   Description = description,
                                                   HasImage = hasImage,
                                                   ImageId = imageId,
                                                   Id = item.Id
                                               }
                                               ).First();
                return View(product);
            }
        }
    }
}