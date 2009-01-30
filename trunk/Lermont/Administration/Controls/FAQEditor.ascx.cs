using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Administration_Controls_FAQEditor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        phAnswer.Visible = false;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        PublishList();
    }

    protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        FAQ item = (FAQ)e.Item.DataItem;
        Literal lComment = (Literal)e.Item.FindControl("lComment");
        LinkButton lbDelete = (LinkButton)e.Item.FindControl("lbDelete");

        lComment.Text = item.Question;
        lbDelete.CommandArgument = item.Id.ToString();
    }
    protected void rItems_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int itemId = int.Parse(e.CommandArgument.ToString());
        FAQ item = new FAQ(itemId);
        if (e.CommandName == "Answer")
        {
            phAnswer.Visible = true;
            lQuestion.Text = item.Question;
            hfItemId.Value = item.Id.ToString();
        }
        if (e.CommandName == "Delete")
        {
            item.Remove();
        }
    }
    protected void ddlExpret_SelectedIndexChanged(object sender, EventArgs e)
    {
        PublishList();
    }

    protected void cbNoAnswers_CheckedChanged(object sender, EventArgs e)
    {
        PublishList();
    }

    private void PublishList()
    {
        FAQList list = new FAQList(true);
        rItems.DataSource = list;
        rItems.DataBind();
    }
}
