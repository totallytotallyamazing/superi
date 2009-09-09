using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Security;
using System.Data.Objects;
using Zamov.Helpers;
using System.Text;

namespace Zamov.Controllers
{
    public class PagePartsController : Controller
    {
        //
        // GET: /PageParts/

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult HeaderSelectors()
        {

            using (ZamovStorage context = new ZamovStorage())
            {
                string currentLanguage = SystemSettings.CurrentLanguage;
                List<City> cities = context.Cities.Select(c => c).ToList();
                List<Category> categories = context.Categories.Select(c => c).ToList();
                List<SelectListItem> citiesList = (from city in cities where city.Enabled select new SelectListItem { Selected = city.Id == SystemSettings.CityId, Text = city.GetName(currentLanguage), Value = city.Id.ToString() }).ToList();
                int cityId = int.MinValue;
                if (citiesList.Where(cl => cl.Selected).Count() == 0)
                    citiesList[0].Selected = true;
                cityId = (from cl in citiesList where cl.Selected select int.Parse(cl.Value)).First();
                List<SelectListItem> categoriesList = context.GetCachedCategories(cityId, false)
                    .Select(c => new SelectListItem
                    {
                        Text = c.GetName(SystemSettings.CurrentLanguage),
                        Value = c.Id.ToString(),
                        Selected = c.Id == SystemSettings.CategoryId
                    })
                    .ToList();
                categoriesList.Insert(0, new SelectListItem { Selected = true, Text = "--" + ResourcesHelper.GetResourceString("SelectCategory") + "--", Value = "" });
                ViewData["citiesList"] = citiesList;
                ViewData["categoriesList"] = categoriesList;
                return View();
            }
        }

        public ActionResult MainMenu()
        {
            ViewData["authenticated"] = User.Identity.IsAuthenticated;
            if (User.Identity.IsAuthenticated)
            {
                ViewData["dealer"] = Roles.IsUserInRole("Dealers");
                ViewData["admin"] = Roles.IsUserInRole("Administrators");
                ViewData["customer"] = Roles.IsUserInRole("Customers");
            }
            return View();
        }

        public ActionResult LeftMenu(string caption, IEnumerable<SelectListItem> items)
        {
            ViewData["caption"] = caption;
            return View(items);
        }

        public ActionResult GetCityCategories(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
                return Json(context.GetCategories(id));
        }

        public ActionResult ShowOrder(Order order, bool cartMode, string caller)
        {
            if (cartMode)
                ViewData["cartMode"] = cartMode;
            ViewData["caller"] = caller;
            return View(order);
        }

        public ActionResult CurrentDealer(int id)
        {
            ViewData["dealerId"] = id;
            return View();
        }

        public ActionResult TranslatedText(string formAction, string formController, string richEditorPanel)
        { 
            ViewData["formAction"] = formAction;
            ViewData["formController"] = formController;
            ViewData["richEditorPanel"] = richEditorPanel;
            return View();
        }
    }
}
