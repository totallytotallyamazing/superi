using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Tours
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class Tours : System.Web.Services.WebService
{
    [WebMethod]
    public object GetTours()
    {
        TourDataContext context = new TourDataContext();
        List<Tour> result = context.Tours.Select(t => t).ToList();
        return result;
    }
}

