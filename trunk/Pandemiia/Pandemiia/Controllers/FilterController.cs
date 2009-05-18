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
        EntitiesDataContext _context = new EntitiesDataContext();

        private string ConvertTypeName(string typeName)
        {
            string type = "";
            switch (typeName)
            {
                case "Image":
                    type = "Изображения";
                    break;
                case "Video":
                    type = "Видео";
                    break;
                case "Music":
                    type = "Музыка";
                    break;
                case "Reading":
                    type = "Чтиво";
                    break;
                case "Other":
                    type = "Другое";
                    break;
            }
            return type;        
        }

        public ActionResult All(string typeName, int pageNumber)
        {
            string type = ConvertTypeName(typeName);
            List<Entity> entities;
            entities = _context.Entities.Select(e => e).ToList();
            if (!string.IsNullOrEmpty(type))
                entities = entities.Where(e => e.EntityType.Name == type).ToList();
            return View("FilteredList", entities);
        }

        public ActionResult Yours(string typeName, int pageNumber)
        {
            string type = ConvertTypeName(typeName);
            List<Entity> entities;
            entities = _context.Entities.Select(e => e).Where(e => e.EntitySource.Name == "ваше").ToList();
            if (!string.IsNullOrEmpty(type))
                entities = entities.Where(e => e.EntityType.Name == type).ToList();
            return View("FilteredList", entities);
        }

        public ActionResult Ours(string typeName, int pageNumber)
        {
            string type = ConvertTypeName(typeName);
            List<Entity> entities;
            entities = _context.Entities.Select(e => e).Where(e => e.EntitySource.Name == "наше").ToList();
            if (!string.IsNullOrEmpty(type))
                entities = entities.Where(e => e.EntityType.Name == type).ToList();
            return View("FilteredList", entities);
        }

        public ActionResult Theirs(string typeName, int pageNumber)
        {
            string type = ConvertTypeName(typeName);
            List<Entity> entities;
            entities = _context.Entities.Select(e => e).Where(e => e.EntitySource.Name == "ихнее").ToList();
            if (!string.IsNullOrEmpty(type))
                entities = entities.Where(e => e.EntityType.Name == type).ToList();
            return View("FilteredList", entities);
        }

        public ActionResult FilteredList(List<Entity> entityList)
        {
            return View(entityList);
        }

    }
}
