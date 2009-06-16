using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Script.Serialization;

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
                using(ZamovStorage context = new ZamovStorage())
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
            using(ZamovStorage context = new ZamovStorage())
            {
                if (dealerId > 0)
                    dealer = context.Dealers.Select(d => d).Where(d => d.Id == dealerId).First();
                dealer.Name = form["name"];
                dealer.Names["ru-RU"] = form["rDescription"];
                dealer.Names["uk-UA"] = form["uDescription"];
                if (!string.IsNullOrEmpty(Request.Files["logoImage"].FileName))
                {
                    HttpPostedFileBase file = Request.Files["logoImage"];
                    dealer.LogoType = file.ContentType;
                    file.InputStream.Read(dealer.LogoImage, 0, (int)file.InputStream.Length);
                }
                context.SaveChanges();
                context.UpdateTranslations(dealer.NamesXml);
            }
            return RedirectToAction("Dealers");
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult SaveDealer(FormCollection frm)
        //{
        //    return RedirectToAction("Dealers");
        //}
        #endregion
    }
}
