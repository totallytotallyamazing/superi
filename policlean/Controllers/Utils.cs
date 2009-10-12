
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PolialClean.Models;

namespace PolialClean.Controllers
{
    public static class Utils
    {
        public static string GetText(string textName)
        {
            using (DataStorage context = new DataStorage())
            {
                return context.SiteContent.Where(c => c.Name == textName).Select(c => c.Content).First();
            }
        }

        public static string GetText(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                return context.SiteContent.Where(c => c.Id == id).Select(c => c.Content).First();
            }
        }

        public static void SetText(string textName, string value)
        {
            using (DataStorage context = new DataStorage())
            {
                SiteContent text = context.SiteContent.Where(sc => sc.Name == textName).Select(sc => sc).First();
                text.Content = value;
                context.SaveChanges();
            }

        }
    }
}
