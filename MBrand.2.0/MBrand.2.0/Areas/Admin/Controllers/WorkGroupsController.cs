using System.Data;
using System.Linq;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Areas.Admin.Controllers
{ 
    public class WorkGroupsController : Controller
    {
        private readonly ContentContainer _db = new ContentContainer();

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
                _db.Contents.AddObject(workgroup);
                _db.SaveChanges();
                return Redirect((string)TempData["redirectTo"]);  
            }

            return View(workgroup);
        }
        
        //
        // GET: /Admin/WorkGroups/Edit/5
 
        public ActionResult Edit(int id, string redirectTo)
        {
            WorkGroup workgroup = _db.Contents.OfType<WorkGroup>().Single(w => w.Id == id);
            return View(workgroup);
        }

        //
        // POST: /Admin/WorkGroups/Edit/5

        [HttpPost]
        public ActionResult Edit(WorkGroup workgroup)
        {
            if (ModelState.IsValid)
            {
                _db.Contents.Attach(workgroup);
                _db.ObjectStateManager.ChangeObjectState(workgroup, EntityState.Modified);
                _db.SaveChanges();
                return Redirect((string)TempData["redirectTo"]);  
            }
            return View(workgroup);
        }


        //
        // POST: /Admin/WorkGroups/Delete/5

        public ActionResult Delete(int id, string redirectTo)
        {
            WorkGroup workgroup = _db.Contents.OfType<WorkGroup>().Single(w => w.Id == id);
            _db.Contents.DeleteObject(workgroup);
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