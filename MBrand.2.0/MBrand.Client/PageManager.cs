// PageManager.cs
//

using System;
using System.Collections.Generic;
using jQueryApi.Address;
using MBrand.Client.Pages;
using jQueryApi;

namespace MBrand.Client
{
    public class PageManager
    {
        Dictionary<string, Type> pages = new Dictionary<string, Type>();

        public PageManager()
        {
            pages["/"] = typeof(StartPage);
            pages["/contacts"] = typeof(ContactsPage);
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
            if (pages.ContainsKey(options.Value))
                Page.ChangePage(pages[options.Value]);
        }
    }
}
