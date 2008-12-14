using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

public partial class Administration_Controls_TradeMarksFrame : System.Web.UI.UserControl
{
    public bool Goods
    {
        get 
        {
            if (ViewState["goods"] != null)
                return Convert.ToBoolean(ViewState["goods"]);
            return true;
        }
        set { ViewState["goods"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        TradeMarkList list = TradeMarks.Get(Goods);
        dlTradeMark.DataSource = list;
        dlTradeMark.DataBind();
        dlTradeMark.DataBind();
    }

    protected void dlTradeMark_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int tmId = int.Parse(e.CommandArgument.ToString());
        TradeMark tradeMark = new TradeMark(tmId);
        if (e.CommandName == "Delete")
        {
            RemovePicture(tradeMark.Picture);
            tradeMark.Remove();
        }
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath(WebSession.ProductsImagesFolder) + PicturePath;
            File.Delete(path);
        }
    }

    protected void dlTradeMark_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        TradeMark tradeMark = (TradeMark)e.Item.DataItem;
        HyperLink hlTradeMark = (HyperLink)e.Item.FindControl("hlTradeMark");
        LinkButton lbDelete = (LinkButton)e.Item.FindControl("lbDelete");

       // ibTradeMark.CommandArgument = tradeMark.ID.ToString();
        lbDelete.CommandArgument = tradeMark.ID.ToString();
        hlTradeMark.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?loc=products&dim=60&file=" + tradeMark.Picture;
        hlTradeMark.NavigateUrl = "javascript:openPopupWindow('PopUps/EditTradeMark.aspx?id="+tradeMark.ID+"', 900, 800)";
    }
}
