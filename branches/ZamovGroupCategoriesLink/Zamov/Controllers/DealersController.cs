using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using Zamov.Models;
using System.Web.Profile;
using Zamov.Helpers;
using System.Data.Objects;

namespace Zamov.Controllers
{
    public class DealersController : Controller
    {
        public ActionResult Index(int? id, int? cityId)
        {
            if (!id.HasValue)
                throw new HttpException(404, "Article not found");

            if (cityId.HasValue)
                SystemSettings.CityId = cityId.Value;

            HttpContext.Items["categoryId"] = id;

            BreadCrumbAttribute.ProcessCategory(id.Value, HttpContext);

            using (ZamovStorage context = new ZamovStorage())
            {
                List<CategoryPresentation> categories = context.GetCachedCategories(SystemSettings.CityId, SystemSettings.CurrentLanguage);

                IEnumerable<CategoryPresentation> flattenCategories = categories.SelectMany(c => c.Children).Union(categories);

                string[] categoryIds = flattenCategories.Where(c => c.Id == id || c.ParentId == id).Select(c => c.Id.ToString()).ToArray();

                string categoryIdsString = string.Join(",", categoryIds);

                ObjectQuery<Group> groups = new ObjectQuery<Group>("SELECT VALUE G FROM Groups as G WHERE G.Category.Id IN{" + categoryIdsString + "}", context);
                int[] onlineDealers = MembershipExtensions.GetOnlineDealers();
                List<DealerPresentation> dealers = groups.Where(g => g.Dealer.Enabled)
                    .Where(g=>g.Dealer.Cities.Where(city=>city.Id == SystemSettings.CityId).Count()>0)
                    .Join(context.Translations
                        .Where(tr => tr.Language == SystemSettings.CurrentLanguage)
                        .Where(tr => tr.TranslationItemTypeId == (int)ItemTypes.DealerName),
                        g => g.Dealer.Id, tr => tr.ItemId,
                        (g, tr) => new DealerPresentation
                            {
                                Id = g.Dealer.Id,
                                Name = tr.Text,
                                TopDealer = g.Dealer.TopDealer,
                                StringId = g.Dealer.Name
                            }
                        )
                   .Distinct().ToList();

                dealers.ForEach(d => d.OnLine = onlineDealers.Contains(d.Id));

                ViewData["categories"] = categories;
                ViewData["expandedGroup"] = categories
                    .Where(c => c.ParentId == null)
                    .Where(c => c.Id == id || (c.Children.Count > 0 && c.Children.Where(ch => ch.Id == id).Count() > 0))
                    .Select(c => c.Id).First();
                return View(dealers);
            }
        }
    }
}
