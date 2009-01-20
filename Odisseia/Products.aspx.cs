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

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TradeMarkList tlGoods = TradeMarks.Get(true);
        TradeMarkList tlServices = TradeMarks.Get(false);
        dlGoods.DataSource = tlGoods;
        dlServices.DataSource = tlServices;
        dlGoods.DataBind();
        dlServices.DataBind();
    }

    protected void dlGoods_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hlTradeMark = (HyperLink)e.Item.FindControl("hlTradeMark");
            TradeMark tradeMark = (TradeMark)e.Item.DataItem;
            hlTradeMark.Text = tradeMark.Name;
            hlTradeMark.ToolTip = tradeMark.Name;
            hlTradeMark.ImageUrl = "MakeThumbnail.aspx?loc=products&dim=65&file=" + tradeMark.Picture;
            hlTradeMark.NavigateUrl = "ProductDetails.aspx?id=" + tradeMark.ID;
        }
    }
}
