using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Security;
using System.IO;

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

        #region Dealer
        public ActionResult AddUpdateDealer()
        {

            int id = Security.GetCurentDealerId(User.Identity.Name);
            if (id > 0)
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    Dealer dealer = context.Dealers.Select(d => d).Where(d => d.Id == id).First();
                    ViewData["dealer"] = dealer;
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddUpdateDealer(FormCollection form)
        {
            int dealerId = Security.GetCurentDealerId(User.Identity.Name);
            Dealer dealer = null;
            using (ZamovStorage context = new ZamovStorage())
            {
                if (dealerId >= 0)
                    dealer = context.Dealers.Select(d => d).Where(d => d.Id == dealerId).First();
                else
                    dealer = new Dealer();
                dealer.Name = form["name"];
                dealer.Names["ru-RU"] = form["rName"];
                dealer.Names["uk-UA"] = form["uName"];
                dealer.Descriptions["ru-RU"] = Server.HtmlDecode(form["rDescription"]);
                dealer.Descriptions["uk-UA"] = Server.HtmlDecode(form["uDescription"]);
                dealer.Enabled = form["enabled"].Contains("true");
                if (!string.IsNullOrEmpty(Request.Files["logoImage"].FileName))
                {
                    HttpPostedFileBase file = Request.Files["logoImage"];
                    dealer.LogoType = file.ContentType;
                    BinaryReader reader = new BinaryReader(file.InputStream);
                    dealer.LogoImage = reader.ReadBytes((int)file.InputStream.Length);
                }
                if (dealerId < 0)
                    context.AddToDealers(dealer);
                context.SaveChanges();
                context.UpdateTranslations(dealer.NamesXml);
                context.UpdateTranslations(dealer.DescriptionsXml);
            }
            return RedirectToAction("Dealers");
        }
        #endregion
    }
}
