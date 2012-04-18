using System.Linq;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/
        readonly ContentContainer _context = new ContentContainer();

        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Get(string id)
        {
            var content = _context.Contents.OfType<TextContent>().FirstOrDefault(c => c.Name == id);
            string contentText = string.Empty;
            if (content != null)
            {
                contentText = content.Text;
                if(Request.IsAuthenticated)
                {
                    contentText+="<div><a class=\"adminLink\" href=\"javascript:location.href='/Admin/Content/Edit/" + id + "?redirectTo='+escape(location.href);\">Править</a></div>";
                }
            }
            return Content(contentText);
        }

        public ActionResult GetChild(string id)
        {
            return Get(id);
        }
    }
}
