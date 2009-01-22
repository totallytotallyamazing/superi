using System;
using System.Web.UI.WebControls;
using Superi.Features;

/// <summary>
/// Summary description for ResourceButton
/// </summary>
namespace CustomControls
{
    public class ResourceButton : Button
    {
        public int ResourceId
        {
            get
            {
                if (ViewState[ID + "resourceId"] != null)
                    return Convert.ToInt32(ViewState[ID + "resourceId"]);
                return int.MinValue;
            }
            set { ViewState[ID + "resourceId"] = value; }
        }

        public int TextId
        {
            get
            {
                if (ViewState[ID + "textId"] != null)
                    return Convert.ToInt32(ViewState[ID + "textId"]);
                return int.MinValue;
            }
            set { ViewState[ID + "textId"] = value; }
        }

        public string TextName
        {
            get
            {
                if (ViewState[ID + "textName"] != null)
                    return ViewState[ID + "textName"].ToString();
                return null;
            }
            set { ViewState[ID + "textName"] = value; }

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (ResourceId > 0)
            {
                Resource resource = new Resource(ResourceId);
                Text = resource[WebSession.Language];
            }
            else if (TextId > 0)
            {
                Text text = new Text(TextId);
                Text = text.TextResource[WebSession.Language];
            }
            else if (!string.IsNullOrEmpty(TextName))
            {
                Text text = new Text(TextName);
                Text = text.TextResource[WebSession.Language];
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
       }
    }
}