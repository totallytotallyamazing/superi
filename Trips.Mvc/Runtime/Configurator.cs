using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Configuration;
using System.Web.Configuration;

namespace Trips.Mvc.Runtime
{
    public static class Configurator
    {
        public static int PageSize { get { return int.Parse(GetSetting("GetSetting")); } }

        private static Configuration LoadConfiguration()
        {
            return WebConfigurationManager.OpenWebConfiguration("/Configuration");
        }

        public static string GetSetting(string name)
        {
            return LoadConfiguration().AppSettings.Settings[name].Value;
        }

        public static void SetSetting(string key, string value)
        {
            Configuration config = LoadConfiguration();
            config.AppSettings.Settings[key].Value = value;
            config.Save();
        }
    }
}
