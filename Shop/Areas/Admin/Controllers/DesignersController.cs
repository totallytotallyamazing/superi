﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Mvc.Helpers;
using System.IO;
using Dev.Helpers;
using System.Collections.ObjectModel;

namespace Shop.Areas.Admin.Controllers
{
    public class DesignersController : Controller
    {
        //
        // GET: /Admin/Designers/

        public ActionResult Index()
        {
            using (var context = new DesignerStorage())
            {
                var designers = context.Designer.Select(d => d).ToList();
                return View(designers);
            }
        }

        [OutputCache(VaryByParam = "*", NoStore = true, Duration = 1)]
        public ActionResult AddEdit(int? id)
        {
            Designer designer = null;
            if (id.HasValue)
            {
                using (var context = new DesignerStorage())
                {
                    designer = context.Designer.First(d => d.Id == id.Value);
                }
            }
            return View(designer);
        }

        [HttpPost]
        public ActionResult AddEdit(FormCollection form)
        {
            using (var context = new DesignerStorage())
            {
                int id;
                Designer designer;
                if (int.TryParse(form["Id"], out id))
                    designer = context.Designer.First(d => d.Id == id);
                else
                {
                    designer = new Designer();
                    context.AddToDesigner(designer);
                }
                TryUpdateModel(designer, new string[] { "Name","NameF", "Url", "Summary" }, form.ToValueProvider());
                designer.Summary = HttpUtility.HtmlDecode(form["Summary"]);

                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    if (!string.IsNullOrEmpty(designer.Logo))
                    {
                        IOHelper.DeleteFile("~/Content/DesignerLogos", designer.Logo);
                    }
                    string fileName = IOHelper.GetUniqueFileName("~/Content/DesignerLogos", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/DesignerLogos");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    designer.Logo = fileName;
                }


                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        /*
        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        public ActionResult Rooms(int id)
        {
            ViewData["id"] = id;
            using (var context = new DesignerStorage())
            {
                var rooms = context.DesignerRoom.ToList();
                Designer designer = context.Designer.Include("DesignerContent").Where(d => d.Id == id).First();
                int[] roomsSelected = designer.DesignerContent.Select(r => r.DesignerRoom.Id).ToArray();
                ViewData["roomsSelected"] = roomsSelected;
                return View(rooms);
            }
        }
        */

        public ActionResult Rooms(int id)
        {
            using (var context = new DesignerStorage())
            {
                ViewData["designerId"] = id;
                var dc = context.DesignerContent.Include("Designer").Where(d => d.Designer.Id == id).ToList();
                return View(dc);
            }
        }

        public ActionResult AddEditRoom(int designerId, int? id)
        {
            ViewData["designerId"] = designerId;
            DesignerContent dc = null;
            if (id.HasValue)
            {
                using (var context = new DesignerStorage())
                {
                    dc = context.DesignerContent.First(d => d.Id == id.Value);
                }
            }
            return View(dc);
        }

        [HttpPost]
        public ActionResult AddEditRoom(FormCollection form)
        {
            using (var context = new DesignerStorage())
            {
                int designerId = Convert.ToInt32(form["designerId"]);

                Designer designer = context.Designer.Where(d => d.Id == designerId).First();


                int id;
                DesignerContent dc;
                if (int.TryParse(form["Id"], out id))
                    dc = context.DesignerContent.First(d => d.Id == id);
                else
                {
                    dc = new DesignerContent();
                    designer.DesignerContent.Add(dc);
                }
                TryUpdateModel(dc, new string[] { "RoomName","RoomType" }, form.ToValueProvider());

                context.SaveChanges();

                return RedirectToAction("Rooms", "Designers", new {area = "Admin", id = designer.Id});
            }
        }

        
        public ActionResult Delete(int id)
        {
            using (var context = new DesignerStorage())
            {
                // TODO: Нужна доработка
                //var designer = context.Designer.Where(d => d.Id == id).First();
                //context.DeleteObject(designer);
                //context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRoom(int designerId, int id)
        {
            using (var context = new DesignerStorage())
            {
                //var designer = context.Designer.Where(d => d.Id == designerId).First();
                DesignerContent dc = context.DesignerContent.Include("DesignerContentImages").Where(d => d.Id == id).First();

                foreach (var image in dc.DesignerContentImages)
                {
                    if (!string.IsNullOrEmpty(image.ImageSource))
                    {
                        IOHelper.DeleteFile("~/Content/DesignerPhotos", image.ImageSource);
                    }
                    image.DesignerContentReference = null;
                    // TODO: Нужна доработка
                    //context.DeleteObject(image);
                }

                dc.DesignerReference = null;
                context.DeleteObject(dc);
                context.SaveChanges();
                return RedirectToAction("Rooms", "Designers", new { area = "Admin", id = designerId });
            }
        }

        public ActionResult EditContent(int id)
        {
            using (var context = new DesignerStorage())
            {
                var dc = context.DesignerContent.Include("Designer").Include("DesignerContentImages").Where(c => c.Id == id).First();


                return View(dc);
            }
           
        }

        [HttpPost]
        public ActionResult EditContent(int id, FormCollection form)
        {
            using (var context = new DesignerStorage())
            {
                var dc = context.DesignerContent.Include("Designer").Where(c => c.Id == id).First();

                TryUpdateModel(dc, new string[] { "Summary" }, form.ToValueProvider());
                dc.Summary = HttpUtility.HtmlDecode(form["Summary"]);
                context.SaveChanges();

                return RedirectToAction("Index", "Designers", new {area = "", id = dc.Designer.Url});
            }
        }

        [HttpPost]
        public ActionResult AddPhoto(int id, FormCollection form)
        {
            using (var context = new DesignerStorage())
            {
                var dc = context.DesignerContent.Include("Designer").Where(c => c.Id == id).First();
                
                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    string fileName = IOHelper.GetUniqueFileName("~/Content/DesignerPhotos", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/DesignerPhotos");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    dc.DesignerContentImages.Add(new DesignerContentImages {ImageSource = fileName});
                    context.SaveChanges();
                }
                
                return RedirectToAction("Index", "Designers", new { area = "", id = dc.Designer.Url });
            }
        }

        public ActionResult DeletePhoto(/*int photoId, int degignerContentId*/ int id)
        {
            using (var context = new DesignerStorage())
            {
                var photo = context.DesignerContentImages.Include("DesignerContent").Where(p => p.Id == id).First();
                int dcId = photo.DesignerContent.Id;
                var designerContent = context.DesignerContent.Include("Designer").Where(dc => dc.Id == dcId).First();
                if (!string.IsNullOrEmpty(photo.ImageSource))
                {
                    IOHelper.DeleteFile("~/Content/DesignerPhotos", photo.ImageSource);
                }
                context.DeleteObject(photo);
                context.SaveChanges();
                return RedirectToAction("Index", "Designers", new { area = "", id = designerContent.Designer.Url });
            }
        }


    }
}
