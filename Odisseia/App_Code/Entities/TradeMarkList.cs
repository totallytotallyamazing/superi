using System;
using System.Collections.Generic;
using System.Data;
using Superi.Common;

/// <summary>
/// Summary description for TradeMarkList
/// </summary>
public class TradeMarkList : List<TradeMark>
{
    public TradeMarkList()
    {
    }

    public TradeMarkList(bool GetAll)
    {
        if (GetAll)
        {
            Load();
        }
    }

    public TradeMarkList(bool ForMan, bool ForWoman)
    {
        Load(ForMan, ForWoman);
    }

    public TradeMarkList(int EventId)
    {
        Load(EventId);
    }

    public void Load(bool ForMan, bool ForWoman)
    {
        if (ForMan && !ForWoman)
        {
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("propertyId", ProductPropertyTypes.ForMan));
            parameterList.Add(new AppDbParameter("value", true.ToString()));

            DataSet ds = AppData.ExecDataSet("Products_GetByPropertyValue", parameterList);
            if (ds.Tables.Count > 0)
                Load(ds.Tables[0]);
        }
        else if (ForWoman && !ForMan)
        {
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("propertyId", ProductPropertyTypes.ForWoman));
            parameterList.Add(new AppDbParameter("value", true.ToString()));

            DataSet ds = AppData.ExecDataSet("Products_GetByPropertyValue", parameterList);
            if (ds.Tables.Count > 0)
                Load(ds.Tables[0]);
        }
        else
        {
            Load();
        }
    }

    public void Load(int EventId)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("propertyId", ProductPropertyTypes.CalendarMapping));
        parameterList.Add(new AppDbParameter("value", EventId.ToString()));

        DataSet ds = AppData.ExecDataSet("Products_GetByPropertyValue", parameterList);
        if (ds.Tables.Count > 0)
            Load(ds.Tables[0]);
    }

    public void LoadByType(bool Goods)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("propertyId", ProductPropertyTypes.Goods));
        parameterList.Add(new AppDbParameter("value", Goods.ToString()));

        DataSet ds = AppData.ExecDataSet("Products_GetByPropertyValue", parameterList);
        if (ds.Tables.Count > 0)
            Load(ds.Tables[0]);
    }

    public void Load()
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("typeid", ProductTypes.TradeMark));
        DataSet ds = AppData.ExecDataSet("Products_Get", parameterList);
        if (ds.Tables.Count > 0)
            Load(ds.Tables[0]);
            
    }

    public void Load(DataTable dt)
    {
        if (dt.Rows.Count > 0)
            foreach (DataRow row in dt.Rows)
            {
                Add(new TradeMark(row));
            }
    }
}