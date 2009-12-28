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
    public class ContentMethodAttribute : FilterAttribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
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

                    ViewDataDictionary viewData = filterContext.Controller.ViewData;
                    viewData["text"] = content.Text;
                    viewData["contentName"] = contentName;
                    viewData["text"] = content.Text;
                    viewData["title"] = content.Title;
                    viewData["keywords"] = content.Keywords;
                    viewData["description"] = content.Description;
                    viewData["contentName"] = content.Name;
                    viewData["subTitle"] = content.SubTitle;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        { 
        
        }
    }
}
