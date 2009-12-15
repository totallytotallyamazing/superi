using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Dev.Helpers
{
    public static class Settings
    {
        public bool AllowMainMenuEdit { 
            get
            {
                bool result = false;
                if(ConfigurationManager.AppSettings["AllowMainMenuEdit"] == null)
                {
                    if (!bool.TryParse(ConfigurationManager.AppSettings["AllowMainMenuEdit"], out result))
                        throw new ConfigurationException("AllowMainMenuEdit can be only \"True\" or \"False\"");
                }
                return result;
            }
        }
    }
}
