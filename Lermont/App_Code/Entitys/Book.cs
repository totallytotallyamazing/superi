using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Shop;
public enum ProductPropertyTypes
{
    NewProduct, SubTitle, Publisher, PublisherUrl, AdditionalInfo, Price
}

/// <summary>
/// Summary description for Book
/// </summary>
public class Book : Product
{
    #region Fields
    private bool newBook = false;
    private int subTitleTextId = int.MinValue;
    private int publisherTextId = int.MinValue;
    private string publisherUrl = "";
    private int additionalInfo = int.MinValue;
    #endregion

    #region Properties
    public bool NewBook
    {
        get { return newBook; }
        set { newBook = value; }
    }

    public int SubTitleTextId
    {
        get { return subTitleTextId; }
        set { subTitleTextId = value; }
    }

    public int PublisherTextId
    {
        get { return publisherTextId; }
        set { publisherTextId = value; }
    }

    public string PublisherUrl
    {
        get { return publisherUrl; }
        set { publisherUrl = value; }
    }

    public int AdditionalInfoTextId
    {
        get { return additionalInfo; }
        set { additionalInfo = value; }
    }

    #endregion

    #region Constructors
    public Book() : base()
    {
        TypeId = 1;
    }
    public Book(int Id)
        : base()
    {
        Load(Id);
        LoadProperties(Id);
        TypeId = 1;
    }

    public Book(DataRow dr)
        : base()
    {
        Load(dr);
        TypeId = 1;
    }
    #endregion

    #region Methods
    private void LoadProperties(int Id)
    {
        string newBook = ProductPropertyValues.Get(Id, ProductPropertyTypes.NewProduct);
        if(!string.IsNullOrEmpty(newBook))
            NewBook = bool.Parse(newBook);
        string stId = ProductPropertyValues.Get(Id, ProductPropertyTypes.SubTitle);
        if (!string.IsNullOrEmpty(stId))
            subTitleTextId = int.Parse(stId);
        string publisher = ProductPropertyValues.Get(Id, ProductPropertyTypes.Publisher);
        if (!string.IsNullOrEmpty(publisher))
            publisherTextId = int.Parse(publisher);
        publisherUrl = ProductPropertyValues.Get(Id, ProductPropertyTypes.PublisherUrl);
        string info = ProductPropertyValues.Get(Id, ProductPropertyTypes.AdditionalInfo);
        if (!string.IsNullOrEmpty(info))
            additionalInfo = int.Parse(info);
    }

    public override bool Save()
    {
        base.Save();
        SaveProperties();
        return true;
    }

    private void SaveProperties()
    {
        ProductPropertyValues.Set(ID, (int)ProductPropertyTypes.NewProduct, newBook.ToString());
        ProductPropertyValues.Set(ID, (int)ProductPropertyTypes.SubTitle, subTitleTextId.ToString());
        ProductPropertyValues.Set(ID, (int)ProductPropertyTypes.Publisher, publisherTextId.ToString());
        ProductPropertyValues.Set(ID, (int)ProductPropertyTypes.PublisherUrl, publisherUrl);
        ProductPropertyValues.Set(ID, (int)ProductPropertyTypes.AdditionalInfo, additionalInfo.ToString());
    }

    private void DeleteProperties()
    {
        ProductPropertyValues.Delete(ID, ProductPropertyTypes.NewProduct);
        ProductPropertyValues.Delete(ID, ProductPropertyTypes.SubTitle);
        ProductPropertyValues.Delete(ID, ProductPropertyTypes.Publisher);
        ProductPropertyValues.Delete(ID, ProductPropertyTypes.PublisherUrl);
        ProductPropertyValues.Delete(ID, ProductPropertyTypes.AdditionalInfo);
    }

    public override bool Load(DataRow dr)
    {
        base.Load(dr);
        LoadProperties(ID);
        return true;
    }

    public override bool Remove()
    {
        DeleteProperties();
        return base.Remove();
    }
    #endregion
}
