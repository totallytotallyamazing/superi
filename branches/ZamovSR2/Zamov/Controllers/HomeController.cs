using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Zamov.Models;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Web.Routing;
using Zamov.Helpers;
using System.Linq.Expressions;

namespace Zamov.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {

        #region Get Actions
        public ActionResult Index(int? id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<SelectListItem> citiesList = context.GetCitiesFromContext(SystemSettings.CurrentLanguage);
                if (id.HasValue)
                    SystemSettings.CityId = id.Value;
                if (citiesList.Count > 0)
                {
                    SystemSettings.InitializeCity(int.Parse(citiesList[0].Value));
                    citiesList.ForEach(cl => { cl.Selected = (cl.Value == SystemSettings.CityId.ToString()); });
                }
                List<SelectListItem> cities = citiesList.Select(c => new SelectListItem { Text = c.Text, Selected = c.Selected, Value = "/Home/" + c.Value }).ToList();
                ViewData["cities"] = cities;

                List<CategoryPresentation> categories = context.GetCachedCategories(SystemSettings.CityId, SystemSettings.CurrentLanguage);
                return View(categories);
            }
        }

        [BreadCrumb(ResourceName = "AboutUs", Url = "/Home/About")]
        public ActionResult About()
        {
            ViewData["content"] = ApplicationData.StartText;
            return View();
        }

        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Agreement()
        {
            return View();
        }

        [BreadCrumb(ResourceName = "Contacts", Url = "/Home/Contacts")]
        public ActionResult Contacts()
        {
            return View();
        }

        #endregion

        #region Post Actions
        [AcceptVerbs(HttpVerbs.Post)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index(int currentCity, int currentCategory)
        {
            SystemSettings.CityId = currentCity;
            return Redirect("~/Categories");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contacts(string userName, string messageSubj, string messageBody, string email, string phone)
        {
            if (Validate(email, messageBody))
            {
                try
                {
                    MailAddress mailAddressFrom = new MailAddress(email);
                    MailAddress mailAddressTo = new MailAddress(ApplicationData.FeedbackEmail);
                    MailMessage message = new MailMessage(mailAddressFrom, mailAddressTo);
                    message.Subject = messageSubj;
                    message.Body = messageBody;
                    SmtpClient client = new SmtpClient(ApplicationData.ZamovSmtpHost);
                    client.Send(message);
                }
                catch
                {

                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion

        #region Language Actions
        public ActionResult SetUkrainian(string returnUrl)
        {
            SystemSettings.CurrentLanguage = "uk-UA";
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SetRussian(string returnUrl)
        {
            SystemSettings.CurrentLanguage = "ru-RU";
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        #region Validation  
        private bool Validate(string email, string messageBody)
        {
            Regex regex = new Regex("^(?:[a-zA-Z0-9_'^&amp;/+-])+(?:\\.(?:[a-zA-Z0-9_'^&amp;/+-])+)*@(?:(?:\\[?(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))\\.){3}(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\]?)|(?:[a-zA-Z0-9-]+\\.)+(?:[a-zA-Z]){2,}\\.?)$");
            //return regex.IsMatch(email);
            if (!regex.IsMatch(email))
                ModelState.AddModelError("email", ResourcesHelper.GetResourceString("EmailIncorrect"));
            if (string.IsNullOrEmpty(messageBody.Trim()))
                ModelState.AddModelError("messageBody", ResourcesHelper.GetResourceString("MessageRequired"));
            return ModelState.IsValid;
        }
        #endregion
    }
}
