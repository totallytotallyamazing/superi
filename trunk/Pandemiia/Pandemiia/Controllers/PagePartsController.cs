using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Pandemiia.Models;

namespace Pandemiia.Controllers
{
    public class PagePartsController : Controller
    {
        public ActionResult Pager(int entitiesCount,  int pageNumber, string source, string typeName)
        {
            int pagesCount = entitiesCount / Settings.PageSize;
            if (entitiesCount % Settings.PageSize > 0)
                pagesCount++;
            int[] pages = new int[pagesCount];
            for (int i = 1; i <= pagesCount; i++)
                pages[i - 1] = i;
            ViewData["source"] = source;
            ViewData["typeName"] = typeName;
            ViewData["pagesCount"] = pagesCount;
            ViewData["pageNumber"] = pageNumber;
            return View(pages);
        }

        public ActionResult Filter(string source, string typeName)
        {
            ViewData["source"] = source;
            ViewData["typeName"] = typeName;
            return View();
        }
    }
}
