using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;
using Dev.Helpers;
using System.Globalization;

namespace Dev.Controllers
{
    public class BaseContentController : LocalizedController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string contentName = filterContext.RouteData.Values["contentName"].ToString();

            if (contentName != null)
            {

                using (DataStorage context = new DataStorage())
                {
                    SiteContent content = context.GetContent(contentName, LocaleHelper.GetCultureName());

                    if (content == null)
                        throw new HttpException(404, "NotFound");

                    if (content.Language != LocaleHelper.GetCultureName())
                    {
                        LocaleHelper.SetCulture(content.Language);
                    }
                    ViewData["text"] = content.Text;
                    ViewData["contentName"] = contentName;
                    ViewData["text"] = content.Text;
                    ViewData["title"] = content.Title;
                    ViewData["keywords"] = content.Keywords;
                    ViewData["description"] = content.Description;
                    ViewData["contentName"] = content.Name;
                    ViewData["subTitle"] = content.SubTitle;
                }
            }
        }

        public ActionResult Index(string contentUrl)
        {
            return View();
        }
    }
}
