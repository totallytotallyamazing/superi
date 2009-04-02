using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Superi.Common;

/// <summary>
/// Summary description for DiskList
/// </summary>
public class DiskList:List<Disk>
{
    public DiskList(bool GetAll)
    {
        if (GetAll)
        {
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("typeid", 2));
            DataSet ds = AppData.ExecDataSet("Products_Get", parameterList);
            
            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                Load(ds.Tables[0]);
        }
    }

    public DiskList(int GroupId)
    {
        ParameterList parameterList = new ParameterList();
        parameterList.Add(new AppDbParameter("groupid", GroupId));
        DataSet ds = AppData.ExecDataSet("Products_Get", parameterList);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            Load(ds.Tables[0]);
    }



    public void Load(DataTable dt)
    {
        if (dt.Rows.Count > 0)
            foreach (DataRow row in dt.Rows)
            {
                Add(new Disk(row));
            }
    }
}
