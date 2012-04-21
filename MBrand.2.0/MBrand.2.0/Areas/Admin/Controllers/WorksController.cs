using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;
using MBrand.Helpers;

namespace MBrand.Areas.Admin.Controllers
{ 
    public class WorksController : Controller
    {
        private const string WorkImagesLocation = "~/Content/workImages";
        private const string WorkBottomImagesLocation = "~/Content/workBottomImages";


        private readonly ContentContainer _db = new ContentContainer();

        //
        // GET: /Admin/Works/Create

        public ActionResult Create(int workGroupId, string redirectTo)
        {
            ViewBag.RedirecTo = redirectTo;
            return View("CreateEdit");
        } 

        //
        // POST: /Admin/Works/Create

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Work work, int workGroupId, string redirectTo, HttpPostedFileBase workImage, HttpPostedFileBase workBottomImage)
        {
            if (ModelState.IsValid)
            {
                if (workImage != null)
                {
                    string fileName = Path.GetFileName(workImage.FileName);
                    fileName = IOHelper.GetUniqueFileName(WorkImagesLocation, fileName);
                    workImage.SaveFile(WorkImagesLocation, fileName);
                    work.Image = fileName;
                }

                if (workBottomImage != null)
                {
                    string fileName = Path.GetFileName(workBottomImage.FileName);
                    fileName = IOHelper.GetUniqueFileName(WorkBottomImagesLocation, fileName);
                    workImage.SaveFile(WorkImagesLocation, fileName);
                    work.BottomImage = fileName;
                }
                work.WorkGroupReference.EntityKey = new EntityKey("ContentContainer.Contents", "Id", workGroupId);
                work.Title = work.Description;
                _db.Contents.AddObject(work);
                _db.SaveChanges();
                return Redirect(redirectTo);  
            }

            return View("CreateEdit", work);
        }
        
        //
        // GET: /Admin/Works/Edit/5

        public ActionResult Edit(string id, string redirectTo)
        {
            ViewBag.RedirecTo = redirectTo;
            Work work = _db.Contents.OfType<Work>().Single(w => w.Name == id);
            return View("CreateEdit", work);
        }

        //
        // POST: /Admin/Works/Edit/5

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(FormCollection form, string redirectTo, HttpPostedFileBase workImage, HttpPostedFileBase workBottomImage)
        {
            int id = int.Parse(form["_id"]);
            Work work = _db.Contents.OfType<Work>().Single(w => w.Id == id);
            if (ModelState.IsValid)
            {
                TryUpdateModel(work, new[] { "Text", "Description", "Name", "Title", "SideBarText" });
                if (workImage != null)
                {
                    if(!string.IsNullOrEmpty(work.Image))
                    {
                        IOHelper.DeleteFile(WorkImagesLocation, work.Image);
                    }

                    string fileName = Path.GetFileName(workImage.FileName);
                    fileName = IOHelper.GetUniqueFileName(WorkImagesLocation, fileName);
                    workImage.SaveFile(WorkImagesLocation, fileName);
                    work.Image = fileName;
                }

                if (workBottomImage != null)
                {
                    if (!string.IsNullOrEmpty(work.BottomImage))
                    {
                        IOHelper.DeleteFile(WorkBottomImagesLocation, work.BottomImage);
                    }

                    string fileName = Path.GetFileName(workBottomImage.FileName);
                    fileName = IOHelper.GetUniqueFileName(WorkBottomImagesLocation, fileName);
                    workBottomImage.SaveFile(WorkBottomImagesLocation, fileName);
                    work.BottomImage = fileName;
                }
                _db.SaveChanges();
                return Redirect(redirectTo);
            }
            return View("CreateEdit", work);
        }

        //
        // POST: /Admin/Works/Delete/5

        public ActionResult Delete(string id, string redirectTo)
        {
            Work work = _db.Contents.OfType<Work>().Single(w => w.Name == id);
            if (!string.IsNullOrEmpty(work.Image))
            {
                IOHelper.DeleteFile(WorkBottomImagesLocation, work.BottomImage);
            }
            if (!string.IsNullOrEmpty(work.Image))
            {
                IOHelper.DeleteFile(WorkImagesLocation, work.Image);
            }
            _db.Contents.DeleteObject(work);
            _db.SaveChanges();
            return Redirect(redirectTo);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}