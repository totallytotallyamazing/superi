using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Controls_AddVouchers : System.Web.UI.UserControl
{
    protected string displayMode = "none";

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
        bAdd.Attributes.Add("onclick", "return verifyVoucherValues()");
    }
    protected void bAdd_Click(object sender, EventArgs e)
    {
        if(TradeMarkId>0)
            foreach (TextBox tbVoucherValue in phNominals.Controls)
            {
                if (!string.IsNullOrEmpty(tbVoucherValue.Text))
                {
                    Voucher voucher = new Voucher();
                    voucher.ProductId = TradeMarkId;
                    voucher.Price = int.Parse(tbVoucherValue.Text);
                    voucher.Save();
                }
            }
        displayMode = "none";
    }
}
