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

    public static class BreadCrumbs
    {
        public static string BreadCrumbs(this AjaxHelper helper, string controlId)
        {
            string scriptTemplate = "<script type=\"text/javascript\">$(function(){$('{0}').html('{1}')})</script>";
            BreadCrumbsTracker tracker = new BreadCrumbsTracker(helper.ViewContext.HttpContext);
            StringBuilder layout = new StringBuilder();
            int itemsCount = tracker.Items.Count;
            for (int i = 0; i < itemsCount; i++)
            {
                layout.Append(RenderItem(tracker.Items[i]));
                if (i < itemsCount - 1)
                    layout.Append(RenderSeparator());
            }
            return String.Format(scriptTemplate, controlId, layout.ToString());
        }

        private static string RenderItem(KeyValuePair<string, string> item)
        {
            string template = "<span class=\"breadCrumb\"><a href=\"{0}\">{1}</a></span>";
            return String.Format(template, item.Value, item.Key);
        }

        private static string RenderSeparator()
        {
            return "<span>/</span>";
        }
    }
}
