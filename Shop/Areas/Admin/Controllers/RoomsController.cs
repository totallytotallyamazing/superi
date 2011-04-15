using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class RoomsController : Controller
    {
        //
        // GET: /Admin/Rooms/

        public ActionResult Index()
        {
            using (var context = new DesignerStorage())
            {
                var rooms = context.DesignerRoom.Select(r => r).ToList();
                return View(rooms);
            }
        }

        [OutputCache(VaryByParam = "*", NoStore = true, Duration = 1)]
        public ActionResult AddEdit(int? id)
        {
            DesignerRoom room = null;
            if (id.HasValue)
            {
                using (var context = new DesignerStorage())
                {
                    room = context.DesignerRoom.First(r => r.Id == id.Value);
                }
            }
            return View(room);
        }

        [HttpPost]
        public ActionResult AddEdit(FormCollection form)
        {
            using (var context = new DesignerStorage())
            {
                int id;
                DesignerRoom room;
                if (int.TryParse(form["Id"], out id))
                    room = context.DesignerRoom.First(d => d.Id == id);
                else
                {
                    room = new DesignerRoom();
                    context.AddToDesignerRoom(room);
                }
                TryUpdateModel(room, new string[] { "Name" }, form.ToValueProvider());
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
