using System.Web;

/// <summary>
/// Summary description for WebSession
/// </summary>
public static class WebSession
{
    public static string Language
    {
        get 
        {
            if (HttpContext.Current.Session["Language"] != null)
            {
                return HttpContext.Current.Session["Language"].ToString();
            }
            else
            {
                if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies.Count > 0)
                {
                    if (HttpContext.Current.Request.Cookies["language"] != null)
                    {
                        HttpContext.Current.Session["Language"] = HttpContext.Current.Request.Cookies["language"].Value;
                    }
                }
                if (HttpContext.Current.Session["Language"] != null && (string) HttpContext.Current.Session["Language"]!="")
                {
                    return HttpContext.Current.Session["Language"].ToString();
                }
                {
                    HttpContext.Current.Session["Language"] = "UA";
                    return "UA";
                }
            }
                
        }
        set { HttpContext.Current.Session["Language"] = value; }
    }

    public static int NavigationID
    {
        get
        {
            if (HttpContext.Current.Session["nid"] != null)
            {
                return (int)HttpContext.Current.Session["nid"];
            }
            return 1;
        }
        set { HttpContext.Current.Session["nid"] = value; }
    }

    public static int TextID
    {
        get
        {
            if (HttpContext.Current.Session["tid"] != null)
            {
                return (int)HttpContext.Current.Session["tid"];
            }
            return int.MinValue;
        }
        set { HttpContext.Current.Session["tid"] = value; }
    }

    public static int ArticleID
    {
        get
        {
            if (HttpContext.Current.Session["aid"] != null)
            {
                return (int)HttpContext.Current.Session["aid"];
            }
            return int.MinValue;
        }
        set { HttpContext.Current.Session["aid"] = value; }
    }

    public static int ContentWidth
    {
        get
        {
            if (HttpContext.Current.Session["contentWidth"] != null)
            {
                return (int)HttpContext.Current.Session["contentWidth"];
            }
            else
                return 580;
        }
        set { HttpContext.Current.Session["contentWidth"] = value; }
    }

    public static bool DisplaySubMenu
    {
        get
        {
            if (HttpContext.Current.Session["displaySubMenu"] != null)
            {
                return (bool)HttpContext.Current.Session["displaySubMenu"];
            }
            else
                return true;
        }
        set { HttpContext.Current.Session["displaySubMenu"] = value; }
    }
}
