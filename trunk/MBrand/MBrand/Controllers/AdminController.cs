using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;
using System.Globalization;
using System.IO;
using System.Data;

namespace MBrand.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private void UpdateText(string textName, string text, string seoKeywords, string seoDescription, string seoCustomText)
        {
            using (DataStorage context = new DataStorage())
            {
                Text clilents = context.Texts.Where(c => c.Name == textName).Select(c => c).First();
                clilents.Content = HttpUtility.HtmlDecode(text);
                clilents.Keywords = seoKeywords;
                clilents.Description = seoDescription;
                clilents.SeoCustomText = seoCustomText;
                context.SaveChanges();
            }
        }

        public ActionResult Index()
        {
            Text text = Helpers.Helpers.GetContent("Index");
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string text, string seoKeywords, string seoDescription, string seoCustomText)
        {
            UpdateText("Index", text, seoKeywords, seoDescription, seoCustomText);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Eugene()
        {
            Text text = Helpers.Helpers.GetContent("Eugene");
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Eugene(string text, string seoKeywords, string seoDescription, string seoCustomText)
        {
            UpdateText("Eugene", text, seoKeywords, seoDescription, seoCustomText);
            return RedirectToAction("Index", "Eugene");
        }


        public ActionResult Clients()
        {
            Text text = Helpers.Helpers.GetContent("Clients");
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients(string text, string seoKeywords, string seoDescription, string seoCustomText)
        {
            UpdateText("Clients", text, seoKeywords, seoDescription, seoCustomText);
            return RedirectToAction("Index", "Clients");
        }

        [OutputCache(VaryByParam = "*", NoStore = true, Duration = 1)]
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
                    ViewData["date"] = note.Date.ToString("dd.MM.yyyy");
                    if (!string.IsNullOrEmpty(note.Image))
                        ViewData["imageLayout"] = string.Format("<img style=\"height:50px;\" alt=\"{0}\" src=\"/Content/images/notes/{1}\"/>", note.Title, note.Image);
                }
            }
            else ViewData["date"] = DateTime.Now.ToString("dd.MM.yyyy");
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
                    if (id > 0)
                        DeleteImage("~/Content/images/notes", note.Image);
                    fileName = Path.GetFileName(fileName);
                    string filePath = Server.MapPath("~/Content/images/notes/" + fileName);
                    Request.Files["image"].SaveAs(filePath);
                    note.Image = fileName;
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

        public ActionResult DeleteNote(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Note note = context.Notes.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
                if (!string.IsNullOrEmpty(note.Image))
                    DeleteImage("~/Content/images/notes", note.Image);
                context.DeleteObject(note);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Notes");
        }

        public ActionResult Contacts()
        {
            Text text = Helpers.Helpers.GetContent("Contacts");
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contacts(string text, string seoKeywords, string seoDescription, string seoCustomText)
        {
            UpdateText("Contacts", text, seoKeywords, seoDescription, seoCustomText);
            return RedirectToAction("Index", "Contacts");
        }

        [OutputCache(VaryByParam = "*", NoStore = true, Duration = 1)]
        public ActionResult AddEditWorkGroup(WorkType workType, int? id)
        {
            ViewData["workType"] = workType;
            ViewData["id"] = id;
            if (id != null)
            {
                using (DataStorage context = new DataStorage())
                {
                    WorkGroup workGroup = context.WorkGroups.Where(wg => wg.Id == id.Value).Select(wg => wg).First();
                    ViewData["name"] = workGroup.Name;
                    ViewData["date"] = workGroup.Date.ToString("dd.MM.yyyy");
                    ViewData["description"] = workGroup.Description;
                    ViewData["seoKeywords"] = workGroup.SeoKeywords;
                    ViewData["seoDescription"] = workGroup.SeoDescription;
                    ViewData["seoCustomText"] = workGroup.SeoCustomText;
                }
            }
            return View();            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEditWorkGroup(WorkType workType, int? id, string name, string date, string description, string seoKeywords, string seoDescription, string seoCustomText) 
        {
            using (DataStorage context = new DataStorage())
            {
                WorkGroup workGroup = new WorkGroup();
                if (id != null)
                {
                    workGroup = context.WorkGroups.Where(wg => wg.Id == id.Value).Select(wg => wg).FirstOrDefault();
                }
                else
                {
                    workGroup.Type = (int)workType;
                }
                CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                workGroup.Date = DateTime.Parse(date, cultureInfo);
                workGroup.Name = name;
                workGroup.Description = description;
                workGroup.SeoKeywords = seoKeywords;
                workGroup.SeoDescription = seoDescription;
                workGroup.SeoCustomText = seoCustomText;
                string previewName = Request.Files["preview"].FileName;
                if (!string.IsNullOrEmpty(previewName))
                {
                    if (id != null)
                    {
                        DeleteImage("~/Content/images/" + workType.ToString().ToLower() + "/preview", workGroup.Image);
                    }
                    previewName = Path.GetFileName(previewName);
                    string filePath = Server.MapPath("~/Content/images/" + workType.ToString().ToLower() + "/preview/" + previewName);
                    Request.Files["preview"].SaveAs(filePath);
                    workGroup.Image = previewName;
                }
                if (id == null)
                    context.AddToWorkGroups(workGroup);
                context.SaveChanges();
            }
            return RedirectToAction(workType.ToString(), "See");
        }

        public ActionResult DeleteWorkGroup(int id)
        {
            WorkType workType;
            using (DataStorage context = new DataStorage())
            {
                WorkGroup workGroup = context.WorkGroups.Where(wg => wg.Id == id).Select(wg => wg).FirstOrDefault();
                workType = (WorkType)(workGroup.Type);
                context.DeleteObject(workGroup);
                context.SaveChanges();
                return RedirectToAction(workType.ToString(), "See");
            }
        }

        public ActionResult See(WorkType type)
        {
            ViewData["baseFolder"] = "~/Content/Images/" + type.ToString().ToLower() + "/";
            ViewData["type"] = type;
            using (DataStorage context = new DataStorage())
            {
                int typeId = (int)type;
                List<Work> works = context.Works.Where(w => w.Type == typeId).Select(w => w).ToList();
                return View(works);
            }
        }

        [OutputCache(VaryByParam="*", NoStore=true, Duration=1)]
        public ActionResult AddEditWork(int? id, int groupId)
        {
            ViewData["groupId"] = groupId;
            if (id != null)
            {
                using (DataStorage context = new DataStorage())
                {
                    Work work = context.Works.Where(w => w.Id == id).Select(w => w).FirstOrDefault();
                    ViewData["id"] = id;
                    ViewData["description"] = work.Description;
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEditWork(int? id, string description, int groupId, string seoCustomText)
        {
            using (DataStorage context = new DataStorage())
            {
                WorkGroup workGroup = context.WorkGroups.Where(wg => wg.Id == groupId).Select(wg => wg).First();
                WorkType type = (WorkType)workGroup.Type;
                Work work = new Work();
                if (id != null)
                {
                    work = context.Works.Where(w => w.Id == id.Value).Select(w => w).FirstOrDefault();
                }
                else
                {
                    work.WorkGroup = workGroup;
                }
                work.Description = HttpUtility.HtmlDecode(description);
                work.SeoCustomText = HttpUtility.HtmlDecode(seoCustomText);
                string image = Request.Files["image"].FileName;
                if (!string.IsNullOrEmpty(image))
                {
                    if (id > 0)
                        DeleteImage("~/Content/images/"+type.ToString().ToLower() +"/", work.Image);
                    image = Path.GetFileName(image); 
                    string imagePath = Server.MapPath("~/Content/images/"+type.ToString().ToLower()+"/" + image);
                    Request.Files["image"].SaveAs(imagePath);
                    work.Image = image;
                }
                if(id == null)
                    context.AddToWorks(work);
                context.SaveChanges();
                return RedirectToAction(type.ToString(), "See", new { id = groupId });
            }
        }

        public ActionResult DeleteWork(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Work work = context.Works.Include("WorkGroup").Where(w => w.Id == id).Select(w => w).FirstOrDefault();
                WorkType type = (WorkType)work.WorkGroup.Type;
                int groupId = work.WorkGroup.Id;
                DeleteImage("~/Content/images/" + type.ToString().ToLower() + "/preview", work.Preview);
                DeleteImage("~/Content/images/" + type.ToString().ToLower(), work.Image);
                context.DeleteObject(work);
                context.SaveChanges();
                return RedirectToAction(type.ToString(), "See", new { id = groupId });
            }
        }
    }
}
