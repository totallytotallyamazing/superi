using System;
using System.Web.UI;
using Superi.Features;

public partial class Administration_TextsPopUp : Page
{
    protected string Mode
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]))
                return Request.QueryString["mode"];
            return "";
        }
    }

	protected void Page_Load(object sender, EventArgs e)
	{
		rTexts.DataSource = new TextList(true);
		rTexts.DataBind();
	}
}
