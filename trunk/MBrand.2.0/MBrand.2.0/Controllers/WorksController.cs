using System.Linq;
using System.Web.Mvc;
using MBrand.Models;
using System.Dynamic;

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
            var result = new { workGroup.Id, works = workGroup.Works
                .OrderByDescending(w=>w.SortOrder)
                .Select(w => new { w.Name, w.Title, w.Description, w.Image })
                .ToArray() };
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 1, VaryByParam = "*", NoStore = true)]
        public PartialViewResult Show(string id)
        {
            var result = _context.Contents.OfType<Work>().Include("WorkGroup")
                .Select(w => new 
                             {
                                 w.Id,
                                 w.Name,
                                 w.Text,
                                 w.Description,
                                 w.Title,
                                 w.BottomImage,
                                 w.SideBarText,
                                 WorkGroupId = w.WorkGroup.Id,
                                 WorkGroupName = w.WorkGroup.Name,
                                 WorkGroupTitle = w.WorkGroup.Title
                             }).Single(w => w.Name == id);
            dynamic res = new ExpandoObject();

            res.Id = result.Id;
            res.Name = result.Name;
            res.Text = result.Text;
            res.Description = result.Description;
            res.Title = result.Title;
            res.BottomImage = result.BottomImage;
            res.SideBarText = result.SideBarText;
            res.WorkGroupId = result.WorkGroupId;
            res.WorkGroupName = result.WorkGroupName;
            res.WorkGroupTitle = result.WorkGroupTitle;

            return PartialView(res);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}