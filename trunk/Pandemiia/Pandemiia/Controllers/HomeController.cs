using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandemiia.Models;

namespace Pandemiia.Controllers
{
    public class HomeController : Controller
    {
        EntitiesDataContext _context = new EntitiesDataContext();

        public ActionResult Index()
        {
            ViewData["typeName"] = "All";
            ViewData["source"] = "All";
            ViewData["entityCount"] = _context.Entities.Count();
            List<Entity> result = Utils.GetEntityPage(null);
            return View(result);
        }

        public ActionResult Page(int? id)
        {
            ViewData["typeName"] = "All";
            ViewData["source"] = "All";
            List<Entity> result = Utils.GetEntityPage(id);
            ViewData["entityCount"] = _context.Entities.Count();
            if(id!=null)
                ViewData["pageNumber"] = id.Value;
            else
                ViewData["pageNumber"] = 1;
            return View(result);
        }

        public ActionResult EntityList(List<Entity> list)
        {
            return View(list);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Entity(Entity entity)
        {
            return View(entity);
        }

        public ActionResult EntityDetails(int id)
        {
            Entity entity = _context.Entities.SingleOrDefault(e => e.ID == id);
            return View(entity);
        }

        public ActionResult EntityVideos(Entity entity)
        {
            return View(entity);
        }

        public ActionResult EntityImages(Entity entity)
        {
            return View(entity);
        }

        public ActionResult EntityMusics(Entity entity)
        {
            return View(entity);
        }
    }
}
