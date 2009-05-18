using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandemiia.Models;

namespace Pandemiia.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        EntitiesDataContext _context = new EntitiesDataContext();

        public ActionResult Index()
        {
            List<Entity> result = _context.Entities.Select(e => e).OrderByDescending(e=>e.Date).ToList();
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
    }
}
