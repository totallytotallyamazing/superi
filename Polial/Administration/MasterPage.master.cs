using System;
using System.Web.Security;
using System.Web.UI;

//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;

public partial class Administration_MasterPage : MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		
	}
	protected void lbSognOut_Click(object sender, EventArgs e)
	{
        FormsAuthentication.SignOut();
        Response.Redirect("~/administration/Login.aspx");
        //Session["LoggedIn"] = null;
        //Response.Redirect("Login.aspx");
	}
}
