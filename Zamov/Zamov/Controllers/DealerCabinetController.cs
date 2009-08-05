using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Security;
using System.IO;
using System.Web.Script.Serialization;
using Zamov.Helpers;
using System.Data;
using System.Collections;

namespace Zamov.Controllers
{
    [Authorize(Roles = "Administrators, Dealers")]
    public class DealerCabinetController : CacheController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Groups
        public ActionResult Groups()
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                int dealerId = int.MinValue;
                dealerId = Security.GetCurentDealerId(User.Identity.Name);
                ViewData["dealerId"] = dealerId;
                return View();
            }
        }

        public ActionResult GoupList(int dealerId, int? id, int level)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                dealerId = Security.GetCurentDealerId(User.Identity.Name);
                ViewData["dealerId"] = dealerId;
                List<Group> groups = context.Groups.Select(g => g).Where(g => g.Dealer.Id == dealerId).ToList();
                if (id == null)
                    groups = groups.Select(g => g).Where(g => g.Parent == null).ToList();
                else
                    groups = groups.Select(g => g).Where(g => g.Parent != null && g.Parent.Id == id.Value).ToList();
                ViewData["level"] = level;
                return View(groups);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InsertGroup(string groupName, string groupUkrName, string groupRusName, bool enabled, int parentId)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                int dealerId = Security.GetCurentDealerId(User.Identity.Name);
                Dealer dealer = context.Dealers.Select(d => d).Where(d => d.Id == dealerId).First();
                Group parent = null;
                if (parentId >= 0)
                    parent = context.Groups.Select(c => c).Where(c => c.Id == parentId).First();
                Group group = new Group();
                group.Parent = parent;
                group.Dealer = dealer;
                group.Name = groupName;
                group.Names.Clear();
                group.Names["ru-RU"] = groupRusName;
                group.Names["uk-UA"] = groupUkrName;
                group.Enabled = enabled;
                context.AddToGroups(group);
                context.SaveChanges();
                context.UpdateTranslations(group.NamesXml);
            }
            return RedirectToAction("Groups");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateGroups(FormCollection form)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (!string.IsNullOrEmpty(form["updates"]))
            {
                Dictionary<string, Dictionary<string, string>> updates = serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(
                    form["updates"]
                    );
                foreach (string key in updates.Keys)
                {
                    int itemId = int.Parse(key);
                    Dictionary<string, string> translations = updates[key];
                    List<TranslationItem> translationItems = new List<TranslationItem>();
                    translationItems = (from tr in translations select new TranslationItem { ItemId = itemId, ItemType = ItemTypes.Group, Language = tr.Key, Translation = tr.Value }).ToList();
                    string translationXml = Utils.CreateTranslationXml(translationItems);
                    using (ZamovStorage context = new ZamovStorage())
                    {
                        context.UpdateTranslations(translationXml);
                    }
                }
                if (!string.IsNullOrEmpty(form["enablities"]))
                {
                    Dictionary<string, string> enables = serializer.Deserialize<Dictionary<string, string>>(form["enablities"]);
                    using (ZamovStorage context = new ZamovStorage())
                    {
                        foreach (string key in enables.Keys)
                        {
                            int id = int.Parse(key);
                            Group group = context.Groups.Select(g => g).Where(g => g.Id == id).First();
                            group.Enabled = bool.Parse(enables[key]);
                        }
                        context.SaveChanges(true);
                    }
                }
            }
            return RedirectToAction("Groups");
        }

        public ActionResult DeleteGroup(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Group group = context.Groups.Select(g => g).Where(g => g.Id == id).First();
                context.DeleteObject(group);
                context.SaveChanges();
                context.DeleteTranslations(id, (int)ItemTypes.Group);
            }
            return RedirectToAction("Groups");
        }
        #endregion

        #region Dealer
        public ActionResult AddUpdateDealer()
        {

            int id = Security.GetCurentDealerId(User.Identity.Name);
            if (id > 0)
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    Dealer dealer = context.Dealers.Select(d => d).Where(d => d.Id == id).First();
                    ViewData["dealer"] = dealer;
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddUpdateDealer(FormCollection form)
        {
            int dealerId = Security.GetCurentDealerId(User.Identity.Name);
            Dealer dealer = null;
            using (ZamovStorage context = new ZamovStorage())
            {
                if (dealerId >= 0)
                    dealer = context.Dealers.Select(d => d).Where(d => d.Id == dealerId).First();
                else
                    dealer = new Dealer();
                dealer.Name = form["name"];
                dealer.Names["ru-RU"] = form["rName"];
                dealer.Names["uk-UA"] = form["uName"];
                dealer.Descriptions["ru-RU"] = Server.HtmlDecode(form["rDescription"]);
                dealer.Descriptions["uk-UA"] = Server.HtmlDecode(form["uDescription"]);
                dealer.Enabled = form["enabled"].Contains("true");
                if (!string.IsNullOrEmpty(Request.Files["logoImage"].FileName))
                {
                    HttpPostedFileBase file = Request.Files["logoImage"];
                    dealer.LogoType = file.ContentType;
                    BinaryReader reader = new BinaryReader(file.InputStream);
                    dealer.LogoImage = reader.ReadBytes((int)file.InputStream.Length);
                }
                if (dealerId < 0)
                    context.AddToDealers(dealer);
                context.SaveChanges();
                context.UpdateTranslations(dealer.NamesXml);
                context.UpdateTranslations(dealer.DescriptionsXml);
            }
            return RedirectToAction("Dealers");
        }
        #endregion

        #region Products
        public ActionResult Products(int? id)
        {
            ZamovStorage context = new ZamovStorage();
            int dealerId = Security.GetCurentDealerId(User.Identity.Name);
            List<Product> products = new List<Product>();
            if (id != null)
            {
                products = (from product in context.Products 
                            where product.Group.Id == id.Value && product.Dealer.Id == dealerId
                            select product).ToList();
            }
            List<SelectListItem> items = new List<SelectListItem>();
            int currentGroupId = (id) ?? int.MinValue;
            GetGroupItems(items, dealerId, int.MinValue, "", currentGroupId);
            ViewData["groups"] = items;
            ViewData["groupId"] = currentGroupId;
            return View(products);
        }

        public ActionResult AddProduct(string partNumber, string name, decimal price, bool active, int groupId)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Product product = new Product();
                int dealerId = Security.GetCurentDealerId(User.Identity.Name);
                IEnumerable<KeyValuePair<string, object>> dealerKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", dealerId) };
                EntityKey dealer = new EntityKey("ZamovStorage.Dealers", dealerKeyValues);
                product.DealerReference.EntityKey = dealer;
                IEnumerable<KeyValuePair<string, object>> groupKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", groupId) };
                EntityKey group = new EntityKey("ZamovStorage.Groups", groupKeyValues);
                product.GroupReference.EntityKey = group;
                product.PartNumber = partNumber;
                product.Name = name;
                product.Price = price;
                product.Enabled = active;
                context.AddToProducts(product);
                context.SaveChanges();
            }
            string url = Url.Action("Products", "DealerCabinet", new { id = groupId });
            return Redirect(url);
        }

        private void GetGroupItems(List<SelectListItem> items, int dealerId, int groupId, string prefix, int currentGroipId)
        {

            if (groupId < 0)
                items.Add(new SelectListItem { Selected = currentGroipId < 0, Text = Resources.GetResourceString("SelectGroup"), Value = "" });
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Group> groups = new List<Group>();
                string cacheKey = "dId_" + dealerId + "gId" + groupId;
                if (Cache[cacheKey] != null)
                    groups = (List<Group>)Cache[cacheKey];
                else
                {
                    if (groupId > 0)
                        groups = (from g in context.Groups where g.Dealer.Id == dealerId && g.Parent.Id == groupId select g).ToList();
                    else
                        groups = (from g in context.Groups where g.Dealer.Id == dealerId && g.Parent == null select g).ToList();
                    Cache[cacheKey] = groups;
                }
                foreach (var g in groups)
                {
                    SelectListItem listItem = new SelectListItem
                    {
                        Selected = (g.Id == currentGroipId),
                        Text = prefix + " " + g.GetName(SystemSettings.CurrentLanguage),
                        Value = g.Id.ToString()
                    };
                    items.Add(listItem);
                    if(!g.Groups.IsLoaded)
                        g.Groups.Load();
                    if (g.Groups != null && g.Groups.Count > 0)
                        GetGroupItems(items, dealerId, g.Id, prefix + "--", currentGroipId);
                }
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UpdateProductDescription(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Product product = (from p in context.Products where p.Id == id select p).First();
                product.LoadDescriptions();
                ViewData["descroptionUkr"] = product.GetDescription("uk-UA");
                ViewData["descroptionRus"] = product.GetDescription("ru-RU");
                ViewData["productId"] = id;
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void UpdateProductDescription(int productId, string descroptionUkr, string descroptionRus)
        {
            TranslationItem ukrItem = new TranslationItem
            {
                ItemId = productId,
                ItemType = ItemTypes.ProductDescription,
                Language = "uk-UA",
                Translation = Server.HtmlDecode(descroptionUkr)
            };

            TranslationItem rusItem = new TranslationItem
            {
                ItemId = productId,
                ItemType = ItemTypes.ProductDescription,
                Language = "ru-RU",
                Translation = Server.HtmlDecode(descroptionRus)
            };

            List<TranslationItem> items = new List<TranslationItem>();
            items.Add(ukrItem);
            items.Add(rusItem);
            using (ZamovStorage context = new ZamovStorage())
                context.UpdateTranslations(Utils.CreateTranslationXml(items));
            Response.Write("<script type=\"text/javascript\">top.closeDescriptionDialog();</script>");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UpdateProductImage(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                ProductImage image = context.ProductImages.Select(pi => pi).Where(pi => pi.Product.Id == id).SingleOrDefault();
                int imageId = (image != null) ? image.Id : int.MinValue;
                ViewData["imageId"] = imageId;
                ViewData["productId"] = id;
                return View();
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public void UpdateProductImage(int id, int productId)
        {
            if (!string.IsNullOrEmpty(Request.Files["newImage"].FileName))
            {
                ProductImage image = null;
                image = new ProductImage();
                IEnumerable<KeyValuePair<string, object>> productKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", productId) };
                EntityKey product = new EntityKey("ZamovStorage.Products", productKeyValues);
                image.ProductReference.EntityKey = product;
                HttpPostedFileBase file = Request.Files["newImage"];
                image.ImageType = file.ContentType;
                BinaryReader reader = new BinaryReader(file.InputStream);
                image.Image = reader.ReadBytes((int)file.InputStream.Length);
                using (ZamovStorage context = new ZamovStorage())
                {
                    context.CleanupProductImages(productId);
                    context.AddToProductImages(image);
                    context.SaveChanges();
                }
            }
            Response.Write("<script type=\"text/javascript\">top.closeImageDialog();</script>");
        }

        public ActionResult UpdateProducts(int groupId, string changes)
        {
            if (!string.IsNullOrEmpty(changes))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, Dictionary<string, string>> updates = serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(changes);
                using (ZamovStorage context = new ZamovStorage())
                    context.UpdateProducts(updates.CreateUpdatesXml());
            }
            return Redirect("~/DealerCabinet/Products/" + groupId);
        }
        #endregion

        #region Products import
        public ActionResult ImportedProducts()
        {
            string fileName = (string)Session["uploadedXls"];
            List<Dictionary<string, string>> importedProductsSet = Utils.QureyUploadedXls(fileName, SystemSettings.CurrentDealer.Value);
            List<Dictionary<string, string>> updatedItems = (from item in importedProductsSet where item["productId"] != null select item).ToList();
            List<Dictionary<string, string>> newItems = (from item in importedProductsSet where item["productId"] == null select item).ToList();
            int productId = 1;
            foreach (var item in newItems)
            {
                item["productId"] = productId.ToString();
                productId++;
            }
            Dictionary<string, Dictionary<string, string>> updatedItemsDictionary = updatedItems.ToDictionary(el => (string)el["productId"], el => el);
            Dictionary<string, Dictionary<string, string>> newItemsDictionary = newItems.ToDictionary(el => (string)el["productId"], el => el);
            ViewData["updatedItems"] = updatedItems;
            ViewData["newItems"] = newItems;
            Session["updatedItems"] = updatedItemsDictionary;
            Session["newItems"] = newItemsDictionary;
            return View();
        }

        public ActionResult ImportedProduct(Dictionary<string, string> product, bool isNew)
        {
            int productId = int.Parse(product["productId"]);
            int? groupId = null;
            if (product["groupId"] != null)
                groupId = int.Parse(product["groupId"]);
            string partNumber = (string)product["partNumber"];
            string name = (string)product["name"];
            string price = (string)product["price"];
            string ukDescription = (string)product["ukDescription"];
            string ruDescription = (string)product["ruDescription"];
            List<SelectListItem> items = new List<SelectListItem>();
            int currentGroupId = (groupId) ?? int.MinValue;
            string cacheKey = "ImportedProduct_DealerId=" + SystemSettings.CurrentDealer.Value;
            if (Cache[cacheKey] != null)
                items = (List<SelectListItem>)Cache[cacheKey];
            else
            {
                GetGroupItems(items, SystemSettings.CurrentDealer.Value, int.MinValue, "", currentGroupId);
                Cache[cacheKey] = items;
            }
            ViewData["id"] = productId;
            ViewData["partNumber"] = partNumber;
            ViewData["name"] = name;
            decimal decimalPrice = 0;
            if (!decimal.TryParse(price, out decimalPrice))
                decimalPrice = 0M;
            ViewData["price"] = decimalPrice;
            ViewData["ukDescription"] = ukDescription;
            ViewData["ruDescription"] = ruDescription;
            ViewData["groupList"] = items;
            ViewData["isNew"] = isNew;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadXls()
        {
            if (!string.IsNullOrEmpty(Request.Files["xls"].FileName))
            {
                string fileName = Request.Files["xls"].FileName;
                string extension = Path.GetExtension(fileName);
                if (extension != ".xls" && extension != ".xlsx")
                    return RedirectToAction("UploadXlsError");
                int hashcode = User.GetHashCode();
                Request.Files["xls"].SaveAs(Server.MapPath("~/UploadedFiles/" + hashcode + "_Imported" + extension));
                Session["uploadedXls"] = Server.MapPath("~/UploadedFiles/" + hashcode + "_Imported" + extension);
                return RedirectToAction("ImportedProducts");
            }
            else
                return RedirectToAction("UploadXlsError");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveImportedProducts(string newItemUpdates, string updatedItemUpdates)
        {
            string fileName = (string)Session["uploadedXls"];
            System.IO.File.Delete(fileName);
            Dictionary<string, Dictionary<string, string>> updatedItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["updatedItems"];
            Dictionary<string, Dictionary<string, string>> newItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["newItems"];

            if (!string.IsNullOrEmpty(newItemUpdates))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, Dictionary<string, string>> newUpdates = serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(newItemUpdates);
                foreach (string key in newUpdates.Keys)
                {
                    Dictionary<string, string> update = newUpdates[key];
                    foreach (string updateKey in update.Keys)
                        newItemsDictionary[key][updateKey] = update[updateKey];
                }
            }

            if (!string.IsNullOrEmpty(updatedItemUpdates))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, Dictionary<string, string>> updatedUpdates = serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(updatedItemUpdates);
                foreach (string key in updatedUpdates.Keys)
                {
                    Dictionary<string, string> update = updatedUpdates[key];
                    foreach (string updateKey in update.Keys)
                        updatedItemsDictionary[key][updateKey] = update[updateKey];
                }
            }

            string updatesXml = updatedItemsDictionary.CreateUpdatesXml();
            string newItemsXml = newItemsDictionary.CreateUpdatesXml();
            using (ZamovStorage context = new ZamovStorage())
            {
                context.InsertImportedProducts(newItemsXml, SystemSettings.CurrentDealer.Value);
                context.UpdateImportedProducts(updatesXml);
            }
            Session["uploadedXls"] = null;
            return RedirectToAction("Products");
        }
        #endregion

        #region DealerMappings
        public ActionResult DealerCityMappings()
        {
            int dealerId = SystemSettings.CurrentDealer.Value;
            List<City> cities = null;
            List<City> dealerCities = null;
            using (ZamovStorage context = new ZamovStorage())
            {
                cities = (from city in context.Cities select city).ToList();
                dealerCities = (from dealer in context.Dealers where dealer.Id == dealerId select dealer.Cities).First().ToList();
            }
            List<SelectListItem> items = (from city in cities
                                          select new SelectListItem
                                          {
                                              Text = city.GetName(SystemSettings.CurrentLanguage),
                                              Value = city.Id.ToString(),
                                              Selected =
                                                (from dc in dealerCities where dc.Id == city.Id select dc).Count() > 0
                                          }).ToList();
            ViewData["items"] = items;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void DealerCityMappings(FormCollection form)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer dealer = (from d in context.Dealers where d.Id == SystemSettings.CurrentDealer.Value select d).First();
                dealer.Cities.Load();
                dealer.Cities.Clear();
                foreach (string key in form.Keys)
                {
                    if (form[key].IndexOf("true") > -1)
                    {
                        int cityId = int.Parse(key);
                        City city = (from c in context.Cities where c.Id == cityId select c).First();
                        dealer.Cities.Add(city);
                    }
                }
                context.SaveChanges();
            }
            Response.Write("<script>top.closeCityMappings();</script>");
        }

        public ActionResult DealerCategoryMappings()
        {
            int dealerId = SystemSettings.CurrentDealer.Value;
            List<Category> categories = null;
            List<Category> dealerCategories = null;
            using (ZamovStorage context = new ZamovStorage())
            {
                categories = (from category in context.Categories select category).ToList();
                dealerCategories = (from dealer in context.Dealers where dealer.Id == dealerId select dealer.Categories).First().ToList();
            }
            List<SelectListItem> items = (from category in categories
                                          select new SelectListItem
                                          {
                                              Text = category.GetName(SystemSettings.CurrentLanguage),
                                              Value = category.Id.ToString(),
                                              Selected =
                                                (from dc in dealerCategories where dc.Id == category.Id select dc).Count() > 0
                                          }).ToList();
            ViewData["items"] = items;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void DealerCategoryMappings(FormCollection form)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer dealer = (from d in context.Dealers where d.Id == SystemSettings.CurrentDealer.Value select d).First();
                dealer.Categories.Load();
                dealer.Categories.Clear();
                foreach (string key in form.Keys)
                {
                    if (form[key].IndexOf("true") > -1)
                    {
                        int categoryId = int.Parse(key);
                        Category category = (from c in context.Categories where c.Id == categoryId select c).First();
                        dealer.Categories.Add(category);
                    }
                }
                context.SaveChanges();
            }
            Response.Write("<script>top.closeCategoryMappings();</script>");
        }

        #endregion

        [Authorize(Roles = "Administrators")]
        public ActionResult SelectDealer(int currentDealerId, string redirectTo)
        {
            SystemSettings.CurrentDealer = currentDealerId;
            return Redirect(redirectTo);
        }

        [Authorize(Roles = "Administrators, Dealers")]
        public ActionResult Orders()
        {
            using (OrderStorage context = new OrderStorage())
            {
                List<Order> orders = (
                                         from order in
                                             context.Orders.Include("Dealers")
                                         where order.Dealers.Id == SystemSettings.CurrentDealer
                                         select order).ToList();
                return View(orders);
            }
        }

        [Authorize(Roles = "Administrators, Dealers")]
        public ActionResult ShowOrder(int id)
        {
            using (OrderStorage context = new OrderStorage())
            {
                Order order = (from o in context.Orders.Include("OrderItems") where o.Id == id select o).First();
                return View(order);

                /*List<Order> orders = (from order in context.Orders.Include("OrderItems") where order.Id == id select order).ToList();
                return View(orders);*/
            }
        }
    }
}