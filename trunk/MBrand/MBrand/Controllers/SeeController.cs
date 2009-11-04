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



        public ActionResult Site(int? id)
        {
            string firstDescription;
            string firstImage;
            string firstPreview;
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Site, out firstImage, out firstDescription, out firstPreview));
            ViewData["firstImage"] = firstImage;
            ViewData["firstDescription"] = firstDescription;
            ViewData["firstPreview"] = firstPreview;
            ViewData["baseFolder"] = "/Content/Images/site/";
            return View();
        }

        public ActionResult Vcard(int? id)
        {
            string firstDescription;
            string firstImage;
            string firstPreview;
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Vcard, out firstImage, out firstDescription, out firstPreview));
            ViewData["firstImage"] = firstImage;
            ViewData["firstDescription"] = firstDescription;
            ViewData["firstPreview"] = firstPreview;
            ViewData["baseFolder"] = "/Content/Images/vcard/";
            return View();
        }

        public ActionResult Logo(int? id)
        {
            string firstDescription;
            string firstImage;
            string firstPreview;
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Logo, out firstImage, out firstDescription, out firstPreview));
            ViewData["firstImage"] = firstImage;
            ViewData["firstDescription"] = firstDescription;
            ViewData["firstPreview"] = firstPreview;
            ViewData["baseFolder"] = "/Content/Images/logo/";
            return View();
        }

        public ActionResult Poly(int? id)
        {
            string firstDescription;
            string firstImage;
            string firstPreview;
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Poly, out firstImage, out firstDescription, out firstPreview));
            ViewData["firstImage"] = firstImage;
            ViewData["firstDescription"] = firstDescription;
            ViewData["firstPreview"] = firstPreview;
            ViewData["baseFolder"] = "/Content/Images/poly/";
            return View();
        }

        public ActionResult Text(int? id)
        {
            string firstDescription;
            string firstImage;
            string firstPreview;
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Text, out firstImage, out firstDescription, out firstPreview));
            ViewData["firstImage"] = firstImage;
            ViewData["firstDescription"] = firstDescription;
            ViewData["firstPreview"] = firstPreview;
            ViewData["baseFolder"] = "/Content/Images/text/";
            return View();
        }

        public ActionResult ShowWork(int id) 
        {
            using(DataStorage context = new DataStorage())
            {
                var result = context.Works.Where(w => w.Id == id).Select(
                    w => new
                    {
                        Image = w.Image,
                        Preview = w.Preview,
                        Description = w.Description
                    }
                ).First();
                return Json(result, "application/javascript");
            }
        }

        private string MakeArray(string[] ids)
        {
            string array = string.Join(",", ids);
            return "[" + array + "];";
        }

        private string[] GetWorks(WorkType type, out string firstImage, out string firstDescription, out string firstPreview)
        {
            string[] result = null;
            using (DataStorage context = new DataStorage())
            {
                int typeId = (int)type;
                var randomizer = new Random();
                List<Work> works = (from work in context.Works
                          where work.Type == typeId
                          select work
                          ).ToList();
                Work[] randomized = works.Select(w => w).OrderBy(w => randomizer.Next()).ToArray();
                if (randomized.Length > 0)
                {
                    firstImage = randomized[0].Image;
                    firstPreview = randomized[0].Preview;
                    firstDescription = randomized[0].Description;
                }
                else
                {
                    firstImage = string.Empty;
                    firstPreview = string.Empty;
                    firstDescription = string.Empty;
                }
                result = randomized.Select(i => i.Id.ToString()).OrderBy(i => randomizer.Next()).ToArray();
            }
            return result;
        }
    }
}
