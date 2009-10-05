using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;
using System.Configuration;

namespace MBrand.Controllers
{
    public class NotesController : Controller
    {
        //
        // GET: /Notes/

        public ActionResult Index(int? id)
        {
            int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
            int currentPage = 0;
            if (id != null)
                currentPage = id.Value - 1;
            if (id == null)
                ViewData["currentPage"] = 1;
            else
                ViewData["currentPage"] = id;
            using (DataStorage context = new DataStorage())
            {
                List<Note> notes = (from note in context.Notes orderby note.Date descending select note).Skip(currentPage*pageSize).Take(pageSize).ToList();
                return View(notes);
            }
        }

        public ActionResult Note(int id, int? currentPage)
        {
            if (currentPage == null)
                ViewData["currentPage"] = 1;
            else
                ViewData["currentPage"] = currentPage;
            using (DataStorage context = new DataStorage())
            {
                Note note = context.Notes.Where(n => n.Id == id).Select(n=>n).FirstOrDefault();
                ViewData["date"] = note.Date.ToString("dd.MM.yyyy");
                return View(note);
            }
        }

    }
}
