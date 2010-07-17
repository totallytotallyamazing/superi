using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Configuration;
using System.Web.Configuration;
using Shop.Models;
using System.Reflection;
using System.Globalization;

namespace Trips.Mvc.Runtime
{
    public static class Configurator
    {
        private static Configuration configuration = null;

        public static int PageSize { get { return int.Parse(GetSetting("GetSetting")); } }

        private static Configuration LoadConfiguration()
        {
            if (configuration == null)
                configuration = WebConfigurationManager.OpenWebConfiguration("/Configuration");
            return configuration;
        }

        public static string GetSetting(string name)
        {

            KeyValueConfigurationElement element = LoadConfiguration().AppSettings.Settings[name];
            if(element!=null)
                return LoadConfiguration().AppSettings.Settings[name].Value;
            return null;
        }

        public static void SetSetting(string key, string value)
        {
            Configuration config = LoadConfiguration();
            config.AppSettings.Settings[key].Value = value;
            config.Save();
            configuration = null;
        }

        public static SiteSettings LoadSettings()
        {
            SiteSettings result = new SiteSettings();
            PropertyInfo[] properties = typeof(SiteSettings).GetProperties();
            foreach (var item in properties)
            {
                string stringValue = GetSetting(item.Name);
                if (!string.IsNullOrEmpty(stringValue))
                {
                    object value = Convert.ChangeType(stringValue, item.PropertyType, CultureInfo.CurrentUICulture);
                    item.SetValue(result, value, null);
                }
            }
            return result;
        }

        public static void SaveSettings(object settings)
        {
            Configuration config = LoadConfiguration();
            PropertyInfo[] properties = settings.GetType().GetProperties();
            config.AppSettings.Settings.Clear();
            foreach (var item in properties)
            {
                object value = item.GetValue(settings, null);
                string stringValue = Convert.ToString(value, CultureInfo.CurrentUICulture);
                config.AppSettings.Settings.Add(item.Name, stringValue);
            }
            config.Save();
            configuration = null;
        }
    }
}
