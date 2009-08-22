using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zamov.Models;
using System.Web.Caching;
using Zamov.Controllers;

public static class ApplicationData
{
    public static string ContactsHeader
    {
        get
        {
            string currentLanguage = SystemSettings.CurrentLanguage;
            if (HttpRuntime.Cache["ApplicationData_ContactsHeader_" + currentLanguage] == null)
            {
                using (SettingsStorage context = new SettingsStorage())
                {
                    string result = (from data in context.ApplicationSettings 
                                     where data.Name == "ContactsHeader" 
                                     && data.Language == currentLanguage
                                     select data.Value).First();
                    HttpRuntime.Cache.Insert("ApplicationData_ContactsHeader_" + currentLanguage, result, null, DateTime.Now.AddHours(3), Cache.NoSlidingExpiration);
                }
            }
            return HttpRuntime.Cache["ApplicationData_ContactsHeader_" + currentLanguage].ToString();
        }
        set
        {
            string currentLanguage = SystemSettings.CurrentLanguage;
            HttpRuntime.Cache.Remove("ApplicationData_ContactsHeader_" + currentLanguage);
            using (SettingsStorage context = new SettingsStorage())
            {
                ApplicationSettings result = (from data in context.ApplicationSettings 
                                              where data.Name == "ContactsHeader" 
                                              && data.Language == currentLanguage
                                              select data).First();
                result.Value = value;
                context.SaveChanges();
            }

        }
    }

    public static string Agreement
    {
        get
        {
            string currentLanguage = SystemSettings.CurrentLanguage;
            if (HttpRuntime.Cache["ApplicationData_Agreement_" + currentLanguage] == null)
            {
                using (SettingsStorage context = new SettingsStorage())
                {
                    string result = (from data in context.ApplicationSettings
                                     where data.Name == "Agreement"
                                     && data.Language == currentLanguage
                                     select data.Value).First();
                    HttpRuntime.Cache.Insert("ApplicationData_Agreement_" + currentLanguage, result, null, DateTime.Now.AddHours(3), Cache.NoSlidingExpiration);
                }
            }
            return HttpRuntime.Cache["ApplicationData_Agreement_" + currentLanguage].ToString();
        }
        set
        {
            string currentLanguage = SystemSettings.CurrentLanguage;
            HttpRuntime.Cache.Remove("ApplicationData_Agreement_" + currentLanguage);
            using (SettingsStorage context = new SettingsStorage())
            {
                ApplicationSettings result = (from data in context.ApplicationSettings
                                              where data.Name == "Agreement" 
                                              && data.Language == currentLanguage
                                              select data).First();
                result.Value = value;
                context.SaveChanges();
            }
        }
    }
}
