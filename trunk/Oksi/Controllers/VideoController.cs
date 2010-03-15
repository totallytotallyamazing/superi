using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Oksi.Models;

namespace Oksi.Controllers
{
    public class VideoController : Controller
    {
        public ActionResult Index()
        {
            using (DataStorage context = new DataStorage())
            {
                List<Clip> clips = context.Clips.OrderBy(c => c.SortOrder).ToList();
                return View(clips); 
            }
        }
    }
}
