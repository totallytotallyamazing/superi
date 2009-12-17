using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;
using Dev.Models;
using System.Globalization;

namespace Dev.ModelBinders
{
    public class ArticleTranslationsBinder : IModelBinder
    {
        class PostData : Dictionary<string, Dictionary<string, string>>{}

        private PostData ProcessPostData(NameValueCollection form, params string[] excludeFields)
        {
            PostData result = new PostData();
            foreach (string key in form.Keys)
            {
                if (excludeFields == null || !excludeFields.Contains(key))
                {
                    string[] item = key.Split('_');
                    string itemId = item[1];
                    string fieldName = item[0];
                    if (!result.ContainsKey(itemId))
                        result[itemId] = new Dictionary<string, string>();
                    if (form[key] == "true,false")
                        result[itemId][fieldName] = "true";
                    else
                        result[itemId][fieldName] = form[key];
                }
            }
            return result;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ArticleTranslations result = new ArticleTranslations();
            
            NameValueCollection form = controllerContext.HttpContext.Request.Form;
            PostData postData = ProcessPostData(form);
            foreach (string key in postData.Keys)
            {
                Dictionary<string, string> item = postData[key];
                Article article = new Article();
                if (!string.IsNullOrEmpty(item["id"]))
                    article.Id = int.Parse(item["id"]);
                article.Language = key;
                article.Name = item["name"];
                article.Date = DateTime.Parse(item["date"], CultureInfo.CurrentUICulture);
                article.Description = HttpUtility.HtmlDecode(item["description"]);
                article.Image = item["image"];
                article.Title = item["title"];
                article.Text = HttpUtility.HtmlDecode(item["description"]);
                result.Add(key, article);
            }
            return result;
        }
    }
}
