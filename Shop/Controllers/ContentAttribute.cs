using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ContentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string contentName = filterContext.RouteData.Values["id"].ToString();

            if (contentName != null)
            {

                using (ContentStorage context = new ContentStorage())
                {
                    Content content = context.GetContent(contentName);

                    if (content == null)
                        throw new HttpException(404, "NotFound");

                    filterContext.Controller.ViewData["text"] = content.Text;
                    filterContext.Controller.ViewData["contentName"] = contentName;
                    filterContext.Controller.ViewData["text"] = content.Text;
                    filterContext.Controller.ViewData["title"] = content.Title;
                    filterContext.Controller.ViewData["keywords"] = content.Keywords;
                    filterContext.Controller.ViewData["description"] = content.Description;
                    filterContext.Controller.ViewData["contentName"] = content.Name;
                }
            }
        }

    }
}
