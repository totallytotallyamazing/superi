using System.IO;
using Jackson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jackson.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        SiteContext _context = null;

        public AdminController(SiteContext context)
        {
            _context = context;
        }

        public ActionResult AddGroup(Group group, string currentGroup)
        {
            group.Url = Utils.Transliterator.Transliterate(group.Name);
            _context.Groups.Add(group);
            _context.SaveChanges();
            return Json(group.Url);
        }

        public ActionResult DeleteGroup(string id)
        {
            bool result = true;
            try
            {
                var group = _context.Groups.First(g => g.Url == id);
                DeleteImages(group);
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return Json(result);
        }

        private void DeleteImages(Group group)
        {
            string filesPath = Server.MapPath("~/Files");
            string folderPath = Path.Combine(filesPath, group.Url);
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }
    }
}