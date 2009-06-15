using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class ToolsController : Controller
    {
        public static string CurrentLanguage
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["lang"] == null)
                    System.Web.HttpContext.Current.Session["lang"] = "uk-UA";
                return (string)System.Web.HttpContext.Current.Session["lang"];
            }
            set { System.Web.HttpContext.Current.Session["lang"] = value; }
        }
        public static void UpdateTranslations(Dictionary<string, string> translations, int ItemId, ItemTypes ItemType)
        {
            StorageContext context = StorageContext.Instanse;
            context.DeleteTranslations(ItemId, (int)ItemType);
            foreach (string key in translations.Keys)
            {
                Translation translation = new Translation
                {
                    ItemId = ItemId,
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
