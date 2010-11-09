using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dev.Helpers
{
    public class PostData : Dictionary<string, Dictionary<string, string>>
    {
    }
    
    
    public static class FormCollectionExtender
    {
        public static PostData ProcessPostData(this FormCollection form, string prefix = "", params string[] excludeFields)
        {
            PostData result = new PostData();

            foreach (string key in form.Keys)
            {
                if (!string.IsNullOrEmpty(prefix) && !key.StartsWith(prefix))
                    continue;

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


        /// <summary>
        /// Designed to get checked checkboxes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static T[] GetArray<T>(this FormCollection form, string prefix)
        {
            string[] items = form.AllKeys.Where(k => k.StartsWith(prefix)).ToArray();
            List<T> res = new List<T>();
            foreach (string key in items)
            {
                if (form[key] == "true,false")
                    res.Add((T)Convert.ChangeType(key.Replace(prefix, string.Empty), typeof(T)));
            }
            T[] result = res.ToArray();
            return result;
        }

        public static Dictionary<TKey, TValue> GetDictionary<TKey, TValue>(this FormCollection form, string prefix)
        {
            string[] items = form.AllKeys.Where(k => k.StartsWith(prefix)).ToArray();
            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
            foreach (var key in items)
            {
                TKey dicKey = (TKey)Convert.ChangeType(key.Replace(prefix, string.Empty), typeof(TKey));
                TValue value = default(TValue);
                if (typeof(TValue) == typeof(bool))
                    value = (TValue)(object)(form[key] == "true,false");
                else
                    value = (TValue)Convert.ChangeType(form[key], typeof(TValue));
                result.Add(dicKey, value);
            }
            return result;
        }
    }


}
