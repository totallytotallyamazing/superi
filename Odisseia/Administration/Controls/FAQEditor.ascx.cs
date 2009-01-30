using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Features;

public partial class Administration_Controls_FAQEditor : System.Web.UI.UserControl
{
    private int TradeMarkID
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.Form[ddlTradeMark.UniqueID]))
                return int.Parse(Request.Form[ddlTradeMark.UniqueID]);
            if (!string.IsNullOrEmpty(ddlTradeMark.SelectedValue))
                return int.Parse(ddlTradeMark.SelectedValue);
            return int.MinValue;
        }
    }

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
        FAQ item = (FAQ) e.Item.DataItem;
        Literal lComment = (Literal)e.Item.FindControl("lComment");
        LinkButton lbDelete = (LinkButton) e.Item.FindControl("lbDelete");

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
        if(e.CommandName=="Delete")
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
        ddlTradeMark.DataValueField = "ID";
        ddlTradeMark.DataTextField = "Name";
        ddlTradeMark.DataSource = new TradeMarkList(true);
        ddlTradeMark.DataBind();
        FAQList list = new FAQList(TradeMarkID);
        rItems.DataSource = list;
        rItems.DataBind();
    }
}
