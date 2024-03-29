﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using Zamov.Controllers;

namespace Zamov.Models
{
    public partial class City
    {
        private Dictionary<string, string> names = new Dictionary<string,string>();

        public Dictionary<string, string> Names
        {
            get 
            {
                return names;
            }
        }

        public void LoadNames()
        {
            using (ZamovStorage context = new ZamovStorage())
                names = (from translation in context.Translations
                         where (translation.ItemId == this.Id && translation.TranslationItemTypeId == (int)ItemTypes.City)
                         select new { lang = translation.Language, val = translation.Text })
                    .ToDictionary(k => k.lang, v => v.val);
        }

        public string NamesXml
        {
            get
            {
                return Utils.CreateTranslationXml(this.Id, ItemTypes.City, Names);
            }
        }

        public string GetName(string language)
        {
            if (Names.Count == 0)
                LoadNames();
            return GetName(language, true);
        }

        public string GetName(string language, bool replaceWithDefault)
        {
            string result = (replaceWithDefault) ? Name : "";
            if (Names.Keys.Contains(language))
                result = Names[language];
            return result;
        }
    }
}
