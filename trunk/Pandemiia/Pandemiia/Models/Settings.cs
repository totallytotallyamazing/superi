using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Pandemiia.Models
{
    public static class Settings
    {
        public static int PageSize
        {
            get 
            {
                try
                {
                    return int.Parse(WebConfigurationManager.AppSettings["pageSize"]);
                }
                catch
                {
                    throw new Exception("Page size should be set in the configuration file. Update the appSettings section pageSize key");
                }
            }
        }
    }
}
