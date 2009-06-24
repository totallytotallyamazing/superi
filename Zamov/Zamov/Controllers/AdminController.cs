using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.Security;
using System.Web.Profile;

namespace Zamov.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        #region Cities
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
        public ActionResult Dealers()
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Dealer> dealers = context.Dealers.Select(d => d).ToList();
                return View(dealers);
            }
        }

        public ActionResult AddUpdateDealer(int id)
        {
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

        public ActionResult EnableDealer(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer dealer = (from d in context.Dealers where d.Id == id select d).First();
                dealer.Enabled = true;
                context.SaveChanges();
            }
            return RedirectToAction("Dealers");
        }

        public ActionResult DisableDealer(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer dealer = (from d in context.Dealers where d.Id == id select d).First();
                dealer.Enabled = false;
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

        #endregion

        #region Categories
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
                    translationItems = (from tr in translations select new TranslationItem { ItemId = itemId, ItemType = ItemTypes.Category, Language = tr.Key, Translation = tr.Value }).ToList();
                    string translationXml = Utils.CreateTranslationXml(translationItems);
                    using (ZamovStorage context = new ZamovStorage())
                    {
                        context.UpdateTranslations(translationXml);
                    }
                }
            }
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
                category.Name = form["categoryName"];
                category.Names.Clear();
                category.Names["ru-RU"] = form["categoryRusName"];
                category.Names["uk-UA"] = form["categoryUkrName"];
                context.AddToCategories(category);
                context.SaveChanges();
                context.UpdateTranslations(category.NamesXml);
            }
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
                ProfileBase profile = ProfileBase.Create(user.UserName);
                int dealerId = -1;
                if (profile["DealerId"] != null)
                    dealerId = Convert.ToInt32(profile["DealerId"]);
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

        #endregion
    }
}
