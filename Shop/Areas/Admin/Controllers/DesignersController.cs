using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Mvc.Helpers;
using System.IO;
using Dev.Helpers;
using System.Collections.ObjectModel;

namespace Shop.Areas.Admin.Controllers
{
    public class DesignersController : Controller
    {
        //
        // GET: /Admin/Designers/

        public ActionResult Index()
        {
            using (var context = new DesignerStorage())
            {
                var designers = context.Designer.Select(d => d).ToList();
                return View(designers);
            }
        }

        [OutputCache(VaryByParam = "*", NoStore = true, Duration = 1)]
        public ActionResult AddEdit(int? id)
        {
            Designer designer = null;
            if (id.HasValue)
            {
                using (var context = new DesignerStorage())
                {
                    designer = context.Designer.First(d => d.Id == id.Value);
                }
            }
            return View(designer);
        }

        [HttpPost]
        public ActionResult AddEdit(FormCollection form)
        {
            using (var context = new DesignerStorage())
            {
                int id;
                Designer designer;
                if (int.TryParse(form["Id"], out id))
                    designer = context.Designer.First(d => d.Id == id);
                else
                {
                    designer = new Designer();
                    context.AddToDesigner(designer);
                }
                TryUpdateModel(designer, new string[] { "Name", "Url", "Summary", "Title" }, form.ToValueProvider());
                designer.Summary = HttpUtility.HtmlDecode(form["Summary"]);
                designer.Title = HttpUtility.HtmlDecode(form["Title"]);

                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    if (!string.IsNullOrEmpty(designer.Logo))
                    {
                        IOHelper.DeleteFile("~/Content/DesignerLogos", designer.Logo);
                    }
                    string fileName = IOHelper.GetUniqueFileName("~/Content/DesignerLogos", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/DesignerLogos");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    designer.Logo = fileName;
                }


                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        public ActionResult Rooms(int id)
        {
            ViewData["id"] = id;
            using (var context = new DesignerStorage())
            {
                var rooms = context.DesignerRoom.ToList();
                Designer designer = context.Designer.Include("DesignerContent").Where(d => d.Id == id).First();
                int[] roomsSelected = designer.DesignerContent.Select(r => r.DesignerRoom.Id).ToArray();
                ViewData["roomsSelected"] = roomsSelected;
                return View(rooms);
            }
        }


        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        [HttpPost]
        public void Rooms(int id, FormCollection form)
        {
            using (DesignerStorage context = new DesignerStorage())
            {
                PostData data = form.ProcessPostData(excludeFields: "id");

                Collection<int> addAttributeIds = new Collection<int>();
                Collection<int> removeAttributeIds = new Collection<int>();
                foreach (var item in data)
                {
                    int attributeId = int.Parse(item.Key);
                    bool contains = bool.Parse(item.Value["room"]);
                    if (contains)
                        addAttributeIds.Add(attributeId);
                    else
                        removeAttributeIds.Add(attributeId);
                }

                Designer designer = context.Designer.Where(d => d.Id == id).First();

                AddDesignerContentToDesigner(context, designer, addAttributeIds);
                RemoveDesignerContentToDesigner(context, designer, removeAttributeIds);

                context.SaveChanges();
            }
            Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close();</script>");
        }


        private void AddDesignerContentToDesigner(DesignerStorage context, Designer designer, Collection<int> roomIds)
        {
            foreach (var roomId in roomIds)
            {
                if (designer.DesignerContent.Where(r => r.RoomId == roomId).Count() == 0)
                {
                    DesignerRoom room = context.DesignerRoom.Where(r => r.Id == roomId).First();
                    DesignerContent dc = new DesignerContent();
                    dc.DesignerRoom = room;
                    designer.DesignerContent.Add(dc);
                }
            }

        }

        private void RemoveDesignerContentToDesigner(DesignerStorage context, Designer designer, Collection<int> roomIds)
        {
            foreach (var roomId in roomIds)
            {
                DesignerContent dc = designer.DesignerContent.Where(r => r.RoomId == roomId).FirstOrDefault();
                if (dc != null)
                {
                    dc.DesignerRoom = null;
                    designer.DesignerContent.Remove(dc);
                }
            }
        }



    }
}
