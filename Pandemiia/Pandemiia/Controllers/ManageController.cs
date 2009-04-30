using System;
using System.Collections.Generic;
using System.Collections;
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
        public ActionResult EditEntity(FormCollection frm)
        {
            Entity entity = _context.Entities.SingleOrDefault(en => en.ID == int.Parse(frm["ID"]));
            entity.Content = Server.HtmlDecode(frm["Content"]);
            entity.Description = Server.HtmlDecode(frm["Description"]);
            entity.Title = frm["Title"];
            entity.Date = DateTime.Parse(frm["Date"]);
            entity.SourceID = int.Parse(frm["SourceID"]);
            entity.TypeID = int.Parse(frm["TypeID"]);
            //_context.Entities.InsertOnSubmit(entity);
            _context.SubmitChanges();
            return RedirectToAction("Entities");  
        }

        public ActionResult DeleteEntity(int Id)
        {
            Entity entity = _context.Entities.SingleOrDefault(en => en.ID == Id);
            _context.Entities.DeleteOnSubmit(entity);
            _context.SubmitChanges();
            return RedirectToAction("Entities"); 
        }

        public ActionResult EditEntity(int Id)
        {
            //ViewData["EntitySources"] = 
            List<EntitySource> entitySources = _context.EntitySources.Select(es => es).ToList();
            List<EntityType> entityTypes = _context.EntityTypes.Select(es => es).ToList();

            List<SelectListItem> sliSources = new List<SelectListItem>();
            List<SelectListItem> sliTypes = new List<SelectListItem>();
            Entity entity = _context.Entities.SingleOrDefault(e => e.ID == Id);
            foreach (EntitySource source in entitySources)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = source.Name;
                sli.Value = source.ID.ToString();
                sli.Selected = (source.ID == entity.SourceID);
                sliSources.Add(sli);
            }

            foreach (EntityType type in entityTypes)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = type.Name;
                sli.Value = type.ID.ToString();
                sli.Selected = (type.ID == entity.TypeID);
                sliTypes.Add(sli);
            }
            ViewData["EntitySources"] = sliSources;
            ViewData["EntytyTypes"] = sliTypes;
            return View(entity);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateEntity(FormCollection frm)
        {
            Entity entity = new Entity();
            entity.Content = Server.HtmlDecode(frm["Content"]);
            entity.Description = Server.HtmlDecode(frm["Description"]);
            entity.Title = frm["Title"];
            entity.Date = DateTime.Parse(frm["Date"]);
            entity.SourceID = int.Parse(frm["SourceID"]);
            entity.TypeID = int.Parse(frm["TypeID"]);
            _context.Entities.InsertOnSubmit(entity);
            _context.SubmitChanges();
            return RedirectToAction("Entities");   
        }        

    }
}
