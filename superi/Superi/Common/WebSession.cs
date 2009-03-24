using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Superi.Common
{
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
                if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies.Count > 0)
                {
                    if (HttpContext.Current.Request.Cookies["language"] != null)
                    {
                        HttpContext.Current.Session["Language"] = HttpContext.Current.Request.Cookies["language"].Value;
                    }
                }
                if (HttpContext.Current.Session["Language"] != null && (string)HttpContext.Current.Session["Language"] != "")
                {
                    return HttpContext.Current.Session["Language"].ToString();
                }
                {
                    HttpContext.Current.Session["Language"] = DefaultLanguage;
                    return DefaultLanguage;
                }
            }
            set { HttpContext.Current.Session["Language"] = value; }
        }

        public static string DefaultLanguage
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"];
            }
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

        public static string BaseUrl
        {
            get
            {
                return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Scheme) + HttpContext.Current.Request.Url.Host + WebSession.VirtualDirectoryName;
            }
        }

        public static string DefaultBaseUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["BaseUrl"];
            }        
        }

        public static string VirtualDirectoryName
        {
            get
            {
                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["VirtualDirectoryName"]))
                    return System.Configuration.ConfigurationManager.AppSettings["VirtualDirectoryName"];
                else
                    return "/";
            }
        }

        public static string BaseImageUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["BaseImageUrl"];
            }
        }

        public static string SmtpServer
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SmtpServer"];
            }
        }

        public static string SmtpAccount
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SmtpAccount"];
            }
        }


        public static string SmptPassword
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SmptPassword"];
            }
        }

        public static string NotificationsSource
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["NotificationsSource"];
            }
        }

        public static string DefaultNotificationsReceiver
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DefaultNotificationsReceiver"];
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

        public static string ClientLogosFolder
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ClientLogosFolder"];
            }
        }

    }
}
