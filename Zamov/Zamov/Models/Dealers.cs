using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zamov.Controllers;

namespace Zamov.Models
{
    public partial class Dealer
    {
        private Dictionary<string, string> names = new Dictionary<string, string>();
        private Dictionary<string, string> descriptions = new Dictionary<string, string>();

        public Dictionary<string, string> Descriptions
        {
            get { return descriptions; }
        }

        public Dictionary<string, string> Names
        {
            get { return names; }
        }

        public string NamesXml
        {
            get
            {
                return Utils.CreateTranslationXml(this.Id, ItemTypes.DealerName, Names);
            }
        }

        public string DescriptionsXml
        {
            get
            {
                return Utils.CreateTranslationXml(this.Id, ItemTypes.DealerDescription, Descriptions);
            }
        }

        public void LoadNames()
        {
            using (ZamovStorage context = new ZamovStorage())
                names = (from translation in context.Translations
                         where (translation.ItemId == this.Id && translation.TranslationItemTypeId == (int)ItemTypes.DealerName)
                         select new { lang = translation.Language, val = translation.Text })
                    .ToDictionary(k => k.lang, v => v.val);
        }

        public void LoadDescriptions()
        {
            using (ZamovStorage context = new ZamovStorage())
                descriptions = (from translation in context.Translations
                         where (translation.ItemId == this.Id && translation.TranslationItemTypeId == (int)ItemTypes.DealerDescription)
                         select new { lang = translation.Language, val = translation.Text })
                    .ToDictionary(k => k.lang, v => v.val);
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

        public string GetDescription(string language)
        {
            if (Descriptions.Count == 0)
                LoadDescriptions();
            string result = "";
            if (Descriptions.Keys.Contains(language))
                result = Descriptions[language];
            return result;
        }
    }
}
