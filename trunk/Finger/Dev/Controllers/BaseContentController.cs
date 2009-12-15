using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;
using Dev.Helpers;

namespace Dev.Controllers
{
    public class BaseContentController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string contentUrl = filterContext.RouteData.Values["contentUrl"].ToString();

            if (contentUrl != null)
            {

                using (DataStorage context = new DataStorage())
                {
                    SiteContent content = context.GetContent(contentUrl);

                    if (content == null)
                        throw new HttpException(404, "NotFound");

                    if (content.Language != DevSession.Language)
                    {
                        DevSession.Language = content.Language;
                    }
                    ViewData["text"] = content.Text;
                    ViewData["contentUrl"] = contentUrl;
                    ViewData["text"] = content.Text;
                    ViewData["title"] = content.Title;
                    ViewData["keywords"] = content.Keywords;
                    ViewData["description"] = content.Description;
                    ViewData["contentName"] = content.Name;
                }
            }
            base.OnActionExecuting(filterContext);
        }

        public ActionResult Index(string contentUrl)
        {
            return View();
        }
    }
}
