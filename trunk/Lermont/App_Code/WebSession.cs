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
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies.Count > 0)
            {
                if (HttpContext.Current.Request.Cookies["language"] != null)
                {
                    HttpContext.Current.Session["Language"] = HttpContext.Current.Request.Cookies["language"].Value;
                }
            }
            if (HttpContext.Current.Session["Language"] != null)
            {
                return HttpContext.Current.Session["Language"].ToString();
            }
            if (HttpContext.Current.Session["Language"] != null && (string)HttpContext.Current.Session["Language"] != "")
            {
                return HttpContext.Current.Session["Language"].ToString();
            }
            {
                HttpContext.Current.Session["Language"] = "RU";
                return "UA";
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
            else
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

    public static string BaseUrl
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["BaseUrl"];
        }
    }

    public static string BaseImageUrl
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["BaseImageUrl"];
        }
    }

    public static string TextImagesFolder
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["TextImagesFolder"];
        }
    }

    public static string NewsImagesFolder
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["NewsImagesFolder"];
        }
    }

    public static string ArticlesImagesFolder
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["ArticlesImagesFolder"];
        }
    }

    public static string ProductsImagesFolder
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["ProductsImagesFolder"];
        }
    }

    public static string MenuImagesFolder
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["MenuImagesFolder"];
        }
    }

    public static string GalleryImagesFolder
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["GalleryImagesFolder"];
        }
    }

    public static string AttachableFilesFolder
    {
        get
        {
            return System.Configuration.ConfigurationManager.AppSettings["AttachableFilesFolder"];
        }
    }

    //public static int ContentWidth
    //{
    //    get
    //    {
    //        if (HttpContext.Current.Session["contentWidth"] != null)
    //        {
    //            return (int)HttpContext.Current.Session["contentWidth"];
    //        }
    //        else
    //            return 580;
    //    }
    //    set { HttpContext.Current.Session["contentWidth"] = value; }
    //}

    //public static bool DisplaySubMenu
    //{
    //    get
    //    {
    //        if (HttpContext.Current.Session["displaySubMenu"] != null)
    //        {
    //            return (bool)HttpContext.Current.Session["displaySubMenu"];
    //        }
    //        else
    //            return true;
    //    }
    //    set { HttpContext.Current.Session["displaySubMenu"] = value; }
    //}
}
