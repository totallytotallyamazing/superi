using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MBrand.Models;


namespace MBrand.Controllers
{
    public class SeeController : Controller
    {
        //
        // GET: /See/

        public ActionResult Index()
        {
            return RedirectToAction("Sites");
        }

        private ActionResult ShowGroupContent(int id)
        {
            using (var context = new DataStorage2())
            {
                var group = context.WorkGroups.Include("Works").Where(wg => wg.Id == id).Select(wg => wg).FirstOrDefault();
                ViewData["workGroupName"] = group.Name;
                ViewData["title"] = group.Title;
                ViewData["groupId"] = id;
                ViewData["keywords"] = group.SeoKeywords;
                ViewData["description"] = group.SeoDescription;
                return View("WorkGroupContents", group.Works);
            }
        }

        public ActionResult Site(int? id)
        {
            ViewData["workType"] = WorkType.Site;

            if (id == null)
            {
                using (var context = new DataStorage2())
                {
                    var sc = context.SeoContent.Where(c => c.WorkType == (int) WorkType.Site).First();
                    ViewData["keywords"] = sc.Keywords;
                    ViewData["description"] = sc.Description;
                    return View(sc);
                }
            }
            else
            {
                return ShowGroupContent(id.Value);
            }
        }

        public ActionResult Vcard(int? id)
        {
            ViewData["workType"] = WorkType.Vcard;

            if (id == null)
            {
                using (var context = new DataStorage2())
                {
                    var sc = context.SeoContent.Where(c => c.WorkType == (int)WorkType.Vcard).First();
                    ViewData["keywords"] = sc.Keywords;
                    ViewData["description"] = sc.Description;
                    return View(sc);
                }
            }
            else
            {
                return ShowGroupContent(id.Value);
            }
        }

        public ActionResult Logo(int? id)
        {
            ViewData["workType"] = WorkType.Logo;

            if (id == null)
            {
                return View();
            }
            else
            {
                return ShowGroupContent(id.Value);
            }
        }

        public ActionResult Poly(int? id)
        {
            ViewData["workType"] = WorkType.Poly;

            if (id == null)
            {
                using (var context = new DataStorage2())
                {
                    var sc = context.SeoContent.Where(c => c.WorkType == (int)WorkType.Poly).First();
                    ViewData["keywords"] = sc.Keywords;
                    ViewData["description"] = sc.Description;
                    return View(sc);
                }
            }
            else
            {
                return ShowGroupContent(id.Value);
            }
        }

        public ActionResult Text(int? id)
        {
            ViewData["workType"] = WorkType.Text;

            if (id == null)
            {
                return View();
            }
            else
            {
                return ShowGroupContent(id.Value);
            }
        }

        public ActionResult Video(int? id)
        {
            ViewData["workType"] = WorkType.Video;

            if (id == null)
            {
                using (var context = new DataStorage2())
                {
                    var sc = context.SeoContent.Where(c => c.WorkType == (int)WorkType.Video).First();
                    ViewData["keywords"] = sc.Keywords;
                    ViewData["description"] = sc.Description;
                    return View(sc);
                }
            }
            else
            {
                return ShowGroupContent(id.Value);
            }
        }

    }
}
