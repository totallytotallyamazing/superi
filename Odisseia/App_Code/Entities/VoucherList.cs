using System;
using System.Collections.Generic;
using System.Data;
using Superi.Common;

/// <summary>
/// Summary description for VoucherList
/// </summary>
public class VoucherList : List<Voucher>
{
    public VoucherList()
    {
    }

    public VoucherList(bool GetAll)
    {
        if (GetAll)
        {
            Load();
        }
    }

    public VoucherList(int ProductId)
    {
        Load(ProductId);
    }

    public void Load()
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("typeid", ProductTypes.Voucher));
        DataSet ds = AppData.ExecDataSet("Products_Get", parameterList);
        if (ds.Tables.Count > 0)
            Load(ds.Tables[0]);
    }

    public void Load(int ProductId)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("propertyId", ProductPropertyTypes.ProductId));
        parameterList.Add(new AppDbParameter("value", ProductId.ToString()));

        DataSet ds = AppData.ExecDataSet("Products_GetByPropertyValue", parameterList);
        if (ds.Tables.Count > 0)
            Load(ds.Tables[0]);
    }

    public void Load(DataTable dt)
    {
        if (dt.Rows.Count > 0)
            foreach (DataRow row in dt.Rows)
            {
                Add(new Voucher(row));
            }
    }

    public void Remove()
    {
        foreach (Voucher voucher in this)
        {
            voucher.Remove();   
        }
    }
}