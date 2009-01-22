using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Common;

/// <summary>
/// Summary description for BookList
/// </summary>
public class BookList : List<Book>
{
    public BookList(bool GetAll)
    {
        if (GetAll)
        {
            DataSet ds = AppData.ExecDataSet("Products_Get", null);
            
            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                Load(ds.Tables[0]);
        }
    }

    public BookList(int GroupId)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("groupid", GroupId));
        DataSet ds = AppData.ExecDataSet("Products_Get", parameterList);
        
        if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            Load(ds.Tables[0]);
    }

    public void Load(DataTable dt)
    {
        if (dt.Rows.Count > 0)
            foreach (DataRow row in dt.Rows)
            {
                Add(new Book(row));
            }
    }
}
