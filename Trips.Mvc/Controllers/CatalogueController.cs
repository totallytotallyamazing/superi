using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trips.Mvc.Models;
using Dev.Helpers;
using System.Web.Configuration;
using System.Configuration;

namespace Trips.Mvc.Controllers
{
    public class CatalogueController : Controller
    {
        public ActionResult Index(int? classId, int? brandId)
        {
            Dictionary<KeyValuePair<string, long>, List<KeyValuePair<string, long>>> brandClasses = new Dictionary<KeyValuePair<string, long>, List<KeyValuePair<string, long>>>();
            using (CarAdStorage context = new CarAdStorage())
            {
                Func<long, string> getClass = (cId) =>
                    {
                        CarAdClasses adClass = (CarAdClasses)cId;
                        return LocaleHelper.GetResourceString("Class" + adClass);
                    };

                var items = context.CarAds.Select(ca => new { Class = ca.Class, BrandName = ca.Brand.Name, BrandId = ca.Brand.Id })
                    .Distinct()
                    .OrderBy(i=>i.Class)
                    .ToList();
                var grouppedItems = items.GroupBy(i=>i.Class, i=>new {BrandId = i.BrandId, BrandName=i.BrandName});
                brandClasses = grouppedItems
                    .ToDictionary(d => new KeyValuePair<string, long>(getClass(d.Key), d.Key), 
                    d => d.Select(di => new KeyValuePair<string, long>(di.BrandName, di.BrandId)).ToList());

                ViewData["brandClasses"] = brandClasses;

                if (classId.HasValue && brandId.HasValue)
                {
                    List<CarAd> carAds = context.CarAds.Include("Images").Include("Descriptions")
                        .Where(ca=>ca.Class == classId.Value)
                        .Where(ca => ca.Brand.Id == brandId.Value).ToList();
                    return View("AdList", carAds);
                }

                using (ContentStorage cs = new ContentStorage())
                {
                    ViewData["id"] = "Catalogue";
                    string language = LocaleHelper.GetCultureName();
                    Content content = cs.Content
                        .Where(c => c.Language == language)
                        .Where(c => c.Name == "Catalogue")
                        .FirstOrDefault();
                    return View(content); 
                }
            }
        }

        public ActionResult Details(int id)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                CarAd carAd = context.CarAds.Where(ca => ca.Id == id).First();
                carAd.Images.Load();
                carAd.Descriptions.Load();

                carAd.BrandReference.Load();

                string title = string.Format("{0} {1} ({2})", carAd.Brand.Name, carAd.Model, carAd.Year);

                ViewData["title"] = title;

                return View(carAd); 
            }
        }

        public ActionResult AddCar(int id)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                CarAd ad = context.CarAds.Where(ca => ca.Id == id).First();
                ad.Images.Load();
                ad.BrandReference.Load();
                OrderItem orderItem = new OrderItem();
                orderItem.AdModel = ad.Brand.Name + " " + ad.Model;
                orderItem.CarId = ad.Id;
                orderItem.Class = ad.Class;
                orderItem.Year = ad.Year;
                CarAdImage img = ad.Images.Where(i => i.Default).FirstOrDefault();
                if (img != null)
                {
                    orderItem.ImageSource = ad.Images.Where(i => i.Default).First().ImageSource;
                }
                else
                {
                    orderItem.ImageSource = "tripsWebMvcNoCarImage.jpg";
                }
                WebSession.OrderItems.Add(orderItem);

                ViewData["name"] = string.Format("{0} ({1})", orderItem.AdModel, orderItem.Year);
            }
            return View();
        }
    }
}