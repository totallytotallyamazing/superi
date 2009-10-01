using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;
using System.Globalization;
using System.IO;

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

        public ActionResult AddEditNote(int id)
        {
            ViewData["id"] = id;
            if (id > 0)
            {
                using (DataStorage context = new DataStorage())
                {
                    Note note = context.Notes.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
                    ViewData["title"] = note.Title;
                    ViewData["description"] = note.Description;
                    ViewData["text"] = note.Text;
                    ViewData["date"] = note.Date.ToString("dd.MM.yyyy HH:mm");
                    if (!string.IsNullOrEmpty(note.Image))
                        ViewData["imageLayout"] = string.Format("<img alt=\"{0}\" src=\"/Content/images/notes/{1}\"/>", note.Title, note.Image);
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEditNote(int id, string title, string date, string description, string text, int? currentPage)
        {
            using (DataStorage context = new DataStorage())
            {
                Note note = null;
                if (id > 0)
                    note = context.Notes.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
                else
                    note = new Note();

                string fileName = Request.Files["image"].FileName;
                if (!string.IsNullOrEmpty(fileName))
                {
                    fileName = Path.GetFileName(fileName);
                    string filePath = Server.MapPath("~/Content/images/notes/" + fileName);
                    Request.Files["image"].SaveAs(filePath);
                    note.Image = fileName;
                    if (id > 0)
                        DeleteImage("~/Content/images/notes", note.Image);
                }
                note.Title = title;
                note.Description = HttpUtility.HtmlDecode(description);
                note.Text = HttpUtility.HtmlDecode(text);
                CultureInfo ruCulture = CultureInfo.GetCultureInfo("ru-RU");
                note.Date = DateTime.Parse(date, ruCulture);
                if (id < 0)
                    context.AddToNotes(note);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Notes");

        }

        public void DeleteNoteImage(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Note note = context.Notes.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
                DeleteImage("~/Content/images/notes", note.Image);
                note.Image = null;
                context.SaveChanges();
            }
        }

        private void DeleteImage(string imageFolder, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
                System.IO.File.Delete(Server.MapPath(imageFolder + "/" + fileName));
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
