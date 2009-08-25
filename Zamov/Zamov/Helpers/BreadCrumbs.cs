using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjaxControlToolkitMvc;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;

namespace Zamov.Helpers
{
    public class BreadCrumbsTracker : BaseTracker<KeyValuePair<string, string>>
    {
        public BreadCrumbsTracker(HttpContextBase context) : base(context) { }

        protected override void Initialize(HttpContextBase context)
        {
            resourceKey = "__breadCrumbs";
            base.Initialize(context);
        }

        public List<KeyValuePair<string, string>> Items
        {
            get { return _resources; }
        }
    }

    public static class BreadCrumbsExtensions
    {
        public static string BreadCrumbs(this AjaxHelper helper, string controlId)
        {
            string scriptTemplate = "<script type=\"text/javascript\">$(function(){$('#" + controlId + "').load('/PageParts/BreadCrumbs')})</script>";
            return scriptTemplate;
        }

        public static void AddBreadCrumb(this HtmlHelper helper, string text, string url)
        {
            BreadCrumbsTracker tracker = new BreadCrumbsTracker(helper.ViewContext.HttpContext);
            tracker.Add(new KeyValuePair<string, string>(text, url));
        }

        public static string RenderItem(KeyValuePair<string, string> item)
        {
            string template = "<span class=\"breadCrumb\"><a href=\"{0}\">{1}</a></span>";
            return String.Format(template, item.Value, item.Key);
        }

        public static string RenderSeparator()
        {
            return "<span>/</span>";
        }
    }
}
