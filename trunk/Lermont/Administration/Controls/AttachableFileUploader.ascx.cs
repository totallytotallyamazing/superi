using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Controls_AttachableFileUploader : UserControl
{
    private int fileId = int.MinValue;
    private string language = "";

    public int FileId
    {
        get { return fileId; }
        set { fileId = value; }
    }

    public FileUpload File
    {
        get { return fuFile; }
    }

    public string Title
    {
        get { return Request.Form[tbTitle.UniqueID]; }
        set { tbTitle.Text = value; }
    }

    public string Language
    {
        get { return language; }
        set { language = value; }
    }

    //public int ItemId
    //{
    //    get { return itemId; }
    //    set { itemId = value; }
    //}

    //public int ItemType
    //{
    //    get { return itemType; }
    //    set { itemType = value; }
    //}

    

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //if (fileId > 0)
        //tbTitle.Text = Title;
    }

    //public void Save()
    //{
    //    if (fuFile.HasFile)
    //    {
    //        AttachableFile attachableFile = new AttachableFile(fileId);
    //        attachableFile.ItemId = itemId;
    //        attachableFile.ItemType = ItemType;
    //        attachableFile.Title = Title;
    //        attachableFile.Language = language;
    //        attachableFile.Save();
    //        attachableFile.FileName = SaveFile(attachableFile.Id);
    //        attachableFile.Save();
    //    }
    //}

    //private string SaveFile(int FId)
    //{
    //    string extension = fuFile.FileName.Substring(fuFile.FileName.LastIndexOf(".")); 
    //    string path = Server.MapPath(DefaultValues.AttachableFilesFolder) + "\\";
    //    fuFile.SaveAs(path + FId + extension);
    //    string result = path + FId + extension;
    //    return result;
    //}   
}

