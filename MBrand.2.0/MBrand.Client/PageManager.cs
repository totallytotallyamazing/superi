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
            jQuery.Select("#mainNav > *").FadeTo(Page.TransitionDuration, 0.5);
            jQuery.Select("[rel='address:" + options.Value + "']", Document.GetElementById("mainNav"))
                .FadeTo(Page.TransitionDuration, 1)
                .Parents("#logo")
                .FadeTo(Page.TransitionDuration, 1);
            if (pages.ContainsKey(options.Value))
                Page.ChangePage(pages[options.Value]);
        }
    }
}
