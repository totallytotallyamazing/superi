using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zamov.Models
{
    public partial class Category
    {
        public Dictionary<string, string> Names
        {
            get
            {
                ZamovStorage context = new ZamovStorage();
                return (from translation in context.Translations
                        where (translation.ItemId == this.Id && translation.TranslationItemTypeId == (int)ItemTypes.Category)
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
            ZamovStorage context = new ZamovStorage();
            context.DeleteTranslations(this.Id, (int)ItemTypes.Category);
            foreach (string key in translations.Keys)
            {
                Translation translation = new Translation
                {
                    ItemId = this.Id,
                    Language = key,
                    TranslationItemTypeId = (int)ItemTypes.Category,
                    Text = translations[key]
                };
                context.AddToTranslations(translation);
            }
        }
    }
}
