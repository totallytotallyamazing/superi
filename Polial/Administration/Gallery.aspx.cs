using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.CustomControls;

public partial class Administration_Gallery : System.Web.UI.Page
{
    private int NavigationId
    {
        get 
        {
            if (!string.IsNullOrEmpty(Request.Form[ddlNavigation.UniqueID]))
                return int.Parse(Request.Form[ddlNavigation.UniqueID]);
            if (!string.IsNullOrEmpty(ddlNavigation.SelectedValue))
                return int.Parse(ddlNavigation.SelectedValue);
            return int.MinValue;
        }
    }

    private int PropertiesNavigationId
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.Form[ddlNavigationsProperty.UniqueID]))
                return int.Parse(Request.Form[ddlNavigationsProperty.UniqueID]);
            if (!string.IsNullOrEmpty(ddlNavigationsProperty.SelectedValue))
                return int.Parse(ddlNavigationsProperty.SelectedValue);
            return int.MinValue;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 12; i++)
        {
            //  GalleryUpload galleryUpload = (GalleryUpload)
            phUpload.Controls.Add(LoadControl("~/administration/controls/galleryupload.ascx"));
        }
        /*btnSaveProperties.Attributes.Add("onclick", "setAction('changeParams');");*/
        NavigationList navigationList = new NavigationList(true);
        ddlNavigationsProperty.Items.Clear();
        ddlNavigation.Items.Clear();
        ddlNavigation.Items.Add(new ListItem("Выберите раздел", int.MinValue.ToString()));
        ddlNavigationsProperty.Items.Add(new ListItem("Выберите раздел", int.MinValue.ToString()));
        foreach (Navigation navigation in navigationList)
        {
            ListItem item = new ListItem(navigation.Texts["RU"], navigation.ID.ToString());
            ListItem itemProperties = new ListItem(navigation.Texts["RU"], navigation.ID.ToString());
            ddlNavigation.Items.Add(item);
            ddlNavigationsProperty.Items.Add(itemProperties);
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        gwGallery.DataBind();
        if (gwGallery.Rows.Count == 0)
            btnDelete.Visible = false;
        else
            btnDelete.Visible = true;
    }

    protected void gwGallery_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            {
                GalleryItem item = (GalleryItem)e.Row.DataItem;
                Image iPreview = (Image)e.Row.FindControl("iPreview");
                Image iLogo = (Image) e.Row.FindControl("iLogo");
                iPreview.ImageUrl = WebSession.GalleryImagesFolder + item.Preview;

                if(!string.IsNullOrEmpty(item.Url))
                {
                    iLogo.ImageUrl = WebSession.ClientLogosFolder + item.Url;
                }
                else
                    iLogo.Visible = false;

                LinkButton lbChange = (LinkButton) e.Row.FindControl("lbChange");
                lbChange.CommandArgument = item.ID.ToString();
                lbChange.Attributes.Add("onclick", "setAction('changeParams');");
            }
        }
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath(WebSession.GalleryImagesFolder) + PicturePath;
            File.Delete(path);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        foreach (GalleryUpload galleryUpload in phUpload.Controls)
        {
            if(galleryUpload.Picture.HasFile && galleryUpload.Preview.HasFile)
            {
                GalleryItem item = new GalleryItem();
                item.Save();
                string path = Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
                string extPicture = galleryUpload.Picture.FileName.Substring(galleryUpload.Picture.FileName.LastIndexOf("."));
                galleryUpload.Picture.SaveAs(path + item.ID + extPicture);

                item.Picture = item.ID + extPicture;

                string extPreview = galleryUpload.Preview.FileName.Substring(galleryUpload.Preview.FileName.LastIndexOf("."));
                galleryUpload.Preview.SaveAs(path + "pr_" + item.ID + extPreview);

                item.Preview = "pr_" + item.ID + extPreview;

                item.GalleryID = NavigationId;
                item.Save();
            }
        }
    }
    protected void gwGallery_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void gwGallery_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int itemId = int.Parse(e.Keys["ID"].ToString());
        GalleryItem item = new GalleryItem(itemId);
        RemovePicture(item.Picture);
        RemovePicture(item.Preview);
        RemoveClientLogo(item.Url);
    }
    protected void gwGallery_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Delete")
        {
            int itemId = int.Parse(e.CommandArgument.ToString());
            GalleryItem item = new GalleryItem(itemId);
            reNames.TextID = item.TitleTextId;

            if (item.SubTitleTextId > 0)
            {
                string ruValue = item.SubTitles["RU"];
                string enValue = item.SubTitles["EN"];

                char[] sep = {'%'};

                string[] ruValues = ruValue.Split(sep);
                string[] enValues = enValue.Split(sep);
                string ruClient = "";
                string enClient = "";
                string ruAddress = "";
                string enAddress = "";
                string year = "";
                string square = "";
                string ruWorkKinds = "";
                string enWorkKinds = "";

                ruClient = ruValues[0];
                ruAddress = ruValues[1];
                year = ruValues[2];
                square = ruValues[3];
                ruWorkKinds = ruValues[4];

                enClient = enValues[0];
                enAddress = enValues[1];
                enWorkKinds = enValues[4];

                reClient._Values.Items.Clear();
                reClient._Values.Items["RU"] = ruClient;
                reClient._Values.Items["EN"] = enClient;
                reAddress._Values.Items.Clear();
                reAddress._Values.Items["RU"] = ruAddress;
                reAddress._Values.Items["EN"] = enAddress;
                tbYear.Text = year;
                tbSquare.Text = square;
                reWorkKinds._Values.Items.Clear();
                reWorkKinds._Values.Items["RU"] = ruWorkKinds;
                reWorkKinds._Values.Items["EN"] = enWorkKinds;

                ddlNavigationsProperty.SelectedValue = item.GalleryID.ToString();
            }

            hfGalleryItemId.Value = e.CommandArgument.ToString();
        }
    }

    protected void btnSaveProperties_Click(object sender, EventArgs e)
    {
        int itemId = int.Parse(hfGalleryItemId.Value);
        GalleryItem item = new GalleryItem(itemId);
        item.TitleTextId = reNames.Values.Save();

        Resource resource = new Resource(item.SubTitleTextId);

        string ruClient = reClient.Values["RU"];
        string enClient = reClient.Values["EN"];
        string ruAddress = reAddress.Values["RU"];
        string enAddress = reAddress.Values["EN"];
        string year = tbYear.Text;
        string square = tbSquare.Text;
        string ruWorkKinds = reWorkKinds.Values["RU"];
        string enWorkKinds = reWorkKinds.Values["EN"];


        string ruValue = ruClient + "%" + ruAddress + "%" + year + "%" + square + "%" + ruWorkKinds;
        string enValue = enClient + "%" + enAddress + "%" + year + "%" + square + "%" + enWorkKinds;

        resource.Items.Clear();

        resource.Items.Add("RU", ruValue);
        resource.Items.Add("EN", enValue);

        item.SubTitleTextId = resource.Save();

        item.Save();

        if(fuLogo.HasFile)
        {
            RemoveClientLogo(item.Url);
            string path = Server.MapPath(WebSession.ClientLogosFolder) + "\\";
            string extPicture = fuLogo.FileName.Substring(fuLogo.FileName.LastIndexOf("."));

            fuLogo.SaveAs(path + item.ID + extPicture);

            item.Url = item.ID + extPicture;
            item.Save();
        }
        
        if (fuPicture.HasFile)
        {
            RemovePicture(item.Picture);
            string path = Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
            string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
            fuPicture.SaveAs(path + item.ID + extPicture);

            item.Picture = item.ID + extPicture;
            item.Save();
        }
        
        if (fuPreview.HasFile)
        {
            RemovePicture(item.Preview);
            string path = Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
            string extPicture = fuPreview.FileName.Substring(fuPreview.FileName.LastIndexOf("."));
            fuPreview.SaveAs(path + "pr_" + item.ID + extPicture);

            item.Preview = item.ID + extPicture;
            item.Save();
        }
        item.GalleryID = PropertiesNavigationId;
        item.Save();
        gwGallery.DataBind();
    }

    private void RemoveClientLogo(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath(WebSession.ClientLogosFolder) + PicturePath;
            File.Delete(path);
        }
    }



    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gwGallery.Rows)
        {
            CheckBox cbDelete = (CheckBox)row.FindControl("cbDelete");
            if (cbDelete.Checked)
            {
                int itemId = int.Parse(row.Cells[0].Text);
                GalleryItem item = new GalleryItem(itemId);
                RemovePicture(item.Picture);
                RemovePicture(item.Preview);
                RemoveClientLogo(item.Url);
                item.Remove();
                gwGallery.DataBind();
            }
        }
    }
}
