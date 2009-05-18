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
                    type = "�����������";
                    break;
                case "Video":
                    type = "�����";
                    break;
                case "Music":
                    type = "������";
                    break;
                case "Reading":
                    type = "�����";
                    break;
                case "Other":
                    type = "������";
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
            entities = _context.Entities.Select(e => e).Where(e => e.EntitySource.Name == "����").ToList();
            if (!string.IsNullOrEmpty(type))
                entities = entities.Where(e => e.EntityType.Name == type).ToList();
            return View("FilteredList", entities);
        }

        public ActionResult Ours(string typeName, int pageNumber)
        {
            string type = ConvertTypeName(typeName);
            List<Entity> entities;
            entities = _context.Entities.Select(e => e).Where(e => e.EntitySource.Name == "����").ToList();
            if (!string.IsNullOrEmpty(type))
                entities = entities.Where(e => e.EntityType.Name == type).ToList();
            return View("FilteredList", entities);
        }

        public ActionResult Theirs(string typeName, int pageNumber)
        {
            string type = ConvertTypeName(typeName);
            List<Entity> entities;
            entities = _context.Entities.Select(e => e).Where(e => e.EntitySource.Name == "�����").ToList();
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
