using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Areas.Admin.Controllers
{ 
    public class WorksController : Controller
    {
        private readonly ContentContainer _db = new ContentContainer();

        //
        // GET: /Admin/Works/Create

        public ActionResult Create(string redirectTo)
        {
            ViewBag.RedirecTo = redirectTo;
            return View("CreateEdit");
        } 

        //
        // POST: /Admin/Works/Create

        [HttpPost]
        public ActionResult Create(Work work, string redirectTo, HttpPostedFileBase image, HttpPostedFileBase bottomImage)
        {
            if (ModelState.IsValid)
            {
                _db.Contents.AddObject(work);
                //_db.SaveChanges();
                return Redirect(redirectTo);  
            }

            return View("CreateEdit", work);
        }
        
        //
        // GET: /Admin/Works/Edit/5
 
        public ActionResult Edit(string id)
        {
            Work work = _db.Contents.OfType<Work>().Single(w => w.Name == id);
            return View("CreateEdit", work);
        }

        //
        // POST: /Admin/Works/Edit/5

        [HttpPost]
        public ActionResult Edit(Work work, string redirectTo, HttpPostedFileBase image, HttpPostedFileBase bottomImage)
        {
            if (ModelState.IsValid)
            {
                _db.Contents.Attach(work);
                _db.ObjectStateManager.ChangeObjectState(work, EntityState.Modified);
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