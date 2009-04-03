﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Features;
using Superi.Common;

public partial class ProductsDisk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkCss();
        DiskList diskList = new DiskList(true);
        rDisks.DataSource = diskList;
        rDisks.DataBind();
    }

    private void LinkCss()
    {
        HtmlLink link = new HtmlLink();
        link.Attributes.Add("rel", "Stylesheet");
        link.Href = "css/disks.css";
        Page.Controls.Add(link);
    }

    protected void rDisks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Disk disk = (Disk)e.Item.DataItem;
            Image hlCover = (Image)e.Item.FindControl("hlCover");
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
            HyperLink hlNewBook = (HyperLink)e.Item.FindControl("hlNewBook");
            Literal lSubTitle = (Literal)e.Item.FindControl("lSubTitle");
            HyperLink hlPublisher = (HyperLink)e.Item.FindControl("hlPublisher");
            Literal lDescription = (Literal)e.Item.FindControl("lDescription");
            Label tbPrice = (Label)e.Item.FindControl("tbPrice");


            string navigateUrl = WebSession.BaseUrl + "workshop/product_details/" + disk.ID;

            hlCover.ToolTip = disk.Names[WebSession.Language];
            hlCover.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?loc=products&h=100&w=100&kp=0&file=" + disk.Picture;
           

            hlTitle.Text = disk.Names[WebSession.Language];
            hlTitle.NavigateUrl = navigateUrl;

            hlNewBook.Visible = disk.NewBook;

            tbPrice.Text = disk.Price.ToString("N");

            hlNewBook.NavigateUrl = navigateUrl;

            lSubTitle.Text = new Resource(disk.SubTitleTextId)[WebSession.Language];

            hlPublisher.Text = new Resource(disk.PublisherTextId)[WebSession.Language];
            hlPublisher.NavigateUrl = disk.PublisherUrl;

            lDescription.Text = disk.ShortDescriptions[WebSession.Language];
        }
    }
}
