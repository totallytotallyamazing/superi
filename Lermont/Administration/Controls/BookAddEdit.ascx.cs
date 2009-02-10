using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;

public partial class Administration_Controls_BookAddEdit : UserControl
{
    public int BookId
    {
        get
        {
            if(ViewState["bookId"]!=null)
            {
                return Convert.ToInt32(ViewState["bookId"]);
            }
            return int.MinValue;
        }
        set { ViewState["bookId"] = value; }
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
        if(BookId>0)
        {
            Book book = new Book(BookId);
            reTitle.TextID = book.NameTextID;
            reSubTitle.TextID = book.SubTitleTextId;
            ibPicture.Attributes.Add("onclick", "return deleteClicked()");
            if (!string.IsNullOrEmpty(book.Picture))
            {
                ibPicture.ImageUrl = WebSession.ProductsImagesFolder.Replace("~", WebSession.BaseUrl) + book.Picture;
                ibPicture.Visible = true;
            }
            else
            {
                ibPicture.Visible = false;
            }
            reShortDescription.TextID = book.ShortDescriptionTextID;
            rePublisher.TextID = book.PublisherTextId;
            tbPublisherUrl.Text = book.PublisherUrl;
            cbNewBook.Checked = book.NewBook;
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
            tbPublisherUrl.Text = "";
            cbNewBook.Checked = false;
        }
    }

    private void SaveBook()
    {
        Book book = new Book(BookId);
        book.NameTextID = reTitle.Values.Save();
        book.SubTitleTextId = reSubTitle.Values.Save();
        book.ShortDescriptionTextID = reShortDescription.Values.Save();
        book.PublisherTextId = rePublisher.Values.Save();
        book.PublisherUrl = tbPublisherUrl.Text;
        book.NewBook = cbNewBook.Checked;
        book.Save();
        if (fuPicture.HasFile)
        {
            book.Picture = SavePicture(book.ID, fuPicture);
            book.Save();
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
        Book book = new Book(BookId);
        RemovePicture(book.Picture);
        book.Picture = string.Empty;
        book.Save();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SaveBook();
        OnSaveClick(e);
    }
}
