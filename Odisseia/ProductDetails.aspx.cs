using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class ProductDetails : System.Web.UI.Page
{
    private int TradeMarkId
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                return int.Parse(Request.QueryString["id"]);
            return int.MinValue;
        }
    }

    private TradeMark tradeMark = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        pComments.Visible = false;
        int commentsCount = new FAQList(TradeMarkId).Count;
        lbComments.Text = "КОММЕНТАРИИ";
        if (commentsCount > 0)
        {
            lbComments.Text += " <span style=\"color:black;\">(</span>" + commentsCount + "<span style=\"color:black;\">)</span>";
        }

        iCloseComments.Attributes.Add("onclick", "closeBaloon(3, '" + pComments.ClientID + "')");
        iCloseComments.Style["cursor"] = "pointer";

        FillProperties();
    }

    private void FillProperties()
    {
        tradeMark = new TradeMark(TradeMarkId);
        iLogo.ImageUrl = "MakeThumbnail.aspx?loc=products&w=120&h=95&ha=c&va=m&bg=White&kp=1&file=" + tradeMark.Picture;
        lDescription.Text = tradeMark.Description;
        lShortDescription.Text = tradeMark.ShortDescription;
        lRecipient.Text = tradeMark.Recipients;
        lOccasion.Text = tradeMark.Ocasions;
        lEventSuggestion.Text = tradeMark.EventSuggestion;
        vVouchers.TradeMarkId = TradeMarkId;
    }
    protected void lbComments_Click(object sender, EventArgs e)
    {
        pComments.Visible = true;
        lCommentsTitle.Text = "Комментарии к " + tradeMark.Name;
    }
}
