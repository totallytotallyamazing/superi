using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Superi.Features;

public partial class Administration_PopUps_EditTradeMark : System.Web.UI.Page
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

    private void LoadValues()
    {
        TradeMark tradeMark = new TradeMark(TradeMarkId);
        VoucherList voucherList = new VoucherList(TradeMarkId);

        rVouchers.DataSource = voucherList;
        rVouchers.DataBind();

        fcDescription.Value = tradeMark.Description;
        fcSummary.Value = tradeMark.ShortDescription;
        tbEventSuggestion.Text = tradeMark.EventSuggestion;
        tbName.Text = tradeMark.Name;
        tbOcassion.Text = tradeMark.Ocasions;
        tbRecipient.Text = tradeMark.Recipients;
        iLogo.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?loc=products&dim=150&file=" + tradeMark.Picture;
        cbMan.Checked = tradeMark.ForMan;
        cbWoman.Checked = tradeMark.ForWoman;
        PublishEvents(tradeMark);
    }

    private void SaveValues()
    {
        if (TradeMarkId > 0)
        {
            TradeMark tradeMark = new TradeMark(TradeMarkId);
            tradeMark.Name = tbName.Text;
            tradeMark.Description = fcDescription.Value;
            tradeMark.ShortDescription = fcSummary.Value;
            tradeMark.EventSuggestion = tbEventSuggestion.Text;
            tradeMark.Ocasions = tbOcassion.Text;
            tradeMark.Recipients = tbRecipient.Text;
            tradeMark.ForMan = cbMan.Checked;
            tradeMark.ForWoman = cbWoman.Checked;
            SaveEvents(tradeMark);
            tradeMark.Save();
        }
    }

    private void PublishEvents(TradeMark Mark)
    {
        EventList eventList = new EventList(true);
        foreach (Event ev in eventList)
        {
            ListItem listItem = new ListItem(ev.Name, ev.Id.ToString());
            listItem.Selected = Mark.AssociatedEventIds.Contains(ev.Id);
            cblHolidays.Items.Add(listItem);
        }
    }

    private void SaveEvents(TradeMark Mark)
    {
        Mark.AssociatedEventIds.Clear();
        foreach(ListItem item in cblHolidays.Items)
        {
            if (item.Selected)
            {
                int eventId = int.Parse(item.Value);
                Mark.AssociatedEventIds.Add(eventId);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        LoadValues();
    }

    protected void rVouchers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int voucherId = int.Parse(e.CommandArgument.ToString());
            Voucher voucher = new Voucher(voucherId);
            voucher.Remove();
        }
    }

    protected void rVouchers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lNominal = (Label)e.Item.FindControl("lNominal");
            LinkButton lbDelete = (LinkButton)e.Item.FindControl("lbDelete");
            Voucher voucher = (Voucher)e.Item.DataItem;

            lNominal.Text = voucher.Price.ToString("0");
            lbDelete.CommandArgument = voucher.ID.ToString();
        }
    }
    protected void bSave_Click(object sender, EventArgs e)
    {
        SaveValues();
        Response.Write("<script type=\"text/javascript\">window.close();</script>");
    }

    protected void bChangeLogo_Click(object sender, EventArgs e)
    {
        TradeMark tradeMark = new TradeMark(TradeMarkId);
        if (fuPicture.HasFile)
        {
            RemovePicture(tradeMark.Picture);
            string path = Server.MapPath(WebSession.ProductsImagesFolder) + "\\";
            string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
            fuPicture.SaveAs(path + tradeMark.ID + extPicture);
            tradeMark.Picture = tradeMark.ID + extPicture;
            tradeMark.Save();
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

}