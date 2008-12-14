using System;
using System.Web.UI;

/// <summary>
/// Summary description for AdminMaster
/// </summary>
public class AdminMaster: MasterPage
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (Session["LoggedIn"] == null)
			Response.Redirect("Login.aspx");
	}
}
