using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.UI;
using System.IO;
using Dev.Mvc.Runtime;

namespace Shop.Helpers
{
    public static class LocalizationHelpers
    {
        public static MvcHtmlString LocalizedTextBox<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>>expression)
        {
            string[] languages = Configurator.LoadSettings().Languages.Split(';');
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            foreach (string lang in languages)
            { 
                
            }
            writer.RenderEndTag();
            MvcHtmlString result = MvcHtmlString.Create(stringWriter.ToString());
            return result;
        }

        static void WriteLangLink(this HtmlTextWriter writer, string language)
        { 
            
        }
    }
}