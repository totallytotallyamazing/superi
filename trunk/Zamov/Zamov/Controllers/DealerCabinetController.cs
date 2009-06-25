using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Security;

namespace Zamov.Controllers
{
    [Authorize(Roles="Administrators, Dealers")]
    public class DealerCabinetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Groups
        public ActionResult Groups()
        {
            using(ZamovStorage context = new ZamovStorage())
            {
                int dealerId = int.MinValue;
                if (User.IsInRole("Administrators"))
                {
                    if (SystemSettings.CurrentDealer == null)
                        return RedirectToAction("Index");
                    else
                        dealerId = SystemSettings.CurrentDealer.Value;
                }
                else
                {
                    ProfileCommon profile = ProfileCommon.Create(User.Identity.Name);
                    dealerId = profile.DealerId;
                }
                ViewData["dealerId"] = dealerId;
                List<Group> groups = (from g in context.Groups where g.Dealer.Id == dealerId select g).ToList();
                return View(groups);
            }
        }

        public ActionResult GoupList(int dealerId, int? id, int level)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<Group> groups = context.Groups.Select(g => g).Where(g => g.Dealer.Id == dealerId).ToList();
                if (id == null)
                    groups = groups.Select(g => g).Where(g => g.Parent == null).ToList();
                else
                    groups = groups.Select(g => g).Where(g => g.Parent.Id == id.Value).ToList();
                ViewData["level"] = level;
                return View(groups);
            }
        }
        #endregion
    }
}
