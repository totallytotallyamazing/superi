using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;

namespace Dev.Controllers
{
    public class ArticlesController : Controller
    {
        public ActionResult Index(string language)
        {
            using (DataStorage context = new DataStorage())
            { 
                
            }
            return View();
        }
    }
}
