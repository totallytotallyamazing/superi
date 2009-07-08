﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zamov.Models
{
    public partial class Product
    {
        private Dictionary<string, string> descriptions = new Dictionary<string, string>();

        public Dictionary<string, string> Descriptions
        {
            get
            {
                return descriptions;
            }
        }

        public void LoadDescriptions()
        {
            using (ZamovStorage context = new ZamovStorage())
                descriptions = (from translation in context.Translations
                         where (translation.ItemId == this.Id && translation.TranslationItemTypeId == (int)ItemTypes.ProductDescription)
                         select new { lang = translation.Language, val = translation.Text })
                    .ToDictionary(k => k.lang, v => v.val);
        }

        public string NamesXml
        {
            get
            {
                return Utils.CreateTranslationXml(this.Id, ItemTypes.City, Descriptions);
            }
        }

        public string GetDescription(string language)
        {
            string result = string.Empty;
            if (Descriptions.Keys.Contains(language))
                result = Descriptions[language];
            return result;
        }

    }
}
