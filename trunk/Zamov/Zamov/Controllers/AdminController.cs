//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.Security;
using System.Data;
using Zamov.Helpers;
using System;
using System.Globalization;

namespace Zamov.Controllers
{
    [Authorize(Roles = "Administrators")]
    [BreadCrumb(ResourceName = "Administration", Url = "/Admin")]
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        #region Cities
        [BreadCrumb(ResourceName = "Cities", Url = "/Admin/Cities")]
        public ActionResult Cities()
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<City> cities = context.Cities.Select(c => c).ToList();
                return View(cities);
            }
        }

        public ActionResult DeleteCity(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                City city = (from c in context.Cities where c.Id == id select c).First();
                context.DeleteObject(city);
                context.SaveChanges();
                context.DeleteTranslations(id, (int)ItemTypes.City);
            }
            return RedirectToAction("Cities");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InsertCity(FormCollection form)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                City city = new City();
                city.Name = form["cityName"];
                city.Names.Clear();
                city.Names["ru-RU"] = form["cityRusName"];
                city.Names["uk-UA"] = form["cityUkrName"];
                city.Enabled = form["cityEnabled"].Contains("true");
                context.AddToCities(city);
                context.SaveChanges();
                context.UpdateTranslations(city.NamesXml);
            }
            return RedirectToAction("Cities");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateCities(FormCollection form)
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
                    translationItems = (from tr in translations select new TranslationItem { ItemId = itemId, ItemType = ItemTypes.City, Language = tr.Key, Translation = tr.Value }).ToList();
                    string translationXml = Utils.CreateTranslationXml(translationItems);
                    using (ZamovStorage context = new ZamovStorage())
                    {
                        context.UpdateTranslations(translationXml);
                    }
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
                        City city = context.Cities.Select(c => c).Where(c => c.Id == id).First();
                        city.Enabled = bool.Parse(enables[key]);
                    }
                    context.SaveChanges(true);
                }
            }
            return RedirectToAction("Cities");
        }
        #endregion

        #region Dealers
        [BreadCrumb(ResourceName = "Dealers", Url = "/Admin/Dealers")]
        public ActionResult Dealers()
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Dealer> dealers = context.Dealers.Select(d => d).ToList();
                return View(dealers);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Dealers(FormCollection form)
        {
            PostData postData = form.ProcessPostData();

            Func<string, int?> getNullableInt = (str =>
            {
                if (string.IsNullOrEmpty(str))
                    return null;
                return int.Parse(str);
            });

            var dealerUpdates = (from pd in postData
                                 select new
                                 {
                                     Id = int.Parse(pd.Key),
                                     Top = pd.Value["top"].Contains("true"),
                                     Enabled = pd.Value["enabled"].Contains("true"),
                                     OrderLifeTime = getNullableInt(pd.Value["orderLifeTime"])
                                 });

            using (ZamovStorage context = new ZamovStorage())
            {
                List<Dealer> dealers = (from dealer in context.Dealers select dealer).ToList();
                dealers.ForEach(d =>
                {
                    d.TopDealer = (from du in dealerUpdates where du.Id == d.Id select du.Top).First();
                    d.Enabled = (from du in dealerUpdates where du.Id == d.Id select du.Enabled).First();
                    d.OrderLifeTime = (from du in dealerUpdates where du.Id == d.Id select du.OrderLifeTime).First();
                });
                context.SaveChanges();
            }
            return RedirectToAction("Dealers");
        }

        public ActionResult DeleteDealer(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer dealer = (from d in context.Dealers where d.Id == id select d).First();
                context.DeleteObject(dealer);
                context.SaveChanges();
            }
            return RedirectToAction("Dealers");
        }

        public ActionResult AddUpdateDealer(int id)
        {
            string bcText = ResourcesHelper.GetResourceString("CreateDealer");
            if (id > 0)
            {
                bcText = ResourcesHelper.GetResourceString("EditDealer");
                using (ZamovStorage context = new ZamovStorage())
                {
                    Dealer dealer = context.Dealers.Select(d => d).Where(d => d.Id == id).First();
                    ViewData["dealer"] = dealer;
                }
            }
            BreadCrumbsExtensions.AddBreadCrumb(HttpContext, bcText, "/Admin/AddUpdateDealer/" + id);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddUpdateDealer(FormCollection form)
        {
            int dealerId = int.Parse(form["dealerId"]);
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

        #region Categories
        [BreadCrumb(ResourceName = "Categories", Url = "/Admin/Categories")]
        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult CategoriesList(int? id, int level)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Category> categories = context.Categories.Select(c => c).ToList();
                if (id == null)
                    categories = categories.Select(c => c).Where(c => c.Parent == null).ToList();
                else
                    categories = categories.Select(c => c).Where(c => c.Parent != null && c.Parent.Id == id.Value).ToList();
                ViewData["level"] = level;
                if (id != null)
                    ViewData["id"] = id.Value;
                return View(categories);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateCategories(FormCollection form)
        {

            Dictionary<string, Dictionary<string, string>> updates = form.ProcessPostData("enablities");// serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(

            foreach (string key in updates.Keys)
            {
                int itemId = int.Parse(key);
                Dictionary<string, string> translations = updates[key];
                List<TranslationItem> translationItems = new List<TranslationItem>();
                translationItems = (from tr in translations where !tr.Key.StartsWith("sub") select new TranslationItem { ItemId = itemId, ItemType = ItemTypes.Category, Language = tr.Key, Translation = tr.Value }).ToList();
                List<TranslationItem> subcategoryNames = (from tr in translations where tr.Key.StartsWith("sub") select new TranslationItem { ItemId = itemId, ItemType = ItemTypes.SubCategoriesName, Language = tr.Key.Replace("sub", ""), Translation = tr.Value }).ToList();
                translationItems.AddRange(subcategoryNames);
                string translationXml = Utils.CreateTranslationXml(translationItems);
                using (ZamovStorage context = new ZamovStorage())
                {
                    context.UpdateTranslations(translationXml);
                }
            }

            if (!string.IsNullOrEmpty(form["enablities"]))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, string> enables = serializer.Deserialize<Dictionary<string, string>>(form["enablities"]);
                using (ZamovStorage context = new ZamovStorage())
                {
                    foreach (string key in enables.Keys)
                    {
                        int id = int.Parse(key);
                        Category category = context.Categories.Select(c => c).Where(c => c.Id == id).First();
                        category.Enabled = bool.Parse(enables[key]);
                    }
                    context.SaveChanges(true);
                }
            }
            HttpContext.Cache.ClearCategoriesCache();
            return RedirectToAction("Categories");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InsertCategory(FormCollection form)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                int parentId = int.Parse(form["parentId"]);
                Category parent = null;
                if (parentId >= 0)
                    parent = context.Categories.Select(c => c).Where(c => c.Id == parentId).First();
                Category category = new Category();
                category.Parent = parent;
                category.Name = form["categoryUkrName"];
                category.Names.Clear();
                category.Names["ru-RU"] = form["categoryRusName"];
                category.Names["uk-UA"] = form["categoryUkrName"];
                category.Enabled = form["categoryEnabled"].ToLowerInvariant().IndexOf("true") > -1;
                context.AddToCategories(category);
                context.SaveChanges();
                context.UpdateTranslations(category.NamesXml);
            }
            HttpContext.Cache.ClearCategoriesCache();
            return RedirectToAction("Categories");
        }

        public ActionResult DeleteCategory(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Category category = (from c in context.Categories where c.Id == id select c).First();
                context.DeleteObject(category);

                context.SaveChanges();
                context.DeleteTranslations(id, (int)ItemTypes.Category);
            }
            return RedirectToAction("Categories");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UpdateCategoryImage(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                CategoryImage image = context.CategoryImages.Select(pi => pi).Where(pi => pi.Category.Id == id).SingleOrDefault();
                int imageId = (image != null) ? image.Id : int.MinValue;
                ViewData["imageId"] = imageId;
                ViewData["categoryId"] = id;
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void UpdateCategoryImage(int id, int categoryId)
        {
            if (!string.IsNullOrEmpty(Request.Files["newImage"].FileName))
            {
                CategoryImage image = null;
                image = new CategoryImage();
                IEnumerable<KeyValuePair<string, object>> productKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", categoryId) };
                EntityKey product = new EntityKey("ZamovStorage.Categories", productKeyValues);
                image.CategoryReference.EntityKey = product;
                HttpPostedFileBase file = Request.Files["newImage"];
                image.ImageType = file.ContentType;
                BinaryReader reader = new BinaryReader(file.InputStream);
                image.Image = reader.ReadBytes((int)file.InputStream.Length);
                using (ZamovStorage context = new ZamovStorage())
                {
                    context.CleanupCategoryImages(categoryId);
                    context.AddToCategoryImages(image);
                    context.SaveChanges();
                }
            }
            Response.Write("<script type=\"text/javascript\">top.closeImageDialog();</script>");
        }
        #endregion

        #region Mappings
        public ActionResult DealerMappings(int id, ItemTypes itemType)
        {
            List<Dealer> dealers = new List<Dealer>();
            using (ZamovStorage context = new ZamovStorage())
            {
                dealers = context.Dealers.Select(d => d).ToList();
            }
            ViewData["id"] = id;
            ViewData["itemType"] = itemType;
            return View(dealers);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void UpdateDealerMappingsMappings()
        {

        }
        #endregion

        #region Users
        [BreadCrumb(ResourceName = "Users", Url = "/Admin/Users")]
        public ActionResult Users(int? pageIndex)
        {
            int totalRecords;
            MembershipUserCollection users;
            if (SystemSettings.UsersPageSize > 0)
            {
                int index = pageIndex ?? 0;
                users = Membership.GetAllUsers(index, SystemSettings.UsersPageSize, out totalRecords);
            }
            else
            {
                users = Membership.GetAllUsers();
                totalRecords = users.Count;
            }
            return View(users);
        }

        public ActionResult UserDetails(MembershipUser user)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                ProfileCommon profile = ProfileCommon.Create(user.UserName);
                int dealerId = profile.DealerId;
                var dealers = (from dealer in context.Dealers select dealer).ToList();
                List<SelectListItem> dealerItems = (from dealer in dealers
                                                    select new SelectListItem
                                                    {
                                                        Text = dealer.GetName(SystemSettings.CurrentLanguage),
                                                        Value = dealer.Id.ToString(),
                                                        Selected = dealer.Id == dealerId
                                                    }).ToList();
                ViewData["dealerId"] = dealerItems;
                return View(user);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateUser(string userName, string firstName, string lastName, bool dealerEmployee, int dealerId)
        {
            ProfileCommon profile = ProfileCommon.Create(userName) as ProfileCommon;
            profile.FirstName = firstName;
            profile.LastName = lastName;

            if (dealerEmployee)
            {
                profile.DealerEmployee = true;
                profile.DealerId = dealerId;
                if (!Roles.IsUserInRole(userName, "Dealers"))
                    Roles.AddUserToRole(userName, "Dealers");
            }
            else
            {
                if (Roles.IsUserInRole(userName, "Dealers"))
                    Roles.RemoveUserFromRole(userName, "Dealers");
                profile.DealerId = int.MinValue;
                profile.DealerEmployee = false;
            }
            profile.Save();
            return RedirectToAction("Users");
        }
        #endregion

        #region ApplicationSettings
        public ActionResult StartText()
        {
            ViewData["ruText"] = ApplicationData.GetStartText("ru-RU");
            ViewData["uaText"] = ApplicationData.GetStartText("uk-UA");
            return View();
        }

        public void UpdateStartText(string ruText, string uaText)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["ru-RU"] = HttpUtility.HtmlDecode(ruText);
            values["uk-UA"] = HttpUtility.HtmlDecode(uaText);
            ApplicationData.UpdateStartText(values);
            Response.Write(Helpers.Helpers.CloseParentScript("StartText"));
        }

        public ActionResult Agreement()
        {
            ViewData["ruText"] = ApplicationData.GetAgreement("ru-RU");
            ViewData["uaText"] = ApplicationData.GetAgreement("uk-UA");
            return View();
        }

        public void UpdateAgreement(string ruText, string uaText)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["ru-RU"] = HttpUtility.HtmlDecode(ruText);
            values["uk-UA"] = HttpUtility.HtmlDecode(uaText);
            ApplicationData.UpdateAgreement(values);
            Response.Write(Helpers.Helpers.CloseParentScript("Agreement"));
        }

        public ActionResult SubCategoryText()
        {
            ViewData["ruText"] = ApplicationData.GetSubCategoryText("ru-RU");
            ViewData["uaText"] = ApplicationData.GetSubCategoryText("uk-UA");
            return View();
        }

        public void UpdateSubCategoryText(string ruText, string uaText)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["ru-RU"] = HttpUtility.HtmlDecode(ruText);
            values["uk-UA"] = HttpUtility.HtmlDecode(uaText);
            ApplicationData.UpdateSubCategoryText(values);
            Response.Write(Helpers.Helpers.CloseParentScript("SubCategoryText"));
        }

        public ActionResult ContactsHeader()
        {
            ViewData["ruText"] = ApplicationData.GetContactsHeader("ru-RU");
            ViewData["uaText"] = ApplicationData.GetContactsHeader("uk-UA");
            return View();
        }

        public void UpdateContactsHeader(string ruText, string uaText)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["ru-RU"] = HttpUtility.HtmlDecode(ruText);
            values["uk-UA"] = HttpUtility.HtmlDecode(uaText);
            ApplicationData.UpdateContactsHeader(values);
            Response.Write(Helpers.Helpers.CloseParentScript("Contacts"));
        }
        #endregion

        #region News
        public ActionResult News()
        {
            using (NewsStorage context = new NewsStorage())
            {
                List<NewsPresentation> news = (from newsItem in context.News
                                               join title in context.Translations on newsItem.Id equals title.ItemId
                                               where title.TranslationItemTypeId == (int)ItemTypes.NewsTitle
                                               && title.Language == SystemSettings.CurrentLanguage
                                               orderby newsItem.Date descending
                                               select new NewsPresentation
                                               {
                                                   Id = newsItem.Id,
                                                   Enabled = newsItem.Enabled,
                                                   Date = newsItem.Date,
                                                   Title = title.Translation
                                               }).ToList();
                return View(news);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult News(FormCollection form)
        {
            PostData updates = form.ProcessPostData();
            using (NewsStorage context = new NewsStorage())
            {
                var news = (from item in context.News select item).ToList();
                foreach (string key in updates.Keys)
                {
                    int itemId = int.Parse(key);
                    bool enabled = bool.Parse(updates[key]["enabled"]);
                    News item = (from n in news where n.Id == itemId select n).First();
                    item.Enabled = enabled;
                }
                context.SaveChanges();
            }
            return RedirectToAction("News");
        }

        public ActionResult DeleteNews(int id)
        {
            using (NewsStorage context = new NewsStorage())
            {
                News item = (from n in context.News where n.Id == id select n).First();
                context.DeleteObject(item);
                context.SaveChanges();
            }
            return RedirectToAction("News");
        }

        public ActionResult AddEditNews(int? id)
        {
            if (id != null)
            {
                using (NewsStorage context = new NewsStorage())
                {
                    var item = (from news in context.News
                                join ruTitle in context.Translations on news.Id equals ruTitle.ItemId
                                join uaTitle in context.Translations on news.Id equals uaTitle.ItemId
                                join ruShortText in context.Translations on news.Id equals ruShortText.ItemId
                                join uaShortText in context.Translations on news.Id equals uaShortText.ItemId
                                join ruLongText in context.Translations on news.Id equals ruLongText.ItemId
                                join uaLongText in context.Translations on news.Id equals uaLongText.ItemId
                                where ruTitle.TranslationItemTypeId == (int)ItemTypes.NewsTitle && ruTitle.Language == "ru-RU"
                                   && uaTitle.TranslationItemTypeId == (int)ItemTypes.NewsTitle && uaTitle.Language == "uk-UA"
                                   && ruShortText.TranslationItemTypeId == (int)ItemTypes.NewsDescription && ruShortText.Language == "ru-RU"
                                   && uaShortText.TranslationItemTypeId == (int)ItemTypes.NewsDescription && uaShortText.Language == "uk-UA"
                                   && ruLongText.TranslationItemTypeId == (int)ItemTypes.NewsText && ruLongText.Language == "ru-RU"
                                   && uaLongText.TranslationItemTypeId == (int)ItemTypes.NewsText && uaLongText.Language == "uk-UA"
                                   && news.Id == id.Value
                                select new
                                {
                                    ruTitle = ruTitle.Translation,
                                    uaTitle = uaTitle.Translation,
                                    ruShortText = ruShortText.Translation,
                                    uaShortText = uaShortText.Translation,
                                    ruLongText = ruLongText.Translation,
                                    uaLongText = uaLongText.Translation,
                                    date = news.Date,
                                    enabled = news.Enabled
                                }
                                    ).First();
                    ViewData["ruTitle"] = item.ruTitle;
                    ViewData["uaTitle"] = item.uaTitle;
                    ViewData["ruShortText"] = item.ruShortText;
                    ViewData["uaShortText"] = item.uaShortText;
                    ViewData["ruLongText"] = item.ruLongText;
                    ViewData["uaLongText"] = item.ruLongText;
                    ViewData["date"] = item.date.ToString("dd.MM.yyyy");
                    ViewData["enabled"] = item.enabled;
                }
            }
            else
                ViewData["date"] = DateTime.Now.ToString("dd.MM.yyyy");
            ViewData["id"] = id;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEditNews(int? id, string uaTitle, string ruTitle, string date, string uaShortText, string ruShortText, string uaLongText, string ruLongText, bool enabled)
        {
            if (ValidateNewsAdd(uaTitle, ruTitle, uaShortText, ruShortText, uaLongText, ruLongText))
            {
                News news = null;
                using (NewsStorage context = new NewsStorage())
                {
                    if (id != null)
                    {
                        news = context.News.Where(n => n.Id == id.Value).Select(n => n).First();
                    }
                    else
                        news = new News();
                    news.Enabled = enabled;
                    CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                    news.Date = DateTime.Parse(date, cultureInfo);
                    if (id == null)
                        context.AddToNews(news);
                    context.SaveChanges();
                }

                List<TranslationItem> translations = new List<TranslationItem>{
                    new TranslationItem{ ItemId = news.Id, ItemType = ItemTypes.NewsTitle, Language="ru-RU", Translation = ruTitle},
                    new TranslationItem{ ItemId = news.Id, ItemType = ItemTypes.NewsTitle, Language="uk-UA", Translation = uaTitle},
                    new TranslationItem{ ItemId = news.Id, ItemType = ItemTypes.NewsDescription, Language="ru-RU", Translation = Server.HtmlDecode(ruShortText)},
                    new TranslationItem{ ItemId = news.Id, ItemType = ItemTypes.NewsDescription, Language="uk-UA", Translation = Server.HtmlDecode(uaShortText)},
                    new TranslationItem{ ItemId = news.Id, ItemType = ItemTypes.NewsText, Language="ru-RU", Translation = Server.HtmlDecode(ruLongText)},
                    new TranslationItem{ ItemId = news.Id, ItemType = ItemTypes.NewsText, Language="uk-UA", Translation = Server.HtmlDecode(uaLongText)}
                };
                using (ZamovStorage context = new ZamovStorage())
                    context.UpdateTranslations(Utils.CreateTranslationXml(translations));
                return RedirectToAction("News");
            }
            else
                return View();
        }

        private bool ValidateNewsAdd(string uaTitle, string ruTitle, string uaShortText, string ruShortText, string uaLongText, string ruLongText)
        {
            if (string.IsNullOrEmpty(uaTitle) || string.IsNullOrEmpty(ruTitle))
                ModelState.AddModelError("title", "");
            if (string.IsNullOrEmpty(uaShortText) || string.IsNullOrEmpty(ruShortText))
                ModelState.AddModelError("shortText", "");
            if (string.IsNullOrEmpty(ruLongText) || string.IsNullOrEmpty(uaLongText))
                ModelState.AddModelError("longText", "");
            return ModelState.IsValid;
        }
        #endregion

        #region StartupTools
        public ActionResult RemoveDealers()
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<DealerPresentation> dealers = (from dealer in context.Dealers
                                                    join name in context.Translations on dealer.Id equals name.ItemId
                                                    where name.TranslationItemTypeId == (int)ItemTypes.DealerName
                                                    && name.Language == SystemSettings.CurrentLanguage
                                                    select new DealerPresentation
                                                    {
                                                        Name = name.Text,
                                                        Id = dealer.Id,
                                                        Enabled = dealer.Enabled
                                                    }
                                                    ).ToList();
                return View(dealers);
            }
        }

        public ActionResult RemoveDealer(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                context.RemoveDealer(id);
            }
            return RedirectToAction("RemoveDealers");
        }
        #endregion

        #region Orders
        public ActionResult ExpireOrders()
        {
            using (ZamovStorage context = new ZamovStorage())
                context.ExpireOrders();
            return RedirectToAction("Index");
        }
        #endregion
    }
}