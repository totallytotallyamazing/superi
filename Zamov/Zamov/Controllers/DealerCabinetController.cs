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
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.Objects;

namespace Zamov.Controllers
{
    [Authorize(Roles = "Administrators, Dealers")]
    [BreadCrumb(ResourceName = "DealerCabinet", Url = "/DealerCabinet")]
    [UpdateCurrentDealer]
    public class DealerCabinetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Groups
        [BreadCrumb(ResourceName = "Groups", Url = "/DealerCabinet/Groups")]
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
                    groups = groups.Select(g => g).Where(g => g.Parent == null && !g.Deleted).ToList();
                else
                    groups = groups.Select(g => g).Where(g => g.Parent != null && g.Parent.Id == id.Value && !g.Deleted).ToList();
                ViewData["level"] = level;
                return View(groups);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InsertGroup(string groupName, string groupUkrName, string groupRusName, bool enabled, int parentId)
        {
            ClearGroupCache();

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
                group.Name = groupUkrName;
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
            ClearGroupCache();

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

        private void ClearGroupCache()
        {
            string cacheKey = "dId_" + SystemSettings.CurrentDealer;
            List<string> cacheKeys = new List<string>();
            IDictionaryEnumerator enumerator = HttpContext.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().StartsWith(cacheKey))
                    cacheKeys.Add(enumerator.Key.ToString());
            }
            foreach (string key in cacheKeys)
                HttpContext.Cache.Remove(key);
        }

        public ActionResult DeleteGroup(int id)
        {
            ClearGroupCache();

            using (ZamovStorage context = new ZamovStorage())
            {
                Group group = context.Groups.Select(g => g).Where(g => g.Id == id).First();
                group.Deleted = true;
                context.SaveChanges();
            }
            return RedirectToAction("Groups");
        }
        #endregion

        #region Dealer
        [BreadCrumb(ResourceName = "EditDealer", Url = "/DealerCabinet/AddUpdateDealer")]
        public ActionResult AddUpdateDealer()
        {

            int id = Security.GetCurentDealerId(User.Identity.Name);
            if (id > 0)
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    Dealer dealer = context.Dealers.Select(d => d).Where(d => d.Id == id).First();
                    ViewData["dealer"] = dealer;
                    ViewData["hasDiscounts"] = dealer.HasDiscounts;
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
                dealer.GroupNames["ru-RU"] = form["rGroupName"];
                dealer.GroupNames["uk-UA"] = form["uGroupName"];
                dealer.HasDiscounts = form["hasDiscounts"].Contains("true");
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
                context.UpdateTranslations(dealer.GroupNamesXml);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeliveryInfo()
        {
            int id = Security.GetCurentDealerId(User.Identity.Name);
            if (id > 0)
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    var deliveryInfo = (from ruTran in context.Translations
                                        from uaTran in context.Translations
                                        where ruTran.ItemId == id && uaTran.ItemId == id
                                        && ruTran.Language == "ru-RU" && uaTran.Language == "uk-UA"
                                        && ruTran.TranslationItemTypeId == (int)ItemTypes.DealerDeliveryInfo
                                        && uaTran.TranslationItemTypeId == (int)ItemTypes.DealerDeliveryInfo
                                        select new { RuDeliveryInfo = ruTran.Text, UaDeliveryInfo = uaTran.Text }).SingleOrDefault();
                    if (deliveryInfo != null)
                    {
                        ViewData["deliveryDetailsRus"] = deliveryInfo.RuDeliveryInfo;
                        ViewData["deliveryDetailsUkr"] = deliveryInfo.UaDeliveryInfo;
                    }
                }
            }
            return View();
        }

        public void UpdateDeliveryDetails(string deliveryDetailsUkr, string deliveryDetailsRus)
        {
            TranslationItem ukrItem = new TranslationItem
            {
                ItemId = SystemSettings.CurrentDealer.Value,
                ItemType = ItemTypes.DealerDeliveryInfo,
                Language = "uk-UA",
                Translation = Server.HtmlDecode(deliveryDetailsUkr)
            };

            TranslationItem rusItem = new TranslationItem
            {
                ItemId = SystemSettings.CurrentDealer.Value,
                ItemType = ItemTypes.DealerDeliveryInfo,
                Language = "ru-RU",
                Translation = Server.HtmlDecode(deliveryDetailsRus)
            };

            List<TranslationItem> items = new List<TranslationItem>();
            items.Add(ukrItem);
            items.Add(rusItem);
            using (ZamovStorage context = new ZamovStorage())
                context.UpdateTranslations(Utils.CreateTranslationXml(items));
            Response.Write(Helpers.Helpers.CloseParentScript("DeliveryDetails"));
        }
        #endregion

        #region Products
        [BreadCrumb(ResourceName = "Products", Url = "/DealerCabinet/Products")]
        public ActionResult Products(int? id)
        {
            ZamovStorage context = new ZamovStorage();
            int dealerId = Security.GetCurentDealerId(User.Identity.Name);
            List<Product> products = new List<Product>();
            if (id != null && id>0)
            {
                products = (from product in context.Products
                            where product.Group.Id == id.Value && product.Dealer.Id == dealerId && !product.Deleted
                            select product).ToList();
            }
            else if (id == 0)
            {
                products = (from product in context.Products
                            where product.Dealer.Id == dealerId && !product.Deleted
                            select product).ToList();
            }
            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> moveToItems = new List<SelectListItem>();
            int currentGroupId = (id) ?? int.MinValue;
            GetGroupItems(items, dealerId, int.MinValue, "", currentGroupId);
            GetGroupItems(moveToItems, dealerId, int.MinValue, "", currentGroupId);
            moveToItems.RemoveAt(0);
            items.Insert(1, new SelectListItem { Value = "0", Text = ResourcesHelper.GetResourceString("AllProducts") });
            ViewData["groups"] = items;
            ViewData["moveToGroups"] = moveToItems;
            ViewData["groupId"] = currentGroupId;
            return View(products);
        }

        public ActionResult AddProduct(string partNumber, string name, decimal price, bool active, int groupId, string unit)
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
                product.Unit = unit;
                context.AddToProducts(product);
                context.SaveChanges();
            }
            string url = Url.Action("Products", "DealerCabinet", new { id = groupId });
            return Redirect(url);
        }

        public ActionResult DeleteProduct(int productId, int groupId)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Product currentProduct = (from product in context.Products where product.Id == productId select product).First();
                currentProduct.Deleted = true;
                context.SaveChanges();
            }
            string url = Url.Action("Products", "DealerCabinet", new { id = groupId });
            return Redirect(url);
        }

        private void GetGroupItems(List<SelectListItem> items, int dealerId, int groupId, string prefix, int? currentGroupId)
        {

            if (groupId < 0)
                items.Add(new SelectListItem { Selected = currentGroupId == null, Text = ResourcesHelper.GetResourceString("SelectGroup"), Value = "" });
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Group> groups = new List<Group>();
                string cacheKey = "dId_" + dealerId + "gId" + groupId;
                if (HttpContext.Cache[cacheKey] != null)
                    groups = (List<Group>)HttpContext.Cache[cacheKey];
                else
                {
                    if (groupId > 0)
                        groups = (from g in context.Groups where g.Dealer.Id == dealerId && g.Parent.Id == groupId && !g.Deleted select g).ToList();
                    else
                        groups = (from g in context.Groups where g.Dealer.Id == dealerId && g.Parent == null && !g.Deleted select g).ToList();
                    HttpContext.Cache[cacheKey] = groups;
                }
                foreach (var g in groups)
                {
                    SelectListItem listItem = new SelectListItem
                    {
                        Selected = (g.Id == currentGroupId),
                        Text = prefix + " " + g.GetName(SystemSettings.CurrentLanguage),
                        Value = g.Id.ToString()
                    };
                    items.Add(listItem);
                    if (!g.Groups.IsLoaded)
                        g.Groups.Load();
                    if (g.Groups != null && g.Groups.Count > 0)
                        GetGroupItems(items, dealerId, g.Id, prefix + "--", currentGroupId);
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
                Image uploadedImage = Image.FromStream(file.InputStream);

                const int maxDimension = 300;
                int width;
                int height;
                if (uploadedImage.Width > uploadedImage.Height)
                {
                    width = maxDimension;
                    height = (maxDimension * uploadedImage.Height) / uploadedImage.Width;

                }
                else if (uploadedImage.Height > uploadedImage.Width)
                {
                    height = maxDimension;
                    width = (maxDimension * uploadedImage.Width) / uploadedImage.Height;
                }
                else
                    width = height = maxDimension;
                Bitmap bitmap = new Bitmap(width, height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(uploadedImage, 0, 0, width, height);
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Jpeg);
                stream.Seek(0, SeekOrigin.Begin);
                BinaryReader reader = new BinaryReader(stream);
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

        public ActionResult UpdateProducts(FormCollection form)
        {
            PostData postData = form.ProcessPostData("groupId", "groups");
            PostData updates = new PostData();
            foreach (var item in postData)
                updates.Add(item.Key, item.Value.Where(v => v.Key != "moveTo").ToDictionary(v => v.Key, v => v.Value));
            int groupId = int.Parse(form["groupId"]);

            int moveToGroup = 0;
            using (ZamovStorage context = new ZamovStorage())
            {
                context.UpdateProducts(updates.CreateUpdatesXml());

                if (int.TryParse(form["groups"], out moveToGroup))
                {
                    List<int> moverProducts = new List<int>();
                    foreach (var item in postData)
                    {
                        if (item.Value["moveTo"] == "true")
                            moverProducts.Add(int.Parse(item.Key));
                    }
                    if (moverProducts.Count > 0)
                    {
                        string[] movedProductsArray = moverProducts.Select(i => i.ToString()).ToArray();
                        string productIds = string.Join(",", movedProductsArray);

                        ObjectQuery<Product> productsQuery = new ObjectQuery<Product>(
                                    "SELECT VALUE P FROM Products AS P WHERE P.Id IN {" + productIds + "}",
                                    context);
                        Group group = context.Groups.Where(g => g.Id == moveToGroup).Select(g => g).First();

                        foreach (Product product in productsQuery)
                            product.Group = group;
                        context.SaveChanges();
                    }
                }
            }
            return Redirect("~/DealerCabinet/Products/" + groupId);
        }
        #endregion

        #region Products import

        [BreadCrumb(ResourceName = "ImportedProducts", Url = "/DealerCabinet/ImportedProducts")]
        public ActionResult ImportedProducts(int? groupId)
        {
            bool processData = false;

            Dictionary<string, Dictionary<string, string>> updatedItemsDictionary = null;
            Dictionary<string, Dictionary<string, string>> newItemsDictionary = null;

            if (Session["uploadedXls"] != null)
            {
                string fileName = (string)Session["uploadedXls"];
                List<Dictionary<string, string>> importedProductsSet = Utils.QureyUploadedXls(fileName, SystemSettings.CurrentDealer.Value, groupId);
                List<Dictionary<string, string>> updatedItems = (from item in importedProductsSet where item["productId"] != null select item).ToList();
                List<Dictionary<string, string>> newItems = (from item in importedProductsSet where item["productId"] == null select item).ToList();

                newItems.ForEach(i => i["productId"] = (-i.GetHashCode()).ToString());
                System.IO.File.Delete(fileName);
                Session["uploadedXls"] = null;
                updatedItemsDictionary = updatedItems.ToDictionary(el => (string)el["productId"], el => el);
                newItemsDictionary = newItems.ToDictionary(el => (string)el["productId"], el => el);
                Session["updatedItems"] = updatedItemsDictionary;
                Session["newItems"] = newItemsDictionary;

                processData = true;
            }
            else if (Session["updatedItems"] != null || Session["newItems"]!=null)
            {
                updatedItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["updatedItems"];
                newItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["newItems"];
                processData = true;
            }
            if (processData)
            {
                List<SelectListItem> items = new List<SelectListItem>();
                string cacheKey = "ImportedProduct_DealerId=" + SystemSettings.CurrentDealer.Value;
                GetGroupItems(items, SystemSettings.CurrentDealer.Value, int.MinValue, "", groupId);
                ViewData["groupItems"] = items;
                ViewData["updatedItems"] = updatedItemsDictionary;
                ViewData["newItems"] = newItemsDictionary;
            }
            return View();
        }

        public ActionResult ImportedProduct(Dictionary<string, string> product, bool isNew)
        {
            int productId = int.Parse(product["productId"]);
            string partNumber = (string)product["partNumber"];
            string name = (string)product["name"];
            string price = (string)product["price"].Replace(",", ".");
            string ukDescription = (string)product["ukDescription"];
            string ruDescription = (string)product["ruDescription"];
            string unit = (string)product["unit"];
            ViewData["id"] = productId;
            ViewData["partNumber"] = partNumber;
            ViewData["name"] = name;
            decimal decimalPrice = 0;
            if (!decimal.TryParse(price, out decimalPrice))
                decimalPrice = 0M;
            ViewData["price"] = decimalPrice;
            ViewData["ukDescription"] = ukDescription;
            ViewData["ruDescription"] = ruDescription;
            ViewData["unit"] = unit;
            ViewData["isNew"] = isNew;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadXls(int? groupId)
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
                return RedirectToAction("ImportedProducts", new { groupId = groupId });
            }
            else
                return RedirectToAction("UploadXlsError");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MoveToNew(FormCollection form, int? groupId)
        {
            PostData postData = form.ProcessPostData("groupId");
            int[] items = (from item in postData where item.Value["check"] == "true" select int.Parse(item.Key)).ToArray();
            Dictionary<string, Dictionary<string, string>> updatedItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["updatedItems"];
            Dictionary<string, Dictionary<string, string>> newItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["newItems"];
            foreach (int id in items)
            {
                Dictionary<string, string> itemToMove = (from item in updatedItemsDictionary where item.Key == id.ToString() select item.Value).First();
                newItemsDictionary.Add((-itemToMove.GetHashCode()).ToString(), itemToMove);
                updatedItemsDictionary.Remove(id.ToString());
            }

            if (updatedItemsDictionary.Count == 0 && newItemsDictionary.Count == 0)
                return RedirectToAction("Products", new { groupId = groupId });

            return RedirectToAction("ImportedProducts", new { groupId = groupId });
        }

        public ActionResult SaveSelectedTo(FormCollection form, int groupItems)
        {
            PostData postData = form.ProcessPostData("groupItems");
            int[] items = (from item in postData where item.Value["check"] == "true" select int.Parse(item.Key)).ToArray();

            Dictionary<string, Dictionary<string, string>> newItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["newItems"];
            Dictionary<string, Dictionary<string, string>> updatedItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["updatedItems"];

            Dictionary<string, Dictionary<string, string>> itemsToMove =
                (from item in newItemsDictionary where items.Contains(int.Parse(item.Key)) select item.Value).ToDictionary(i => i["productId"], i => i);

            foreach (string key in itemsToMove.Keys)
            {
                itemsToMove[key]["groupId"] = groupItems.ToString();
                newItemsDictionary.Remove(key);
            }

            string newItemsXml = itemsToMove.CreateUpdatesXml();

            using (ZamovStorage context = new ZamovStorage())
                context.InsertImportedProducts(newItemsXml, SystemSettings.CurrentDealer.Value);

            if (updatedItemsDictionary.Count == 0 && newItemsDictionary.Count == 0)
                return RedirectToAction("Products", new { groupId = groupItems });

            return RedirectToAction("ImportedProducts", new { groupId = groupItems });
        }

        private ActionResult SaveUpdated(int? groupId)
        {
            Dictionary<string, Dictionary<string, string>> updatedItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["updatedItems"];
            Dictionary<string, Dictionary<string, string>> newItemsDictionary = (Dictionary<string, Dictionary<string, string>>)Session["newItems"];

            string updatesXml = updatedItemsDictionary.CreateUpdatesXml();
            using (ZamovStorage context = new ZamovStorage())
                context.UpdateImportedProducts(updatesXml);

            ((Dictionary<string, Dictionary<string, string>>)Session["updatedItems"]).Clear();

            if (updatedItemsDictionary.Count == 0 && newItemsDictionary.Count == 0)
                return RedirectToAction("Products", new { groupId = groupId });

            return RedirectToAction("ImportedProducts", new { groupId = groupId });
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
            Response.Write(Helpers.Helpers.CloseParentScript("CityMappings"));
        }

        public ActionResult DealerCategoryMappings()
        {
            int dealerId = SystemSettings.CurrentDealer.Value;

            using (ZamovStorage context = new ZamovStorage())
            {
                List<CategoryPresentation> categories = (from category in context.Categories
                                                         join translation in context.Translations on category.Id equals translation.ItemId
                                                         where translation.TranslationItemTypeId == (int)ItemTypes.Category
                                                            && translation.Language == SystemSettings.CurrentLanguage
                                                            && category.Enabled
                                                         select new CategoryPresentation
                                                             {
                                                                 Id = category.Id,
                                                                 Name = translation.Text,
                                                                 Selected = context.Dealers.Include("Categories")
                                                                    .Where(d => d.Id == dealerId)
                                                                    .FirstOrDefault().Categories
                                                                    .Where(c => c.Id == category.Id).Count() > 0,
                                                                 ParentId = (category.Parent != null) ? (int?)category.Parent.Id : null
                                                             }
                                                         ).ToList();

                categories.ForEach(ac => ac.PickChildren(categories));
                List<CategoryPresentation> sortedCategories = categories.Select(c => c).Where(c => c.ParentId == null).ToList();
                return View(sortedCategories);

            }
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
            HttpContext.Cache.ClearCategoriesCache();
            Response.Write(Helpers.Helpers.CloseParentScript("CategoryMappings"));
        }

        #endregion

        #region Payment details
        public ActionResult PaymentDetails()
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer dealer = (from d in context.Dealers where d.Id == SystemSettings.CurrentDealer select d).First();
                ViewData["cash"] = dealer.Cash;
                ViewData["noncash"] = dealer.Noncash;
                ViewData["card"] = dealer.Card;
                ViewData["hasDiscounts"] = dealer.HasDiscounts;
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void PaymentDetails(bool cash, bool noncash, bool card, bool hasDiscounts)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer dealer = (from d in context.Dealers where d.Id == SystemSettings.CurrentDealer select d).First();
                dealer.Cash = cash;
                dealer.Card = card;
                dealer.Noncash = noncash;
                dealer.HasDiscounts = hasDiscounts;
                context.SaveChanges();
            }
            Response.Write(Helpers.Helpers.CloseParentScript("PaymentDetails"));
        }
        #endregion

        [Authorize(Roles = "Administrators")]
        public ActionResult SelectDealer(int currentDealerId, string redirectTo)
        {
            SystemSettings.CurrentDealer = currentDealerId;
            return Redirect(redirectTo);
        }

        #region Ordering
        [Authorize(Roles = "Administrators, Dealers")]
        [BreadCrumb(ResourceName = "Orders", Url = "/DealerCabinet/Orders")]
        public ActionResult Orders()
        {
            SystemSettings.LastTime = DateTime.Now;
            using (OrderStorage context = new OrderStorage())
            {
                List<Order> orders = (
                                         from order in
                                             context.Orders.Include("Dealer").Include("OrderItems")
                                         where order.Dealer.Id == SystemSettings.CurrentDealer
                                         orderby order.Date descending
                                         select order).ToList();

                return View(orders);
            }
        }

        [Authorize(Roles = "Administrators, Dealers")]
        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
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

        [AcceptVerbs(HttpVerbs.Post)]
        public void AcceptOrder(int orderId)
        {
            using (OrderStorage context = new OrderStorage())
            {
                Order order = (from o in context.Orders where o.Id == orderId select o).First();
                order.Status = (int)Statuses.Accepted;
                context.SaveChanges();
                //return RedirectToAction("Orders");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CancelOrder(int orderId)
        {
            using (OrderStorage context = new OrderStorage())
            {
                Order order = (from o in context.Orders where o.Id == orderId select o).First();
                order.Status = (int)Statuses.Canceled;
                context.SaveChanges();
                return RedirectToAction("Orders");
            }
        }
        #endregion
    }
}