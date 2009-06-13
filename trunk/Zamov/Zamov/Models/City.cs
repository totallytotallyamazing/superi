using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zamov.Models
{
    public partial class City
    {
        //public const ItemTypes ItemType = ItemTypes.City;

        public Dictionary<string, string> Names
        {
            get 
            {
                StorageContext context = StorageContext.Instanse;
                return (from translation in context.Translations
                        where( translation.ItemId == this.Id && translation.TranslationItemTypeId == (int)ItemTypes.City)
                        select new { lang = translation.Language, val = translation.Text })
                        .ToDictionary(k => k.lang, v => v.val);
            }
        }

        public string GetName(string language)
        {
            return GetName(language, true);
        }

        public string GetName(string language, bool replaceWithDefault)
        {
            string result = (replaceWithDefault) ? Name : "";
            if (Names.Keys.Contains(language))
                result = Names[language];
            return result;
        }

        public void UpdateTranslations(Dictionary<string, string> translations)
        {
            StorageContext context = StorageContext.Instanse;
            context.DeleteTranslations(this.Id, (int)ItemTypes.City);
            foreach (string key in translations.Keys)
            {
                Translation translation = new Translation
                {
                    ItemId = this.Id,
                    Language = key,
                    TranslationItemTypeId = (int)ItemTypes.City,
                    Text = translations[key]
                };
                context.AddToTranslations(translation);
            }
            context.SaveChanges();
        }
    }
}
