using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Trips.Web.Widgets
{
    public class WidgetBase : UserControl
    {
        List<string> LoadedWidgets
        {
            get
            {
                if (Context.Items["LoadedWidgets"] == null)
                    Context.Items["LoadedWidgets"] = new List<string>();
                return Context.Items["LoadedWidgets"] as List<string>;
            }
        }

        //protected string WidgetName { get; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //LoadedWidgets.Add(this.WidgetName);
        }
    }
}
