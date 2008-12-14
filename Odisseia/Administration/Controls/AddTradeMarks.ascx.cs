using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Controls_AddTradeMarks : System.Web.UI.UserControl
{
    protected string displayMode = "none";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void bAdd_Click(object sender, EventArgs e)
    {
        foreach (FileUpload fuTradeMark in phTradeMarks.Controls)
        {
            if (fuTradeMark.HasFile)
            {
                TradeMark tradeMark = new TradeMark();
                tradeMark.Goods = bool.Parse(rbType.SelectedValue);
                tradeMark.Save();
                string path = Server.MapPath(WebSession.ProductsImagesFolder) + "\\";
                string extPicture = fuTradeMark.FileName.Substring(fuTradeMark.FileName.LastIndexOf("."));
                fuTradeMark.SaveAs(path + tradeMark.ID + extPicture);
                tradeMark.Picture = tradeMark.ID + extPicture;
                tradeMark.Save();
            }
        }
        displayMode="none";
    }
}
