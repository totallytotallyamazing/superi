﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Helpers
{
    public static class Helpers
    {
        public static string GetText(string textName)
        {
            using (DataStorage context = new DataStorage())
            {
                return context.Texts.Where(c => c.Name == textName).Select(c => c.Content).First();
            }
        }

        public static string GetSeoText(string textName)
        {
            using (DataStorage context = new DataStorage())
            {
                return context.Texts.Where(c => c.Name == textName).Select(c => c.SeoCustomText).First();
            }
        }


        public static Text GetContent(string textName)
        {
            using (DataStorage context = new DataStorage())
            {
                return context.Texts.FirstOrDefault(c => c.Name == textName);
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
