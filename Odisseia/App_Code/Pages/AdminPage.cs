using System;
using System.Web.UI;

/// <summary>
/// Summary description for AdminPage
/// </summary>
public class AdminPage:Page
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (Session["LoggedIn"] == null)
			Response.Redirect("Login.aspx");
	}
}
