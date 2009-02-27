using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for News
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class News : System.Web.Services.WebService
{
    [WebMethod]
    public int GetPageCount()
    {
        NewsDataContext context = new NewsDataContext();
        int count = context.NewsItems.Count();
        int result = count / 4;
        if (count % 4 > 0)
            result++;
        return result;
    }
}

