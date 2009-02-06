using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Superi.Features;

namespace Superi.CustomControls
{
    public class ResourceWritter : WebControl
    {
        private string language = "";
        private int resourceId = int.MinValue;

        public int ResourceId
        {
            get 
            {
                if (EnableViewState && ViewState["resourceId"] != null)
                    resourceId = Convert.ToInt32(ViewState["resourceId"]);
                return resourceId; 
            }
            set 
            {
                if (EnableViewState)
                    ViewState["resourceId"] = value;
                resourceId = value; 
            }
        }

        public string Language
        {
            get 
            {
                if (EnableViewState && ViewState["language"] != null)
                    language = ViewState["language"].ToString();
                return language; 
            }
            set 
            {
                if (EnableViewState)
                    ViewState["language"] = value;
                language = value; 
            }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            Resource resource = new Resource(resourceId);
            writer.Write(resource[Language]);
        }
    }
}
