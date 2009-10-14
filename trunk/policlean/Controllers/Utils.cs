
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PolialClean.Models;

namespace PolialClean.Controllers
{
    public static class Utils
    {
        public static SiteContent GetText(string textName)
        {
            using (DataStorage context = new DataStorage())
            {
                SiteContent result = context.SiteContent.Where(c => c.Name == textName).Select(c => c).First();
                context.Detach(result);
                return result;
            }
        }

        public static SiteContent GetText(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                SiteContent result = context.SiteContent.Where(c => c.Id == id).Select(c => c).First();
                context.Detach(result);
                return result;
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
