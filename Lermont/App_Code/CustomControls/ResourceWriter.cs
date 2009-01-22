using System;
using System.Web.UI;
using Superi.Features;

/// <summary>
/// Summary description for ResourceWriter
/// </summary>
namespace CustomControls
{
    public class ResourceWriter : Control
    {
        public int ResourceId
        {
            get
            {
                if (ViewState["resourceId"] != null)
                    return Convert.ToInt32(ViewState["resourceId"]);
                return int.MinValue;
            }
            set { ViewState["resourceId"] = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            Resource resource = new Resource(ResourceId);

            string textToWrite;// = text.Value;
            if (!string.IsNullOrEmpty(WebSession.Language))
            {
                if (resource.Items.Count > 0)
                    textToWrite = resource[WebSession.Language];
                else
                    textToWrite = "";
            }
            else textToWrite = "";
            if (textToWrite.IndexOf("<br") == -1)
                textToWrite = textToWrite.Replace(Environment.NewLine, "<br/>");
            writer.Write(textToWrite);
        }

    }
}