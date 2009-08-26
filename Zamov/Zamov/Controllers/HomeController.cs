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

namespace Zamov.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int currentCity, int currentCategory)
        {
            SystemSettings.CityId = currentCity;
            SystemSettings.CategoryId = currentCategory;
            return Redirect("~/Categories");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Agreement()
        {
            return View();
        }

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

        public ActionResult Contacts()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SendMessage(string userName, string messageSubj, string messageBody, string email, string phone)
        {
            if (ValidEmail(email))
            {
                try
                {
                    MailAddress mailAddressFrom = new MailAddress(email);
                    MailAddress mailAddressTo = new MailAddress(ApplicationData.FeedbackEmail);
                    MailMessage message = new MailMessage(mailAddressFrom, mailAddressTo);
                    message.Subject = messageSubj;
                    message.Body = messageBody;
                    string host = "";
                    SmtpClient client = new SmtpClient(host);
                    client.Send(message);
                }
                catch
                {
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Contacts", "Home");
        }

        private bool ValidEmail(string email)
        {
            Regex regex = new Regex("^(?:[a-zA-Z0-9_'^&amp;/+-])+(?:\\.(?:[a-zA-Z0-9_'^&amp;/+-])+)*@(?:(?:\\[?(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))\\.){3}(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\]?)|(?:[a-zA-Z0-9-]+\\.)+(?:[a-zA-Z]){2,}\\.?)$");
            //return regex.IsMatch(email);
            if (!regex.IsMatch(email))
                ModelState.AddModelError("email", Resources.GetResourceString("EmailIncorrect"));
            return ModelState.IsValid;
        }

    }
}
