using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Pandemiia.Helpers;

namespace Pandemiia.Services
{
    /// <summary>
    /// Summary description for Tools
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Tools : System.Web.Services.WebService
    {
        public object YoutubeProgress()
        {
            object result = null;
            if (YoutubeVerifier.Queried)
            {
                result = new
                {
                    queried = YoutubeVerifier.Queried,
                    items = YoutubeVerifier.Result.Select(r => new
                    {
                        entityTitle = r.Entity.Title,
                        title = r.Name,
                        id = r.ID
                    }
                    )
                };
            }
            else
            {
                result = new { queried = YoutubeVerifier.Queried, status = YoutubeVerifier.Status };
            }
            return result;
        }
    }
}
