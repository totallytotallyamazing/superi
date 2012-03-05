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
        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();
        private string[] _currentPathNames;
        private static PageManager _instance;

        public event Action<AddressChangeEventArgs> AddressChanged;

        public static PageManager Current { get { return _instance; } }

        public bool PreventChange
        {
            get { return _preventChange; }
            set { _preventChange = value; }
        }

        private bool _preventChange;

        public void Reset()
        {
            _currentPathNames = null;
        }

        public PageManager()
        {
            _pages[""] = typeof(StartPage);
            _pages["works"] = typeof(WorksPage);
            _pages["content"] = typeof(ContentPage);
        }

        public void Initialize()
        {
            Address.Make.Change(OnAddressChanged);
            ContentScroller.Enable();
            jQuery.Document.Click(delegate { jQuery.Select("a").Blur(); });
            _instance = this;
        }

        private void OnAddressChanged(ChangeOptions options)
        {
            AddressChangeEventArgs callbackArgs = new AddressChangeEventArgs();
            if (AddressChanged != null)
            {
                callbackArgs.Path = (string[])options.PathNames.Extract(1);
                AddressChanged(callbackArgs);
            }
            if (callbackArgs.PreventDefault)
            {
                return;
            }

            string a = options.PathNames[0] ?? string.Empty;
            jQuery.Select("#mainNav > *").FadeTo(Page.TransitionDuration, 0.5);
            jQuery.Select("[rel='address:/" + a + "'], [rel='address:" + options.Value + "']", Document.GetElementById("mainNav"))
                .FadeTo(Page.TransitionDuration, 1)
                .Parents("#logo")
                .FadeTo(Page.TransitionDuration, 1);

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