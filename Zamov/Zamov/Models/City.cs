using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zamov.Models
{
    public partial class City
    {
        public Dictionary<string, string> Names
        {
            get 
            {
                ZamovStorage context = new ZamovStorage();
                return (from translation in context.Translations
                        where( translation.ItemId == this.Id && translation.TranslationItemTypeId == (int)ItemTypes.City)
                        select new { lang = translation.Language, val = translation.Text })
                        .ToDictionary(k => k.lang, v => v.val);
            }
        }

        public void UpdateTranslations(Dictionary<string, string> translations)
        {
            ZamovStorage context = new ZamovStorage();
            
        }
    }
}
