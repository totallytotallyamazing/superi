using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;
using MBrand.Models2;

namespace MBrand.Helpers
{
    public static class Helpers
    {
        public static string GetText(string textName)
        {
            using (var context = new DataStorage2())
            {
                return context.Texts.Where(c => c.Name == textName).Select(c => c.Content).First();
            }
        }

        public static string GetSeoText(string textName)
        {
            using (var context = new DataStorage2())
            {
                return context.Texts.Where(c => c.Name == textName).Select(c => c.SeoCustomText).First();
            }
        }


        public static MBrand.Models2.Text GetContent(string textName)
        {
            using (var context = new DataStorage2())
            {
                return context.Texts.FirstOrDefault(c => c.Name == textName);
            }
        }

        public static IEnumerable<MBrand.Models2.SecretImages>  GetSecretImages()
        {
            using (var context = new DataStorage2())
            {
                return context.SecretImages.ToList();
            }
        }

        public static string WriteText(this HtmlHelper helper, string textName)
        {
            return GetText(textName);
        }

        public static string WriteSeoText(this HtmlHelper helper, string textName)
        {
            return GetSeoText(textName);
        }
    }
}
