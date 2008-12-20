using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        FillProperties();
    }

    private void FillProperties()
    {
        TradeMark tradeMark = new TradeMark(TradeMarkId);
        iLogo.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?loc=products&w=120&h=95&ha=c&va=m&bg=White&kp=1&file=" + tradeMark.Picture;
        lDescription.Text = tradeMark.Description;
        lShortDescription.Text = tradeMark.ShortDescription;
        lRecipient.Text = tradeMark.Recipients;
        lOccasion.Text = tradeMark.Ocasions;
        lEventSuggestion.Text = tradeMark.EventSuggestion;
    }
}
