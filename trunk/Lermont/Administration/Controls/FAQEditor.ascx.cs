using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Administration_Controls_FAQEditor : System.Web.UI.UserControl
{
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UpdateComment")
        {
            int faqId = Convert.ToInt32(e.CommandArgument);
            FAQ faq = new FAQ(faqId);
            if (faq.Id > 0)
            {
                faq.Question = ((TextBox)(e.CommandSource as Button).NamingContainer.FindControl("tbComment")).Text;
                faq.Save();
            }

        }
    }
}