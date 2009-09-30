using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;

namespace MBrand.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private void UpdateText(string textName, string text)
        {
            using (DataStorage context = new DataStorage())
            {
                Text clilents = context.Texts.Where(c => c.Name == textName).Select(c => c).First();
                clilents.Content = HttpUtility.HtmlDecode(text);
                context.SaveChanges();
            }
        }

        public ActionResult Index()
        {
            ViewData["text"] = Helpers.Helpers.GetText("Index");
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string text)
        {
            UpdateText("Index", text);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Eugene()
        {
            ViewData["text"] = Helpers.Helpers.GetText("Eugene");
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Eugene(string text)
        {
            UpdateText("Eugene", text);
            return RedirectToAction("Index", "Eugene");
        }

        public ActionResult See()
        {
            return View();
        }

        public ActionResult Clients()
        {
            ViewData["text"] = Helpers.Helpers.GetText("Clients");
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients(string text)
        {
            UpdateText("Clients", text);
            return RedirectToAction("Index", "Clients");
        }

        public ActionResult Notes(int? id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddNote(string title, string shortText, string longText, int currentPage)
        {
            return RedirectToAction("Index", "Notes", new { id = currentPage });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteNote(int id, int currentPage)
        {
            return RedirectToAction("Index", "Notes", new { id = currentPage });
        }

        public ActionResult Contacts()
        {
            ViewData["text"] = Helpers.Helpers.GetText("Contacts");
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contacts(string text)
        {
            UpdateText("Contacts", text);
            return RedirectToAction("Index", "Contacts");
        }



    }
}
