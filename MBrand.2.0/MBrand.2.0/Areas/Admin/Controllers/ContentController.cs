using System.Data;
using System.Linq;
using System.Web.Mvc;
using MBrand.Models;
using System.Web;

namespace MBrand.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        readonly ContentContainer _db = new ContentContainer();
        //
        // GET: /Admin/Content/

        public ActionResult Edit(string id, string redirectTo)
        {
            ViewBag.RedirectTo = redirectTo;
            TextContent content = _db.Contents.OfType<TextContent>().Single(c => c.Name == id);
            return View(content);
        }

        [HttpPost]
        public ActionResult Edit(string name, string text, string redirectTo)
        {
            TextContent content = _db.Contents.OfType<TextContent>().Single(c=>c.Name == name);
            content.Text = HttpUtility.HtmlDecode(text);
            _db.SaveChanges();
            return Redirect(string.IsNullOrEmpty(redirectTo) ? "~/" : redirectTo);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
