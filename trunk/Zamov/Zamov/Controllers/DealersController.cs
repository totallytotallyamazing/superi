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

namespace Zamov.Controllers
{
    [BreadCrumb(CategoryId = true)]
    public class DealersController : Controller
    {
        //
        // GET: /Dealers/
        [BreadCrumb( SubCategoryId = true )]
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
                                   && dealer.Enabled
                               select new { Id = dealer.Id, Name = trn.Text,  TopDealer = dealer.TopDealer });
                int[] onlineDealers = MembershipExtensions.GetOnlineDealers();

                List<DealerPresentation> result = new List<DealerPresentation>();
                foreach (var item in dealers)
                    result.Add(new DealerPresentation { Id = item.Id, Name = item.Name, OnLine = onlineDealers.Contains(item.Id), TopDealer = item.TopDealer });
                return View(result);
            }
        }

        public ActionResult SelectDealer(int id)
        {
            int? groupId = null;
            SystemSettings.SelectedDealer = id;
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
                foreach (var item in g)
                {
                    if (item.NameRu == SystemSettings.CategoryName || item.NameUa == SystemSettings.CategoryName)
                    {
                        groupId = item.Id;
                        break;
                    }
                }
            }
            return RedirectToAction("Index", "Products", new { dealerId = id, groupId = groupId });
        }
    }
}
