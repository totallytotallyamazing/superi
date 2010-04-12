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
        [OutputCache(Duration=1, NoStore = true, VaryByParam="*")]
        public ActionResult Index(int? classId, int? brandId, int? pageNumber)
        {
            
            Dictionary<KeyValuePair<string, long>, List<KeyValuePair<string, long>>> brandClasses = new Dictionary<KeyValuePair<string, long>, List<KeyValuePair<string, long>>>();
            using (CarAdStorage context = new CarAdStorage())
            {
                Func<long, string> getClass = (cId) =>
                    {
                        CarAdClasses adClass = (CarAdClasses)cId;
                        return LocaleHelper.GetResourceString(adClass.ToString());
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

        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        public ActionResult CarSearch(string searchField)
        {
            Dictionary<KeyValuePair<string, long>, List<KeyValuePair<string, long>>> brandClasses = new Dictionary<KeyValuePair<string, long>, List<KeyValuePair<string, long>>>();
            using (CarAdStorage context = new CarAdStorage())
            {
                Func<long, string> getClass = (cId) =>
                {
                    CarAdClasses adClass = (CarAdClasses)cId;
                    return LocaleHelper.GetResourceString(adClass.ToString());
                };

                var items = context.CarAds.Select(ca => new { Class = ca.Class, BrandName = ca.Brand.Name, BrandId = ca.Brand.Id })
                    .Distinct()
                    .OrderBy(i => i.Class)
                    .ToList();
                var grouppedItems = items.GroupBy(i => i.Class, i => new { BrandId = i.BrandId, BrandName = i.BrandName });
                brandClasses = grouppedItems
                    .ToDictionary(d => new KeyValuePair<string, long>(getClass(d.Key), d.Key),
                    d => d.Select(di => new KeyValuePair<string, long>(di.BrandName, di.BrandId)).ToList());

                ViewData["brandClasses"] = brandClasses;

                if (!string.IsNullOrEmpty(searchField))
                {
                    List<CarAd> carAds = (from car in context.CarAds
                                              .Include("Brand").Include("Images").Include("Descriptions")
                                          let model = car.Brand.Name + " " + car.Model
                                          where model.StartsWith(searchField)
                                          select car).Distinct().ToList();
                    carAds.ForEach(ca => { ca.Images.Load(); ca.Descriptions.Load(); });
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

        public ActionResult AddCar(long id)
        {
            using (CarAdStorage context = new CarAdStorage())
            {
                OrderItem orderItem;
                if (WebSession.OrderItems.ContainsKey(id))
                {
                    WebSession.OrderItems[id].Quantity++;
                    orderItem = WebSession.OrderItems[id];
                }
                else
                {
                    CarAd ad = context.CarAds.Where(ca => ca.Id == id).First();
                    ad.Images.Load();
                    ad.BrandReference.Load();
                    orderItem = new OrderItem();
                    orderItem.AdModel = ad.Brand.Name + " " + ad.Model;
                    orderItem.CarId = ad.Id;
                    orderItem.Class = ad.Class;
                    orderItem.Quantity = 1;
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
                    WebSession.OrderItems.Add(orderItem.CarId, orderItem);
                }
                ViewData["name"] = string.Format("{0} ({1})", orderItem.AdModel, orderItem.Year);
            }
            return View();
        }

        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        public ActionResult SearchSuggestion(string term)
        {
            using(CarAdStorage  context = new CarAdStorage())
	        {
                var result = (from car in context.CarAds.Include("Brand")
                              let model = car.Brand.Name + " " + car.Model
                              where model.StartsWith(term)
                              select model).Distinct().ToList();
                return Json(result);
	        }
        }
    }
}
