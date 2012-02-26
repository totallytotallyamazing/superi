using System.Linq;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class WorksController : Controller
    {
        private readonly ContentContainer _context = new ContentContainer();
        //
        // GET: /Works/

        [OutputCache(Duration = 1, VaryByParam = "*", NoStore = true)]
        public PartialViewResult Index()
        {
            var groups = _context.Contents.OfType<WorkGroup>();

            return PartialView(groups);
        }

        [OutputCache(Duration = 1, VaryByParam = "*", NoStore = true)]
        public JsonResult Items(string id)
        {
            var workGroup =
                _context.Contents.OfType<WorkGroup>().Include("Works").Single(w => w.Name == id);
            var result = new { workGroup.Id, works = workGroup.Works.Select(w => new { w.Name, w.Title, w.Description, w.Image }).ToArray() };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}