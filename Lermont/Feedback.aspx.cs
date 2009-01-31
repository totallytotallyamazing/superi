using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.CustomControls;

public partial class Feedback : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        rlComment.Language = WebSession.Language;
        rlName.Language = WebSession.Language;
        rbPostComment.Language = WebSession.Language;
    }

    protected void rbPostComment_Click(object sender, EventArgs e)
    {
        FAQ comment = new FAQ();
        comment.Question = tbComment.Text;
        comment.Email = tbEmail.Text;
        comment.Name = tbName.Text;
        comment.Display = false;
        comment.Save();
    }

    protected void Page_PreRender()
    {
        PublishComments();
    }

    private void PublishComments()
    {
        FAQList list = new FAQList(true);
        rComments.DataSource = list;
        rComments.DataBind();
    }
    protected void rComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            (e.Item.FindControl("rlName") as ResourceLabel).Language = WebSession.Language;
            (e.Item.FindControl("rlComment") as ResourceLabel).Language = WebSession.Language;
            FAQ faq = (FAQ)e.Item.DataItem;
            if (faq.Display)
            {
                Label lName = (Label)e.Item.FindControl("lName");
                Label lEmail = (Label)e.Item.FindControl("lEmail");
                HyperLink hlEmail = (HyperLink)e.Item.FindControl("hlEmail");
                Literal lComment = (Literal)e.Item.FindControl("lComment");

                lName.Text = faq.Name;
                if (string.IsNullOrEmpty(faq.Email))
                    hlEmail.Visible = lEmail.Visible = false;
                else
                {
                    hlEmail.NavigateUrl = "mailto:" + faq.Email;
                    hlEmail.Text = faq.Email;
                }
                lComment.Text = faq.Question;
            }
       }
    }
}
