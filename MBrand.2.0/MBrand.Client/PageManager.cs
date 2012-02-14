// PageManager.cs
//

using System;
using System.Collections.Generic;
using jQueryApi.Address;
using MBrand.Client.Pages;
using jQueryApi;
using System.Html;

namespace MBrand.Client
{
    public class PageManager
    {
        private Dictionary<string, Type> _pages = new Dictionary<string, Type>();
        private string[] _currentPathNames;

        public PageManager()
        {
            _pages[""] = typeof (StartPage);
            _pages["contacts"] = typeof (ContactsPage);
            _pages["works"] = typeof (WorksPage);
        }

        public void Initialize()
        {
            Address.Make.Change(AddressChanged);
            ContentScroller.Enable();
            jQuery.Document.Click(delegate
                                      {
                                          jQuery.Select("a").Blur();
                                      });
        }

        private void AddressChanged(ChangeOptions options)
        {
            jQuery.Select("#mainNav > *").FadeTo(Page.TransitionDuration, 0.5);
            jQuery.Select("[rel='address:" + options.Value + "']", Document.GetElementById("mainNav"))
                .FadeTo(Page.TransitionDuration, 1)
                .Parents("#logo")
                .FadeTo(Page.TransitionDuration, 1);
            string a = options.PathNames[0] ?? string.Empty;
            if (_pages.ContainsKey(a))
            {
                int depth = GetPathDifferenceDepth(_currentPathNames, options.PathNames);
                if (depth < 1)
                    Page.ChangePage(_pages[a], (string[])options.PathNames.Extract(1));
                else
                    Page.Current.SetPath((string[])options.PathNames.Extract(1));
                _currentPathNames = options.PathNames;
            }
        }

        private static int GetPathDifferenceDepth(string[] pathNamesA, string[] pathNamesB)
        {
            if (pathNamesA == null || pathNamesB == null)
                return 0;
            int count = (pathNamesA.Length > pathNamesB.Length) ? pathNamesA.Length : pathNamesB.Length;
            for (int i = 0; i < count; i++)
            {
                if (pathNamesA[i] != pathNamesB[i])
                    return i;
            }
            return -1;
        }
    }
}
