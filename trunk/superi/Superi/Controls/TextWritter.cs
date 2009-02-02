using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;
using System.Web.UI;

namespace Superi.CustomControls
{
    public class TextWriter : WebControl
    {
        private const string BASE_DIR = "%BASE_DIR%";
        private const string BASE_IMAGE_DIR = "%BASE_IMAGE_DIR%";

        public int TextID
        {
            get
            {
                if (ViewState["textId"] != null)
                    return Convert.ToInt32(ViewState["textId"]);
                return int.MinValue;
            }
            set { ViewState["textId"] = value; }
        }

        public string TextName
        {
            get
            {
                if (ViewState["textName"] != null)
                    return ViewState["textName"].ToString();
                return null;
            }
            set { ViewState["textName"] = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            Text text;
            if (TextID > 0)
                text = new Text(TextID);
            else
                text = new Text(TextName);
            string textToWrite;
            if (!string.IsNullOrEmpty(WebSession.Language))
            {
                if (text.TextResource != null && text.TextResource.Items.Count > 0)
                    textToWrite = text.TextResource[WebSession.Language];
                else
                    textToWrite = text.Value;
            }
            else textToWrite = text.Value;
            textToWrite = textToWrite.Replace(BASE_DIR, WebSession.BaseUrl);
            textToWrite = textToWrite.Replace(BASE_IMAGE_DIR, WebSession.BaseImageUrl);
            writer.Write(textToWrite);
        }
    }

}
