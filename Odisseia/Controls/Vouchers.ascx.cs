using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Controls_Vouchers : System.Web.UI.UserControl
{
    public int TradeMarkId
    {
        get
        {
            if (ViewState["tmId"] == null)
                return int.MinValue;
            return Convert.ToInt32(ViewState["tmId"]);
        }
        set { ViewState["tmId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        pOrderForm.Visible = false;
        iCloseOrder.Attributes.Add("onclick", "closeBaloon(3, '" + pOrderForm.ClientID + "')");
        iCloseOrder.Style["cursor"] = "pointer";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (TradeMarkId > 0)
        {
            TradeMark tradeMark = new TradeMark(TradeMarkId);
            rVouchers.DataSource = tradeMark.Vouchers;
            rVouchers.DataBind();
        }
    }

    protected void rVouchers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
        {
            HtmlGenericControl divVoucher = (HtmlGenericControl)e.Item.FindControl("divVoucher");
            Voucher voucher = (Voucher)e.Item.DataItem;
            ImageButton ibOrder = (ImageButton)e.Item.FindControl("ibOrder");
            ibOrder.ImageUrl = WebSession.BaseImageUrl + "orderButton.jpg";
            ibOrder.CommandArgument = voucher.ID.ToString();
            divVoucher.Style["background"] = "transparent url(" + WebSession.BaseUrl + "VoucherBackground.ashx?am=" + (int)voucher.Price + ")";
        }
        if (e.Item.ItemType == ListItemType.Separator)
        {
            if ((e.Item.ItemIndex+1) % 4 == 0)
            {
                PlaceHolder phSeparator = (PlaceHolder)e.Item.FindControl("phSeparator");
                phSeparator.Visible = false;
            }
        }
        
    }

    protected void rVouchers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        pOrderForm.Visible = true;
        hfVoucheId.Value = e.CommandArgument.ToString();
    }

    protected void ibSendOrder_Click(object sender, ImageClickEventArgs e)
    {

    }
}
