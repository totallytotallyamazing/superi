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
    [BreadCrumb(CategoryId = true)]
    public class DealersController : Controller
    {
        //
        // GET: /Dealers/
        [BreadCrumb(SubCategoryId = true)]
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
                throw new HttpException(404, "Article not found");

            using (ZamovStorage context = new ZamovStorage())
            {
                List<CategoryPresentation> categories = context.GetCachedCategories(SystemSettings.CityId, SystemSettings.CurrentLanguage);

                IEnumerable<CategoryPresentation> flattentCategories = categories.SelectMany(c => c.Children).Union(categories);

                string[] categoryIds = flattentCategories.Where(c => c.Id == id || c.ParentId == id).Select(c => c.Id.ToString()).ToArray();

                string categoryIdsString = string.Join(",", categoryIds);

                ObjectQuery<Group> groups = new ObjectQuery<Group>("SELECT VALUE G FROM Groups as G WHERE G.Id IN{" + categoryIdsString + "}", context);

                List<DealerPresentation> dealers = groups.Where(g => g.Dealer.Enabled).Join(context.Translations
                    .Where(tr => tr.Language == SystemSettings.CurrentLanguage)
                    .Where(tr => tr.TranslationItemTypeId == (int)ItemTypes.DealerName),
                    g => g.Dealer.Id, tr => tr.ItemId,
                    (g, tr) => new DealerPresentation
                        {
                            Id = g.Dealer.Id,
                            Name = tr.Text,
                            TopDealer = g.Dealer.TopDealer,
                        }
                    )
                .Distinct().ToList();

                ViewData["categories"] = categories;
                ViewData["expandedGroup"] = categories
                    .Where(c => c.ParentId == null)
                    .Where(c => c.Id == id || (c.Children.Count > 0 && c.Children.Where(ch => ch.Id == id).Count() > 0))
                    .Select(c => c.Id).First();
                return View(dealers);
            }
        }

        public ActionResult SelectDealer(int id)
        {
            int? groupId = null;
            SystemSettings.SelectedDealer = id;
            string dealerName = "";
            using (ZamovStorage context = new ZamovStorage())
            {
                Dealer currentDealer = context.Dealers.Include("Groups").Select(d => d).Where(d => d.Id == id).First();
                var g = (from gr in currentDealer.Groups
                         join trr in context.Translations on gr.Id equals trr.ItemId
                         join tru in context.Translations on gr.Id equals tru.ItemId
                         where
                              trr.Language == "ru-RU" && tru.Language == "uk-UA"
                              && trr.TranslationItemTypeId == (int)ItemTypes.Group && tru.TranslationItemTypeId == (int)ItemTypes.Group
                         select new { Id = gr.Id, NameUa = tru.Text, NameRu = trr.Text });
                dealerName = currentDealer.Name;
                foreach (var item in g)
                {
                    if (item.NameRu == SystemSettings.CategoryName || item.NameUa == SystemSettings.CategoryName)
                    {
                        groupId = item.Id;
                        break;
                    }
                }
            }
            return RedirectToAction("Index", "Products", new { dealerId = dealerName, groupId = groupId });
        }
    }
}
