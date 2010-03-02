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
        //
        // GET: /Catalogue/

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

                return View();
            }
        }
    }
}
