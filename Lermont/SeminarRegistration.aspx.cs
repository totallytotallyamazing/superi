using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SeminarRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkCss();
        bSend.TextName = "bSend";
    }

    private void LinkCss()
    {
        HtmlLink link = new HtmlLink();
        link.Attributes.Add("rel", "Stylesheet");
        link.Href = "css/SeminarRegistration.css";
        Page.Controls.Add(link);
    }

    protected void bSend_Click(object sender, EventArgs e)
    {
        SmtpClient client = new SmtpClient();
    }
}
