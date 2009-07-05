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

namespace Zamov.Controllers
{
    [Authorize(Roles = "Administrators, Dealers")]
    public class DealerCabinetController : Controller
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
                List<Group> groups = (from g in context.Groups where g.Dealer.Id == dealerId select g).ToList();
                return View(groups);
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
            return RedirectToAction("Products");
        }

        private void GetGroupItems(List<SelectListItem> items, int dealerId, int groupId, string prefix, int currentGroipId)
        {
            if (groupId < 0)
                items.Add(new SelectListItem { Selected = currentGroipId < 0, Text = Resources.GetResourceString("SelectGroup"), Value = "" });
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Group> groups = new List<Group>();
                if (groupId > 0)
                    groups = (from g in context.Groups where g.Dealer.Id == dealerId && g.Parent.Id == groupId select g).ToList();
                else
                    groups = (from g in context.Groups where g.Dealer.Id == dealerId && g.Parent == null select g).ToList();
                foreach (var g in groups)
                {
                    SelectListItem listItem = new SelectListItem
                    {
                        Selected = (g.Id == currentGroipId),
                        Text = prefix + " " + g.GetName(SystemSettings.CurrentLanguage),
                        Value = g.Id.ToString()
                    };
                    items.Add(listItem);
                    g.Groups.Load();
                    if (g.Groups != null && g.Groups.Count > 0)
                        GetGroupItems(items, dealerId, g.Id, prefix + "--", currentGroipId);
                }
            }
        }
        #endregion
    }
}
