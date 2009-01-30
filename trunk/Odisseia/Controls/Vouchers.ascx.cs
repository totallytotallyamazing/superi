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
using System.Net.Mail;
using System.Net;
using System.Text;

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
        pThankYou.Visible = false;
        iCloseOrder.Attributes.Add("onclick", "closeBaloon(3, '" + pOrderForm.ClientID + "')");
        iCloseOrder.Style["cursor"] = "pointer";
        
        iCloseTanks.Attributes.Add("onclick", "closeBaloon(3, '" + pThankYou.ClientID + "')");
        iCloseTanks.Style["cursor"] = "pointer";
        iCloseThanksButton.Attributes.Add("onclick", "closeBaloon(3, '" + pThankYou.ClientID + "')");
        iCloseThanksButton.Style["cursor"] = "pointer";
        CustomValidator val = new CustomValidator();
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
            ibOrder.CommandArgument = voucher.ID.ToString();
            divVoucher.Style["background"] = "transparent url(VoucherBackground.ashx?am=" + (int)voucher.Price + ")";
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
        int voucherId = Convert.ToInt32(e.CommandArgument);
        pOrderForm.Visible = true;
        hfVoucheId.Value = voucherId.ToString();
        Voucher voucher = new Voucher(voucherId);
        lTradeMark.Text = new TradeMark(voucher.ProductId).Name;
        lPrice.Text = voucher.Price.ToString("0");
    }

    protected void ibSendOrder_Click(object sender, ImageClickEventArgs e)
    {
        pThankYou.Visible = true;
        SendOrder();
        pOrderForm.Visible = false;
    }

    private bool SendOrder()
    {
        SmtpClient client = new SmtpClient("mail.odisseia.com.ua");
        client.Credentials = new NetworkCredential("sales", "9589373");

        MailMessage message = new MailMessage("sales@odisseia.com.ua", "sales@odisseia.com.ua");
        message.IsBodyHtml = false;
        message.Subject = "Заказ с сайта";
        message.SubjectEncoding = Encoding.GetEncoding("koi8-r");
        StringBuilder sbBody = new StringBuilder();
        sbBody.Append("Имя: ");
        sbBody.Append(tbName.Text);
        sbBody.Append(Environment.NewLine);
        sbBody.Append("Email: ");
        sbBody.Append(tbEmail.Text);
        sbBody.Append(Environment.NewLine);
        sbBody.Append("Телефон: ");
        sbBody.Append(tbPhone.Text);
        message.Body = sbBody.ToString();
        message.BodyEncoding = Encoding.GetEncoding("koi8-r");
        try
        {
            client.Send(message);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
