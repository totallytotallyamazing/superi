using System;
using System.Collections.Generic;
using System.Web;
using Superi.Shop;
using Superi.Features;
using Superi.Common;
using System.Data;
using System.Web.UI;

/// <summary>
/// Summary description for TradeMark
/// </summary>
public class TradeMark : Product
{
    #region Private fields
    private string recipients = "";
    private string eventSuggestion = "";
    private string ocasions = "";
    private List<int> associatedEventIds = new List<int>();
    private bool forMan = false;
    private bool forWoman = false;
    private bool goods = true;
    #endregion

    #region Public properties
    public string Recipients
    {
        get { return recipients; }
        set { recipients = value; }
    }

    public string EventSuggestion
    {
        get { return eventSuggestion; }
        set { eventSuggestion = value; }
    }

    public string Ocasions
    {
        get { return ocasions; }
        set { ocasions = value; }
    }

    public List<int> AssociatedEventIds
    {
        get { return associatedEventIds; }
        set { associatedEventIds = value; }
    }

    public EventList AssociatedEvents
    {
        get { return GetAssociatedEvents(); }
    }

    public bool ForWoman
    {
        get { return forWoman; }
        set { forWoman = value; }
    }

    public bool ForMan
    {
        get { return forMan; }
        set { forMan = value; }
    }

    public bool Goods
    {
        get { return goods; }
        set { goods = value; }
    }

    public VoucherList Vouchers
    {
        get { return new VoucherList(ID); }

    }
    #endregion

    #region Constructors
    public TradeMark()
    {
        Load(int.MinValue);
    }

    public TradeMark(int Id)
    {
        Load(Id);
    }

    public TradeMark(DataRow dr)
    {
        Load(dr);
    }
    #endregion

    #region Overriden methods

    public override bool Load(int Id)
    {
        base.Load(Id);
        LoadProperties();
        TypeId = (int)ProductTypes.TradeMark;
        return true;
    }
    
    public override bool Load(DataRow dr)
    {
        base.Load(dr);
        LoadProperties();
        TypeId = (int)ProductTypes.TradeMark;
        return true;
    }

    public override bool Save()
    {
        base.Save();
        DeleteProperties();
        SaveProperties();
        return true;
    }

    public override bool Remove()
    {
        DeleteProperties();
        Vouchers.Remove();
        return base.Remove();
    }
    #endregion

    #region Private methods
    private EventList GetAssociatedEvents()
    {
        ParameterList pList = new ParameterList();
        pList.Add(new AppDbParameter("productId", ID));
        pList.Add(new AppDbParameter("propertyId", ProductPropertyTypes.CalendarMapping));
        DataSet ds = AppData.ExecDataSet("Events_GetByProductId", pList);
        if (ds.Tables.Count > 0)
            return new EventList(ds.Tables[0]);
        return new EventList(false);
    }

    private void LoadProperties()
    {
        if (ID > 0)
        {
            associatedEventIds.Clear();
            List<Pair> pairList = ProductPropertyValues.GetMultiple(ID, null);
            foreach (Pair pair in pairList)
            {
                ProductPropertyTypes type = (ProductPropertyTypes)pair.First;
                switch (type)
                { 
                    case ProductPropertyTypes.EventSuggestion:
                        eventSuggestion = pair.Second.ToString();
                        break;
                    case ProductPropertyTypes.Ocasions:
                        ocasions = pair.Second.ToString();
                        break;
                    case ProductPropertyTypes.Recipients:
                        recipients = pair.Second.ToString();
                        break;
                    case ProductPropertyTypes.ForMan:
                        forMan = Convert.ToBoolean(pair.Second);
                        break;
                    case ProductPropertyTypes.ForWoman:
                        forWoman = Convert.ToBoolean(pair.Second);
                        break;
                    case ProductPropertyTypes.Goods:
                        goods = Convert.ToBoolean(pair.Second);
                        break;
                    case ProductPropertyTypes.CalendarMapping:
                        List<int> result = new List<int>();
                        associatedEventIds.Add(Convert.ToInt32(pair.Second));
                        break;
                }

            }
        }
    }

    private void SaveProperties()
    {
        if (ID > 0)
        {
            List<KeyValuePair<ProductPropertyTypes, string>> propertyValues = new List<KeyValuePair<ProductPropertyTypes, string>>();
            propertyValues.Add(new KeyValuePair<ProductPropertyTypes,string>(ProductPropertyTypes.EventSuggestion, eventSuggestion));
            propertyValues.Add(new KeyValuePair<ProductPropertyTypes,string>(ProductPropertyTypes.Ocasions, ocasions));
            propertyValues.Add(new KeyValuePair<ProductPropertyTypes, string>(ProductPropertyTypes.Recipients, recipients));
            propertyValues.Add(new KeyValuePair<ProductPropertyTypes, string>(ProductPropertyTypes.ForMan, forMan.ToString()));
            propertyValues.Add(new KeyValuePair<ProductPropertyTypes, string>(ProductPropertyTypes.ForWoman, forWoman.ToString()));
            propertyValues.Add(new KeyValuePair<ProductPropertyTypes, string>(ProductPropertyTypes.Goods, goods.ToString()));

            foreach (int item in AssociatedEventIds)
            {
                propertyValues.Add(new KeyValuePair<ProductPropertyTypes,string>(ProductPropertyTypes.CalendarMapping, item.ToString()));
            }
            ProductPropertyValues.SetMultiple(ID, propertyValues);
        }
    }

    private void DeleteProperties()
    {
        ProductPropertyValues.Delete(ID, null);
    }
    #endregion
}