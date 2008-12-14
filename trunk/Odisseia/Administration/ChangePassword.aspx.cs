using System;

public partial class Administration_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Write("<script type=\"text/javascript\">close();</script>");
    }
    protected void ChangePassword1_CancelButtonClick(object sender, EventArgs e)
    {
        Response.Write("<script type=\"text/javascript\">close();</script>");
    }
}
