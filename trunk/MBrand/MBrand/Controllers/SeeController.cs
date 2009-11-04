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
            using (DataStorage context = new DataStorage())
            {
                WorkGroup group = context.WorkGroups.Include("Works").Where(wg => wg.Id == id).Select(wg => wg).FirstOrDefault();
                ViewData["workGroupName"] = group.Name;
                return View("WorkGroupContents", group.Works);
            }
        }

        public ActionResult Site(int? id)
        {
            ViewData["workType"] = WorkType.Site;

            if (id == null)
            {
                return View();
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
                return View();
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
                return View();
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

        //public ActionResult ShowWork(int id) 
        //{
        //    using(DataStorage context = new DataStorage())
        //    {
        //        var result = context.Works.Where(w => w.Id == id).Select(
        //            w => new
        //            {
        //                Image = w.Image,
        //                Preview = w.Preview,
        //                Description = w.Description
        //            }
        //        ).First();
        //        return Json(result, "application/javascript");
        //    }
        //}

        //private string MakeArray(string[] ids)
        //{
        //    string array = string.Join(",", ids);
        //    return "[" + array + "];";
        //}

        //private string[] GetWorks(WorkType type, out string firstImage, out string firstDescription, out string firstPreview)
        //{
        //    string[] result = null;
        //    using (DataStorage context = new DataStorage())
        //    {
        //        int typeId = (int)type;
        //        var randomizer = new Random();
        //        List<Work> works = (from work in context.Works
        //                  where work.Type == typeId
        //                  select work
        //                  ).ToList();
        //        Work[] randomized = works.Select(w => w).OrderBy(w => randomizer.Next()).ToArray();
        //        if (randomized.Length > 0)
        //        {
        //            firstImage = randomized[0].Image;
        //            firstPreview = randomized[0].Preview;
        //            firstDescription = randomized[0].Description;
        //        }
        //        else
        //        {
        //            firstImage = string.Empty;
        //            firstPreview = string.Empty;
        //            firstDescription = string.Empty;
        //        }
        //        result = randomized.Select(i => i.Id.ToString()).OrderBy(i => randomizer.Next()).ToArray();
        //    }
        //    return result;
        //}
    }
}
