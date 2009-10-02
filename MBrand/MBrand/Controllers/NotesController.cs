using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class NotesController : Controller
    {
        //
        // GET: /Notes/

        public ActionResult Index(int? id)
        {
            using (DataStorage context = new DataStorage())
            {
                List<Note> notes = (from note in context.Notes select note).ToList();
                return View(notes);
            }
        }

    }
}
