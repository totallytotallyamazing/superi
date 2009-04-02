using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;


public partial class Administration_Controls_DiskAddEdit : System.Web.UI.UserControl
{
    public int DiskId
    {
        get
        {
            if (ViewState["diskId"] != null)
            {
                return Convert.ToInt32(ViewState["diskId"]);
            }
            return int.MinValue;
        }
        set { ViewState["diskId"] = value; }
    }

    public delegate void SaveClikEventHandler(object sender, EventArgs e);

    public SaveClikEventHandler SaveClick;

    protected virtual void OnSaveClick(EventArgs e)
    {
        if (SaveClick != null)
            SaveClick(this, e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        InitControl();
    }

    private void InitControl()
    {
        if (DiskId > 0)
        {
            Disk disk = new Disk(DiskId);
            reTitle.TextID = disk.NameTextID;
            reSubTitle.TextID = disk.SubTitleTextId;
            ibPicture.Attributes.Add("onclick", "return deleteClicked()");
            if (!string.IsNullOrEmpty(disk.Picture))
            {
                ibPicture.ImageUrl = WebSession.ProductsImagesFolder.Replace("~", WebSession.BaseUrl) + disk.Picture;
                ibPicture.Visible = true;
            }
            else
            {
                ibPicture.Visible = false;
            }
            reShortDescription.TextID = disk.ShortDescriptionTextID;
            rePublisher.TextID = disk.PublisherTextId;
            tbPublisherUrl.Text = disk.PublisherUrl;
            tbPrice.Text = disk.Price.ToString();
            cbNewBook.Checked = disk.NewBook;
        }
        else
        {
            reTitle.TextID = int.MinValue;
            reSubTitle.TextID = int.MinValue;
            ibPicture.ImageUrl = "";
            ibPicture.Visible = false;
            ibPicture.Visible = false;
            reShortDescription.TextID = int.MinValue;
            rePublisher.TextID = int.MinValue;
            tbPrice.Text = "0";
            tbPublisherUrl.Text = "";
            cbNewBook.Checked = false;
        }
    }

    private void SaveDisk()
    {
        Disk disk = new Disk(DiskId);
        decimal price;
        decimal.TryParse(tbPrice.Text, out price);
        disk.Price = price;
        disk.NameTextID = reTitle.Values.Save();
        disk.SubTitleTextId = reSubTitle.Values.Save();
        disk.ShortDescriptionTextID = reShortDescription.Values.Save();
        disk.PublisherTextId = rePublisher.Values.Save();
        disk.PublisherUrl = tbPublisherUrl.Text;
        disk.NewBook = cbNewBook.Checked;

        disk.Save();
        if (fuPicture.HasFile)
        {
            disk.Picture = SavePicture(disk.ID, fuPicture);
            disk.Save();
        }
    }

    private string SavePicture(int Id, FileUpload upload)
    {
        string path = Server.MapPath(WebSession.ProductsImagesFolder) + "\\";
        string extention = upload.FileName.Substring(upload.FileName.LastIndexOf("."));
        upload.SaveAs(path + Id + extention);
        return Id + extention;
    }

    private void RemovePicture(string FileName)
    {
        string path = Server.MapPath(WebSession.ProductsImagesFolder) + "\\";
        File.Delete(path + FileName);
    }

    protected void ibPicture_Click(object sender, ImageClickEventArgs e)
    {
        Disk disk = new Disk(DiskId);
        RemovePicture(disk.Picture);
        disk.Picture = string.Empty;
        disk.Save();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SaveDisk();
        OnSaveClick(e);
    }
}
