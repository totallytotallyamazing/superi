using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Web.Security;

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
                    ViewDataDictionary viewData = filterContext.Controller.ViewData;

                    Content content = context.GetContent(contentName);

                    if (content == null)
                        throw new HttpException(404, "NotFound");

                    viewData["text"] = content.Text;
                    viewData["contentName"] = contentName;
                    viewData["text"] = content.Text;
                    
                    if (string.IsNullOrEmpty((string)viewData["title"]) && !string.IsNullOrEmpty(content.Title))
                        viewData["title"] = content.Title;
                    if (string.IsNullOrEmpty((string)viewData["keywords"]) && !string.IsNullOrEmpty(content.Keywords))
                        viewData["keywords"] = content.Keywords;
                    if (string.IsNullOrEmpty((string)viewData["description"]) && !string.IsNullOrEmpty(content.Description))
                        viewData["description"] = content.Description;

                    viewData["contentName"] = content.Name;
                }
            }
        }

    }
}
