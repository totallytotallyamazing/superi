using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Dev.Helpers
{
    public static class GetOutputExtensions
    {
        public static string GetPartialOutput(this HtmlHelper htmlHelper, string partialViewName)
        {
            return htmlHelper.GetPartialOutput(partialViewName, htmlHelper.ViewData, null, ViewEngines.Engines);
        }

        public static string GetPartialOutput(this HtmlHelper htmlHelper, string partialViewName, object model)
        {
            return htmlHelper.GetPartialOutput(partialViewName, htmlHelper.ViewData, model, ViewEngines.Engines);
        }

        private static string GetPartialOutput(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, object model, ViewEngineCollection viewEngineCollection)
        {
            if (string.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException("The following parameter should not be empty: {0}", "partialViewName");
            }
            ViewDataDictionary dictionary = null;
            if (model == null)
            {
                if (viewData == null)
                {
                    dictionary = new ViewDataDictionary(htmlHelper.ViewData);
                }
                else
                {
                    dictionary = new ViewDataDictionary(viewData);
                }
            }
            else if (viewData == null)
            {
                dictionary = new ViewDataDictionary(model);
            }
            else
            {
                ViewDataDictionary dictionary2 = new ViewDataDictionary(viewData);
                dictionary2.Model = model;
                dictionary = dictionary2;
            }
            
            ViewContext viewContext = new ViewContext(htmlHelper.ViewContext, htmlHelper.ViewContext.View, dictionary, htmlHelper.ViewContext.TempData);
            ViewEngineResult result = ViewEngines.Engines.FindPartialView(viewContext, partialViewName);

            var response = HttpContext.Current.Response;
            //Flushing
            response.Flush();


            var oldFilter = response.Filter;
            Stream filter = new MemoryStream(); ;
            try
            {
                response.Filter = filter;
                result.View.Render(viewContext, null);
                response.Flush();
                filter.Position = 0;
                var reader = new StreamReader(filter, response.ContentEncoding);
                return reader.ReadToEnd();
            }
            finally
            {
                filter.Dispose();
                response.Filter = oldFilter;
            } 
        }
    }
}
