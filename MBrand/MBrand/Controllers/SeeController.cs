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

        public ActionResult Sites()
        {
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Site));
            ViewData["baseFolder"] = "~/Content/Images/sites/";
            return View();
        }

        public ActionResult Vcards()
        {
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Vcard));
            ViewData["baseFolder"] = "~/Content/Images/vcards/";
            return View();
        }

        public ActionResult Logos()
        {
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Logo));
            ViewData["baseFolder"] = "~/Content/Images/logos/";
            return View();
        }

        public ActionResult Poly()
        {
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Poly));
            ViewData["baseFolder"] = "~/Content/Images/poly/";
            return View();
        }

        public ActionResult Text()
        {
            ViewData["workIds"] = MakeArray(GetWorks(WorkType.Text));
            ViewData["baseFolder"] = "~/Content/Images/text/";
            return View();
        }

        public ActionResult ShowWork(int id) 
        {
            using(DataStorage context = new DataStorage())
            {
                var result = context.Works.Where(w => w.Id == id).Select(
                    w => new
                    {
                        image = w.Image,
                        preview = w.Preview,
                        description = w.Description
                    }
                );
            return Json(result);
            }
        }

        private string MakeArray(string[] ids)
        {
            string array = string.Join(",", ids);
            return "new Array(" + array + ");";
        }

        private string[] GetWorks(WorkType type)
        {
            string[] result = null;
            using (DataStorage context = new DataStorage())
            {
                int typeId = (int)type;
                var randomizer = new Random();
                int[] workIds = (from work in context.Works
                          where work.Type == typeId
                          select work.Id
                          ).ToArray();
                result = workIds.Select(i => i.ToString()).OrderBy(i => randomizer.Next()).ToArray();
            }
            return result;
        }
    }
}
