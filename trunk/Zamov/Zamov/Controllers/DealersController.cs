using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using Zamov.Models;
using System.Web.Profile;

namespace Zamov.Controllers
{
    public class DealersController : Controller
    {
        //
        // GET: /Dealers/

        public ActionResult Index()
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                var dealers = (from dealer in context.Dealers.Include("Cities").Include("Categories")
                               join trn in context.Translations on dealer.Id equals trn.ItemId
                               where dealer.Cities.Where(c => c.Id == SystemSettings.CityId).Count() > 0
                                   && dealer.Categories.Where(c => c.Id == SystemSettings.CategoryId).Count() > 0
                                   && trn.TranslationItemTypeId == (int)ItemTypes.DealerName
                                   && trn.Language == SystemSettings.CurrentLanguage
                               select new { Id = dealer.Id, Name = trn.Text });
                int[] onlineDealers = MembershipExtensions.GetOnlineDealers();

                List<DealerPresentation> result = new List<DealerPresentation>();
                foreach (var item in dealers)
                    result.Add(new DealerPresentation { Id = item.Id, Name = item.Name, OnLine = onlineDealers.Contains(item.Id) });
                return View(result);
            }
        }
    }
}
