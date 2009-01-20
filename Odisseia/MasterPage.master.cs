using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using Superi.Features;
using Superi.Common;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pPrices.Visible = false;
        pHolidays.Visible = false;
        InitPrices();
    }

    protected void ibHoliday_Click(object sender, EventArgs e)
    {
        pHolidays.Visible = true;
    }

    protected void ibPrices_Click(object sender, EventArgs e)
    {
        pPrices.Visible = true;
    }

    private void InitPrices()
    {
        ArrayList scopes = ApplicationSettings.Get("PriceScope");
        rPrices.DataSource = scopes;
        rPrices.DataBind();
    }


    protected void rPrices_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string scope = e.Item.DataItem.ToString();
            HyperLink hlPriceScope = (HyperLink)e.Item.FindControl("hlPriceScope");
            hlPriceScope.NavigateUrl = "products.aspx?price=" + e.Item.ItemIndex;
            if (scope[0] == '-')
            {
                hlPriceScope.Text = "от <strong>" + scope.Substring(1) + "</strong> грн.";
            }
            else if (scope[scope.Length - 1] == '-')
            {
                hlPriceScope.Text = "<strong>" + scope.Replace("-", "") + "</strong> грн. и выше";
            }
            else
            {
                hlPriceScope.Text = "от <strong>" + scope.Substring(0, scope.IndexOf("-")) + "</strong> грн. до <strong>" + scope.Substring(scope.IndexOf("-") + 1) + "</strong> грн.";
            }
        }
    }
}
