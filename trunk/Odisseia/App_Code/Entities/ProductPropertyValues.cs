using System.Data;
using Superi.Common;
using System.Collections.Generic;
using Superi.Shop;
using System;
using System.Web.UI;

/// <summary>
/// Summary description for ProductPropertyValues
/// </summary>
public static class ProductPropertyValues
{
    private static DataSet GetDs(int ProductId, int? PropertyId)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("productid", ProductId));
        parameterList.Add(new AppDbParameter("propertyid", PropertyId));
        return AppData.ExecDataSet("ProductPropertyValues_Get", parameterList);
    }

    public static string Get(int ProductId, int PropertyId)
    {
        DataSet ds = GetDs(ProductId, PropertyId);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            return ds.Tables[0].Rows[0]["Value"].ToString();
        return string.Empty;
    }

    public static List<Pair> GetMultiple(int ProductId, int? PropertyId)
    {
        List<Pair> result = new List<Pair>();
        DataSet ds = GetDs(ProductId, PropertyId);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { 
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new Pair((ProductPropertyTypes)dr["PropertyId"], dr["Value"].ToString()));
            }
        }
        return result;
    }

    public static List<Pair> GetMultiple(int ProductId, ProductPropertyTypes PropertyId)
    {
        return GetMultiple(ProductId, (int)PropertyId);
    }

    public static string Get(int ProductId, ProductPropertyTypes PropertyId)
    {
        return Get(ProductId, (int) PropertyId);
    }

    public static void Set(int ProductId, int PropertyId, string Value)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("productid", ProductId));
        parameterList.Add(new AppDbParameter("propertyid", (int)PropertyId));
        parameterList.Add(new AppDbParameter("value", Value));
        AppData.ExecStoredProcedure("ProductPropertyValues_Set", parameterList);
    }

    public static void Set(int ProductId, ProductPropertyTypes PropertyId, string Value)
    {
        Set(ProductId, (int)PropertyId, Value);
    }

    public static void SetMultiple(int ProductId, List<KeyValuePair<ProductPropertyTypes, string>> PropertyValues)
    {
        string propertyIds = "";
        string values = "";
        foreach (KeyValuePair<ProductPropertyTypes, string> kvPair in PropertyValues)
        {
            propertyIds += (int)kvPair.Key;
            propertyIds += ";";
            values += kvPair.Value;
            values += "|||";
        }
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("productid", ProductId));
        parameterList.Add(new AppDbParameter("propertyids", propertyIds));
        parameterList.Add(new AppDbParameter("values", values));
        AppData.ExecStoredProcedure("ProductPropertyValues_AddMultiple", parameterList);
    }

    //public static void SetMultiple(int ProductId, ProductPropertyTypes PropertyId, string ValueList)
    //{
    //    SetMultiple(ProductId, (int)PropertyId, ValueList);
    //}

    public static void Delete(int ProductId, int? PropertyId)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("productid", ProductId));
        parameterList.Add(new AppDbParameter("propertyid", PropertyId));
        AppData.ExecStoredProcedure("ProductPropertyValues_Delete", parameterList);
    }

    public static void Delete(int ProductId, ProductPropertyTypes PropertyId)
    {
        Delete(ProductId, (int)PropertyId);
    }

    

}
