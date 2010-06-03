using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lady.Areas.Admin.Controllers
{
    public class PostData : Dictionary<string, Dictionary<string, string>>
    {
    }
    
    
    public static class FormCollectionExtender
    {
        public static PostData ProcessPostData(this FormCollection form, params string[] excludeFields)
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
    }

}
