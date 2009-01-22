using System.Data;
using Superi.Common;

/// <summary>
/// Summary description for ProductPropertyValues
/// </summary>
public static class ProductPropertyValues
{
    public static string Get(int ProductId, int PropertyId)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("productid", ProductId));
        parameterList.Add(new AppDbParameter("propertyid", PropertyId));
        DataSet ds = AppData.ExecDataSet("ProductPropertyValues_Get", parameterList);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            return ds.Tables[0].Rows[0]["Value"].ToString();
        return string.Empty;
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

    public static void Delete(int ProductId, int PropertyId)
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
