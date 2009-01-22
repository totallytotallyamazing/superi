using System.Web.UI;
using Superi.Features;

/// <summary>
/// Summary description for TextWriter
/// </summary>
namespace CustomControls
{
	public class TextWriter : Control
	{
		private const string BASE_DIR = "%BASE_DIR%";
		private const string BASE_IMAGE_DIR = "%BASE_IMAGE_DIR%";

		private int _TextID = int.MinValue;
		private string _TextName="";

		public int TextID
		{
			get { return _TextID; }
			set { _TextID = value; }
		}

		public string TextName
		{
			get { return _TextName; }
			set { _TextName = value; }
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			Text text;
			if(TextID>0)
				text = new Text(TextID);
			else 
				text = new Text(TextName);
            string textToWrite;// = text.Value;
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
