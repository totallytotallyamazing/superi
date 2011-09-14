using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Helpers;
using MBrand.Models;
using System.Globalization;
using System.IO;
using System.Data;
using MBrand.Models2;

namespace MBrand.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {


        public ActionResult TransferData()
        {


            using (DataStorage context = new DataStorage())
            {

                IEnumerable<MBrand.Models.WorkGroup> wgs = context.WorkGroups.Include("Works").ToList();

                using (var context2 = new DataStorage2())
                {

                    foreach (var wg in wgs)
                    {

                        var workgroup = new MBrand.Models2.WorkGroup
                        {

                            Date = wg.Date,
                            Description = wg.Description,
                            Image = wg.Image,
                            Name = wg.Name,
                            SeoCustomText = wg.SeoCustomText,
                            SeoDescription = wg.SeoDescription,
                            SeoKeywords = wg.SeoKeywords,
                            Title = wg.Title,
                            Type = wg.Type
                        };

                        context2.AddToWorkGroups(workgroup);

                        foreach (var w in wg.Works)
                        {
                            var work = new MBrand.Models2.Work
                            {
                                Description = w.Description,
                                Image = w.Image,
                                Preview = w.Preview,
                                SeoCustomText = w.SeoCustomText,
                                Title = w.Title,
                                Type = w.Type,
                                WorkGroup = workgroup
                            };

                            context2.AddToWorks(work);


                        }
                        
                    }
                    context2.SaveChanges();
                }
            }



            /*
            using (DataStorage context = new DataStorage())
            {

               
                IEnumerable<MBrand.Models.SeoContent> seocontents = context.SeoContent.ToList();

                using (var context2 = new DataStorage2())
                {

                    foreach (var s in seocontents)
                    {
                        
                        var seo = new MBrand.Models2.SeoContent
                        {
                           Description= s.Description,
                           Keywords=s.Keywords,
                           SeoCustomText=s.SeoCustomText,
                           Title=s.Title,
                           WorkType=s.WorkType


                        };

                        context2.AddToSeoContent(seo);
                    }
                    context2.SaveChanges();
                }
            }
            */



            //IEnumerable<MBrand.Models.SecretImages> images = MBrand.Helpers.Helpers.GetSecretImages();

            //using (var context = new DataStorage2())
            //{

            //    foreach (var image in images)
            //    {

            //        var simage = new MBrand.Models2.SecretImages
            //        {
            //            Image = image.Image,
            //            ImagePreview = image.ImagePreview


            //        };

            //        context.AddToSecretImages(simage);
            //    }
            //    context.SaveChanges();
            //}




            //var text = Helpers.Helpers.GetContent("Index");
            //UpdateText("Index", text.Content, text.Keywords, text.Description, text.SeoCustomText, text.Title);

            //text = Helpers.Helpers.GetContent("Clients");
            //UpdateText("Clients", text.Content, text.Keywords, text.Description, text.SeoCustomText, text.Title);

            //text = Helpers.Helpers.GetContent("Contacts");
            //UpdateText("Contacts", text.Content, text.Keywords, text.Description, text.SeoCustomText, text.Title);

            //text = Helpers.Helpers.GetContent("Eugene");
            //UpdateText("Eugene", text.Content, text.Keywords, text.Description, text.SeoCustomText, text.Title);

            //text = Helpers.Helpers.GetContent("Secret");
            //UpdateText("Secret", text.Content, text.Keywords, text.Description, text.SeoCustomText, text.Title);








            //using (DataStorage context = new DataStorage())
            //{

            //    var notes = context.notes.select(n => n).tolist();





            //    using (DataStorage2 context2 = new DataStorage2())
            //    {
            //        foreach (MBrand.Models.Note note in notes)
            //        {

            //            var mnote = new Models2.Note();
            //            mnote.Date = note.Date;
            //            mnote.Description = note.Description;
            //            mnote.Image = note.Image;
            //            mnote.SeoCustomText = note.SeoCustomText;
            //            mnote.Text = note.Text;
            //            mnote.Title = note.Title;

            //            context2.AddToNotes(mnote);
            //            context2.SaveChanges();
            //        }
            //    }
            //}
            return RedirectToAction("Index");
        }


        private void UpdateText(string textName, string text, string seoKeywords, string seoDescription, string seoCustomText, string title)
        {
            using (var context = new DataStorage2())
            {
                var clilents = context.Texts.Where(c => c.Name == textName).Select(c => c).First();
                clilents.Content = HttpUtility.HtmlDecode(text);
                clilents.Keywords = seoKeywords;
                clilents.Description = seoDescription;
                clilents.SeoCustomText = HttpUtility.HtmlDecode(seoCustomText);
                clilents.Title = title;
                context.SaveChanges();
            }
        }

        public ActionResult Index()
        {
            var text = Helpers.Helpers.GetContent("Index");
            ViewData["title"] = text.Title;
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string text, string seoKeywords, string seoDescription, string seoCustomText, string title)
        {
            UpdateText("Index", text, seoKeywords, seoDescription, seoCustomText, title);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Eugene()
        {
            var text = Helpers.Helpers.GetContent("Eugene");
            ViewData["title"] = text.Title;
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Eugene(string text, string seoKeywords, string seoDescription, string seoCustomText, string title)
        {
            UpdateText("Eugene", text, seoKeywords, seoDescription, seoCustomText, title);
            return RedirectToAction("Index", "Eugene");
        }


        public ActionResult Clients()
        {
            var text = Helpers.Helpers.GetContent("Clients");
            ViewData["title"] = text.Title;
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Clients(string text, string seoKeywords, string seoDescription, string seoCustomText, string title)
        {
            UpdateText("Clients", text, seoKeywords, seoDescription, seoCustomText, title);
            return RedirectToAction("Index", "Clients");
        }

        public ActionResult Secret()
        {
            var text = Helpers.Helpers.GetContent("Secret");
            ViewData["title"] = text.Title;
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Secret(string text, string seoKeywords, string seoDescription, string seoCustomText, string title)
        {
            UpdateText("Secret", text, seoKeywords, seoDescription, seoCustomText, title);
            return RedirectToAction("Index", "Secret");
        }


        public ActionResult AddSecretImageOriginal(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddSecretImageOriginal(int id, FormCollection form)
        {
            string fileName = Request.Files["image"].FileName;
            if (!string.IsNullOrEmpty(fileName))
            {
                using (var context = new DataStorage())
                {
                    var img = context.SecretImages.Where(si => si.Id == id).First();
                    if (!string.IsNullOrEmpty(img.Image))
                        IOHelper.DeleteFile("~/Content/images/secret", img.Image);


                    fileName = IOHelper.GetUniqueFileName("~/Content/images/secret", Request.Files["image"].FileName);
                    string filePath = Server.MapPath("~/Content/images/secret");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["image"].SaveAs(filePath);
                    img.Image = fileName;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Secret");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddSecretImagePreview()
        {
            string fileName = Request.Files["image"].FileName;
            if (!string.IsNullOrEmpty(fileName))
            {

                fileName = IOHelper.GetUniqueFileName("~/Content/images/secret/preview", Request.Files["image"].FileName);
                //string filePath = Server.MapPath("~/Content/images/secret/" + fileName);
                string filePath = Server.MapPath("~/Content/images/secret/preview");
                filePath = Path.Combine(filePath, fileName);
                Request.Files["image"].SaveAs(filePath);
                using (var context = new DataStorage())
                {
                    context.AddToSecretImages(new MBrand.Models.SecretImages { ImagePreview = fileName, Image = "" });
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Secret");
        }

        public ActionResult DeleteSecretImage(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                var si = context.SecretImages.Where(s => s.Id == id).First();
                if (!string.IsNullOrEmpty(si.ImagePreview))
                    IOHelper.DeleteFile("~/Content/images/secret/preview", si.ImagePreview);
                if (!string.IsNullOrEmpty(si.Image))
                    IOHelper.DeleteFile("~/Content/images/secret", si.Image);
                context.DeleteObject(si);
                context.SaveChanges();
            }


            return RedirectToAction("Index", "Secret");
        }

        [OutputCache(VaryByParam = "*", NoStore = true, Duration = 1)]
        public ActionResult AddEditNote(int id)
        {
            ViewData["id"] = id;
            if (id > 0)
            {
                using (DataStorage context = new DataStorage())
                {
                    var note = context.Notes.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
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
                MBrand.Models.Note note = null;
                if (id > 0)
                    note = context.Notes.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
                else
                    note = new MBrand.Models.Note();

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
                var note = context.Notes.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
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
                var note = context.Notes.Where(n => n.Id == id).Select(n => n).FirstOrDefault();
                if (!string.IsNullOrEmpty(note.Image))
                    DeleteImage("~/Content/images/notes", note.Image);
                context.DeleteObject(note);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Notes");
        }

        public ActionResult Contacts()
        {
            var text = Helpers.Helpers.GetContent("Contacts");
            ViewData["title"] = text.Title;
            ViewData["text"] = text.Content;
            ViewData["seoKeywords"] = text.Keywords;
            ViewData["seoDescription"] = text.Description;
            ViewData["seoCustomText"] = text.SeoCustomText;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contacts(string text, string seoKeywords, string seoDescription, string seoCustomText, string title)
        {
            UpdateText("Contacts", text, seoKeywords, seoDescription, seoCustomText, title);
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
                    var workGroup = context.WorkGroups.Where(wg => wg.Id == id.Value).Select(wg => wg).First();
                    ViewData["title"] = workGroup.Title;
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
        public ActionResult AddEditWorkGroup(WorkType workType, int? id, string name, string date, string description, string seoKeywords, string seoDescription, string seoCustomText, string title)
        {
            using (DataStorage context = new DataStorage())
            {
                var workGroup = new MBrand.Models.WorkGroup();
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
                workGroup.Title = title;
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
                var workGroup = context.WorkGroups.Where(wg => wg.Id == id).Select(wg => wg).FirstOrDefault();
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
                List<MBrand.Models.Work> works = context.Works.Where(w => w.Type == typeId).Select(w => w).ToList();
                return View(works);
            }
        }

        [OutputCache(VaryByParam = "*", NoStore = true, Duration = 1)]
        public ActionResult AddEditWork(int? id, int groupId)
        {
            ViewData["groupId"] = groupId;
            if (id != null)
            {
                using (DataStorage context = new DataStorage())
                {
                    var work = context.Works.Where(w => w.Id == id).Select(w => w).FirstOrDefault();
                    ViewData["id"] = id;
                    ViewData["description"] = work.Description;
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddEditWork(int? id, string description, int groupId, string seoCustomText, string title)
        {
            using (DataStorage context = new DataStorage())
            {
                var workGroup = context.WorkGroups.Where(wg => wg.Id == groupId).Select(wg => wg).First();
                WorkType type = (WorkType)workGroup.Type;
                var work = new MBrand.Models.Work();
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
                work.Title = title;
                string image = Request.Files["image"].FileName;
                if (!string.IsNullOrEmpty(image))
                {
                    if (id > 0)
                        DeleteImage("~/Content/images/" + type.ToString().ToLower() + "/", work.Image);
                    image = Path.GetFileName(image);
                    string imagePath = Server.MapPath("~/Content/images/" + type.ToString().ToLower() + "/" + image);
                    Request.Files["image"].SaveAs(imagePath);
                    work.Image = image;
                }
                if (id == null)
                    context.AddToWorks(work);
                context.SaveChanges();
                return RedirectToAction(type.ToString(), "See", new { id = groupId });
            }
        }

        public ActionResult DeleteWork(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                var work = context.Works.Include("WorkGroup").Where(w => w.Id == id).Select(w => w).FirstOrDefault();
                WorkType type = (WorkType)work.WorkGroup.Type;
                int groupId = work.WorkGroup.Id;
                DeleteImage("~/Content/images/" + type.ToString().ToLower() + "/preview", work.Preview);
                DeleteImage("~/Content/images/" + type.ToString().ToLower(), work.Image);
                context.DeleteObject(work);
                context.SaveChanges();
                return RedirectToAction(type.ToString(), "See", new { id = groupId });
            }
        }

        public ActionResult EditSeoContent(int workType, string returnUrl)
        {
            using (var context = new DataStorage2())
            {
                var content = context.SeoContent.Where(s => s.WorkType == workType).First();
                ViewData["seoKeywords"] = content.Keywords;
                ViewData["seoDescription"] = content.Description;
                return View(content);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditSeoContent(int workType, string returnUrl, string title, string seoDescription, string seoKeywords, string seoCustomText)
        {
            using (var context = new DataStorage2())
            {
                var content = context.SeoContent.Where(s => s.WorkType == workType).First();
                content.Title = title;
                content.Description = seoDescription;
                content.Keywords = seoKeywords;
                content.SeoCustomText = HttpUtility.HtmlDecode(seoCustomText);
                context.SaveChanges();
            }

            return RedirectToAction(returnUrl, "See");
        }
    }
}
