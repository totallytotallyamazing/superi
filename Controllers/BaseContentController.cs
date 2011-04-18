using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Oksi.Models;
using Oksi.Helpers;
using System.Globalization;

namespace Oksi.Controllers
{
    public class BaseContentController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string contentName = filterContext.RouteData.Values["contentName"].ToString();

            if (contentName != null)
            {

                using (DataStorage context = new DataStorage())
                {
                    SiteContent content = context.GetContent(contentName);

                    if (content == null)
                        throw new HttpException(404, "NotFound");

                    ViewData["text"] = content.Text;
                    ViewData["contentName"] = contentName;
                    ViewData["text"] = content.Text;
                    ViewData["title"] = content.Title;
                    ViewData["keywords"] = content.Keywords;
                    ViewData["description"] = content.Description;
                    ViewData["contentName"] = content.Name;
                }
            }
        }

        public virtual ActionResult Index(string contentUrl)
        {
            return View();
        }
    }
}
