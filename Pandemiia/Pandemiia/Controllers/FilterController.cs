using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Pandemiia.Models;

namespace Pandemiia.Controllers
{
    public class FilterController : Controller
    {
        //
        // GET: /Filter/
        public ActionResult All(string typeName, int? pageNumber)
        {
            int totalCount;
            List<Entity> entities = Utils.GetFilteredList("", typeName, pageNumber, out totalCount);
            ViewData["source"] = "All";
            ViewData["typeName"] = (typeName) ?? "All";
            ViewData["entityCount"] = totalCount;
            ViewData["tagName"] = null;
            if (pageNumber != null)
                ViewData["pageNumber"] = pageNumber.Value;
            else
                ViewData["pageNumber"] = 1;
            return View("FilteredList", entities);
        }

        public ActionResult Yours(string typeName, int? pageNumber)
        {
            int totalCount;
            List<Entity> entities = Utils.GetFilteredList("ваше", typeName, pageNumber, out totalCount);
            ViewData["source"] = "Yours";
            ViewData["typeName"] = (typeName) ?? "All";
            ViewData["entityCount"] = totalCount;
            ViewData["tagName"] = null;
            if (pageNumber != null)
                ViewData["pageNumber"] = pageNumber.Value;
            else
                ViewData["pageNumber"] = 1;
            return View("FilteredList", entities);
        }

        public ActionResult Ours(string typeName, int? pageNumber)
        {
            int totalCount;
            List<Entity> entities = Utils.GetFilteredList("наше", typeName, pageNumber, out totalCount);
            ViewData["source"] = "Ours";
            ViewData["typeName"] = (typeName) ?? "All";
            ViewData["entityCount"] = totalCount;
            ViewData["tagName"] = null;
            if (pageNumber != null)
                ViewData["pageNumber"] = pageNumber.Value;
            else
                ViewData["pageNumber"] = 1;
            return View("FilteredList", entities);
        }

        public ActionResult Theirs(string typeName, int? pageNumber)
        {
            int totalCount;
            List<Entity> entities = Utils.GetFilteredList("ихнее", typeName, pageNumber, out totalCount);
            ViewData["source"] = "Theirs";
            ViewData["typeName"] = (typeName) ?? "All";
            ViewData["entityCount"] = totalCount;
            ViewData["tagName"] = null;
            if (pageNumber != null)
                ViewData["pageNumber"] = pageNumber.Value;
            else
                ViewData["pageNumber"] = 1;
            return View("FilteredList", entities);
        }

        public ActionResult Tags(string typeName, int? pageNumber)
        {
            int startIndex = (pageNumber == null || pageNumber == 0) ? 1 : pageNumber.Value;
            startIndex--;
            startIndex *= Settings.PageSize;
            int entitiesCount = Settings.PageSize;
            EntitiesDataContext context = new EntitiesDataContext();
            List<Entity> entities = (from etm in context.EntityTagMappings where etm.Tag.TagName.ToLower() == typeName.ToLower() select etm.Entity).ToList();
            ViewData["entityCount"] = entities.Count;
            entities = entities.Skip(startIndex).Take(entitiesCount).ToList();
            ViewData["source"] = "All";
            ViewData["typeName"] = "All";
            ViewData["tagName"] = typeName;
            if (pageNumber != null)
                ViewData["pageNumber"] = pageNumber.Value;
            else
                ViewData["pageNumber"] = 1;
            return View("FilteredList", entities);
        }

        public ActionResult FilteredList(List<Entity> entityList)
        {
            return View(entityList);
        }

    }
}
