using System;

public partial class Administration_Controls_EditBokDescription : System.Web.UI.UserControl
{
    public int BookId
    {
        get
        {
            if (ViewState["bookId"] != null)
                return Convert.ToInt32(ViewState["bookId"]);
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
        PublishProperties();
    }

    private void PublishProperties()
    {
        if(BookId>0)
        {
            Book book = new Book(BookId);
            reAdditionalInfo.TextID = book.AdditionalInfoTextId;
            reDescription.TextID = book.DescriptionTextID;
        }
        else
        {
            reAdditionalInfo.TextID = int.MinValue;
            reDescription.TextID = int.MinValue;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (BookId > 0)
        {
            Book book = new Book(BookId);
            book.DescriptionTextID = reDescription.Values.Save();
            book.AdditionalInfoTextId = reAdditionalInfo.Values.Save();
            book.Save();
        }
        OnSaveClick(e);
    }
}
