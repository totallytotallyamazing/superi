using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zamov.Models;
using System.Web.Caching;
using Zamov.Controllers;
using System.Data.Common;
using System.Data.EntityClient;

public static class ApplicationData
{
    public static string ContactsHeader
    {
        get { return GetApplicationData("ContactsHeader", SystemSettings.CurrentLanguage); }
    }

    public static string Agreement
    {
        get { return GetApplicationData("Agreement", SystemSettings.CurrentLanguage); }
    }

    public static void UpdateAgreement(Dictionary<string, string> values)
    {
        UpdateApplicationData("Agreement", values);
    }

    public static void UpdateContactsHeader(Dictionary<string, string> values)
    {
        UpdateApplicationData("ConteactsHeader", values);
    }

    private static string GetApplicationData(string name, string language)
    {
        if (HttpRuntime.Cache["ApplicationData_" + name + "_" + language] == null)
        {
            using (SettingsStorage context = new SettingsStorage())
            {
                string result = (from data in context.ApplicationSettings
                                 where data.Name == name
                                 && data.Language == language
                                 select data.Value).First();
                HttpRuntime.Cache.Insert("ApplicationData_" + name + "_" + language, result, null, DateTime.Now.AddHours(3), Cache.NoSlidingExpiration);
            }
        }
        return HttpRuntime.Cache["ApplicationData_" + name + "_" + language].ToString();
    }

    private static void UpdateApplicationData(string name, Dictionary<string, string> values)
    {
        using (SettingsStorage context = new SettingsStorage())
        {
            foreach (string key in values.Keys)
            {
                EntityCommand command = (context.Connection.CreateCommand() as EntityCommand);
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE ApplicationSettings SET " + name + " = '" + values[key] + "' where Language = '" + key + "'";
                command.ExecuteNonQuery();
            }
            context.SaveChanges();
        }
    }
}
