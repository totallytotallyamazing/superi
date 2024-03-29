using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PolialClean.Models;
using System.IO;
using System.Data;

namespace PolialClean.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult EditText(string contentName, string controllerName)
        {
            ViewData["controllerName"] = controllerName;
            ViewData["text"] = Utils.GetText(contentName).Content;
            ViewData["contentName"] = controllerName;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditText(string text, string controllerName, string contentName)
        {
            Utils.SetText(contentName, HttpUtility.HtmlDecode(text));
            return RedirectToAction("Index", controllerName, new { contentName = contentName });
        }

        private void DeleteImage(string imageFolder, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
                System.IO.File.Delete(Server.MapPath(imageFolder + "/" + fileName));
        }

        [OutputCache(NoStore=true, Duration=1, VaryByParam="*")]
        public ActionResult AddUpdateClient(int? id)
        {
            ViewData["id"] = id;
            if (id != null)
            {
                using (DataStorage context = new DataStorage())
                {
                    Clients client = context.Clients.Where(c => c.Id == id).Select(c => c).FirstOrDefault();
                    ViewData["name"] = client.Name;
                }
            }
            return View();
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddUpdateClient(int? id, string name)
        {
            using (DataStorage context = new DataStorage())
            {
                Clients client = null;
                if (id != null)
                    client = context.Clients.Where(c => c.Id == id).Select(c => c).FirstOrDefault();
                else
                    client = new Clients();
                client.Name = name;
                string fileName = Request.Files["logo"].FileName;
                if (!string.IsNullOrEmpty(fileName))
                {
                    if (id > 0)
                        DeleteImage("~/Content/Logos/", client.Logo);
                    fileName = Path.GetFileName(fileName);
                    string filePath = Server.MapPath("~/Content/Logos/" + fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    client.Logo = fileName;
                    if (id == null)
                        context.AddToClients(client);
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Clients");
        }

        public ActionResult DeleteClient(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Clients client = context.Clients.Where(c => c.Id == id).Select(c => c).FirstOrDefault();
                client.Objects.Load();
                foreach (Objects item in client.Objects)
                {
                    DeleteImage("~/Content/Objects", item.Image);
                    DeleteImage("~/Content/Object/Previews", item.Preview);
                    context.DeleteObject(item);
                }

                client.Recomendations.Load();
                foreach (Recomendations item in client.Recomendations)
                {
                    DeleteImage("~/Content/Recomendations/", item.Image);
                    context.DeleteObject(item);
                }

                DeleteImage("~/Content/Logos", client.Logo);
                context.DeleteObject(client);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Clients");
        }

        public ActionResult TooManyObjects()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult AddRecomendation(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddRecomendation(int id, string image, string preview)
        {
            string fileName = Request.Files["image"].FileName;
            string previewName = Request.Files["preview"].FileName;
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(previewName))
            {
                fileName = Path.GetFileName(fileName);
                string filePath = Server.MapPath("~/Content/Recomendations/" + fileName);
                Request.Files["image"].SaveAs(filePath);
                
                previewName = Path.GetFileName(previewName);
                string previewPath = Server.MapPath("~/Content/Recomendations/Previews/" + previewName);
                Request.Files["preview"].SaveAs(previewPath);

                using (DataStorage context = new DataStorage())
                {
                    Recomendations item = new Recomendations();
                    EntityKey key = new EntityKey("DataStorage.Clients", "Id", id);
                    item.ClientsReference.EntityKey = key;
                    item.Image = fileName;
                    item.Preview = previewName;
                    context.AddToRecomendations(item);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Clients");
        }

        public ActionResult DeleteRecomendation(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Recomendations item = context.Recomendations.Where(r => r.Id == id).Select(r => r).FirstOrDefault();
                if (item != null)
                {
                    DeleteImage("~/Content/Recomendations", item.Image);
                    DeleteImage("~/Content/Recomendations/Preview", item.Preview);
                    context.DeleteObject(item);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Clients");
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult AddObject(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddObject(int id, string image, string preview)
        {
            string imageName = Request.Files["image"].FileName;
            string previewName = Request.Files["preview"].FileName;
            if (!string.IsNullOrEmpty(imageName) && !string.IsNullOrEmpty(previewName))
            {
                imageName = Path.GetFileName(imageName);
                string imagePath = Server.MapPath("~/Content/Objects/" + imageName);
                Request.Files["image"].SaveAs(imagePath);

                previewName = Path.GetFileName(previewName);
                string previewPath = Server.MapPath("~/Content/Objects/Previews/" + previewName);
                Request.Files["preview"].SaveAs(previewPath);

                using (DataStorage context = new DataStorage())
                {
                    Objects item = new Objects();
                    EntityKey key = new EntityKey("DataStorage.Clients", "Id", id);
                    item.ClientsReference.EntityKey = key;
                    item.Image = imageName;
                    item.Preview = previewName;
                    context.AddToObjects(item);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Clients");
        }

        public ActionResult DeleteObject(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Objects item = context.Objects.Where(o => o.Id == id).Select(o => o).FirstOrDefault();
                if (item != null)
                {
                    DeleteImage("~/Content/Objects", item.Image);
                    DeleteImage("~/Content/Objects/Previews", item.Preview);
                    context.DeleteObject(item);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Clients");
        }
    }
}
