using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Zamov.Helpers
{
    public static class HierarchicalDropDownHelper
    {
        public static string HierarchicalDropDown<T>(this HtmlHelper html, string name, IEnumerable<T> rootItems, Func<T, IEnumerable<T>> childrenProperty, Func<T, string> itemText, Func<T, string> itemValue, object htmlAttributes)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in rootItems)
            {
                items.Add(new SelectListItem { Text = itemText(item), Value = itemValue(item) });
                AppendChildren(items, item, childrenProperty, itemText, itemValue, 1);
            }
            return html.DropDownList(name, items, htmlAttributes);
        }
        
        private static void AppendChildren<T>(List<SelectListItem> items, T root, Func<T, IEnumerable<T>> childrenProperty, Func<T, string> itemText, Func<T, string> itemValue, int level)
        {
            var children = childrenProperty(root);
            foreach (T item in children)
            {
                items.Add(new SelectListItem { Text = GetPrefix(level) + itemText(item), Value = itemValue(item) });
                AppendChildren(items, item, childrenProperty, itemText, itemValue, level + 1);
            }
        }

        static string GetPrefix(int level)
        {
            string result = "";
            for (int i = 0; i < level; i++)
            {
                result += "--";
            }
            return result;
        }
    }


}
