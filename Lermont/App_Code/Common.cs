using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Superi.Features;

/// <summary>
/// Summary description for Common
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Common : System.Web.Services.WebService
{

    public Common()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public int CreateText(string Name)
    {
        Text text = new Text();
        text.Name = Name;
        text.Save();
        return text.ID;
    }
}

