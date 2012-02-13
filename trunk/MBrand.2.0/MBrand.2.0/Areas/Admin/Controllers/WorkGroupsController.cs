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
    public class WorkGroupsController : Controller
    {
        private ContentContainer db = new ContentContainer();

        //
        // GET: /Admin/WorkGroups/Create

        public ActionResult Create(string redirectTo)
        {
            TempData["redirectTo"] = redirectTo;
            return View();
        } 

        //
        // POST: /Admin/WorkGroups/Create

        [HttpPost]
        public ActionResult Create(WorkGroup workgroup)
        {
            if (ModelState.IsValid)
            {
                db.Contents.AddObject(workgroup);
                db.SaveChanges();
                return Redirect((string)TempData["redirectTo"]);  
            }

            return View(workgroup);
        }
        
        //
        // GET: /Admin/WorkGroups/Edit/5
 
        public ActionResult Edit(int id, string redirectTo)
        {
            WorkGroup workgroup = db.Contents.OfType<WorkGroup>().Single(w => w.Id == id);
            return View(workgroup);
        }

        //
        // POST: /Admin/WorkGroups/Edit/5

        [HttpPost]
        public ActionResult Edit(WorkGroup workgroup)
        {
            if (ModelState.IsValid)
            {
                db.Contents.Attach(workgroup);
                db.ObjectStateManager.ChangeObjectState(workgroup, EntityState.Modified);
                db.SaveChanges();
                return Redirect((string)TempData["redirectTo"]);  
            }
            return View(workgroup);
        }


        //
        // POST: /Admin/WorkGroups/Delete/5

        public ActionResult Delete(int id, string redirectTo)
        {
            WorkGroup workgroup = db.Contents.OfType<WorkGroup>().Single(w => w.Id == id);
            db.Contents.DeleteObject(workgroup);
            db.SaveChanges();
            return Redirect(redirectTo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}