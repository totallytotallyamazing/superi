using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Pandemiia.Models;


namespace Pandemiia.Controllers
{
    [Authorize(Roles="Admin")]
    public class ManageController : Controller
    {
        EntitiesDataContext _context = new EntitiesDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entities()
        {

            return View(_context.Entities.Select(ent=>ent).ToList());
        }

        public ActionResult CreateEntity()
        {
            ViewData["EntitySources"] = _context.EntitySources.Select(es => es);
            ViewData["EntityTypes"] = _context.EntityTypes.Select(es => es);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateEntity(FormCollection frm)
        {
            return RedirectToAction("Entities");   
        }
        //public ActionResult CreateEntity([Bind(Exclude="ID")]Entity entity)
        //{
        //    _context.Entities.InsertOnSubmit(entity);
        //    _context.SubmitChanges();
        //    return RedirectToAction("Entities");
        //}

        

    }
}
