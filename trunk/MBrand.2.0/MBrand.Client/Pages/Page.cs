using System.Collections.Generic;
using System;
using jQueryApi;
using System.Collections;
using jQueryApi.jQueryUi;
using System.Html;

namespace MBrand.Client.Pages
{
    public abstract class Page
    {
        const int _transitionDuration = 500;

        static Dictionary<string, Page> pageCache = new Dictionary<string, Page>();
        AjaxRequestCallback<object> _loadedHandler;
        private static Page _current;

        public static Page Current
        {
            get { return _current; }
        }

        private jQueryObject _container;

        public abstract string Url { get; }
        public abstract string Name { get; }

        public static Page Create(Type page)
        {
            string key = page.Name;
            Page result = null;
            if (!pageCache.ContainsKey(key))
            {
                result = (Page)Type.CreateInstance(page);
                pageCache[key] = result;
            }
            else
                result = pageCache[key];
            return result;
        }

        public static void ChangePage(Type page)
        {
            Page pageInstance = (Page)Create(page);
            Dictionary pageProperties = new Dictionary();
            pageProperties["id"] = pageInstance.Name;
            pageProperties["class"] = "commingIn";
            jQueryObject container = jQuery.FromHtml("<div>", pageProperties).AppendTo("#page");
            pageInstance.LoadContent(container);
        }

        private void LoadContent(jQueryObject container)
        {
            _container = container;
            _loadedHandler = new AjaxRequestCallback<object>(Loaded);
            _container.Load(Url, null, _loadedHandler);
        }

        private void Loaded(object data, string status, jQueryDataHttpRequest<object> request)
        {
            if (Current != null)
            {
                jQueryUiObject oldObject = ((jQueryUiObject)jQuery.Select("#" + Current.Name));
                oldObject.SwitchClass("currentPage", "commingOut", _transitionDuration);
                Window.SetTimeout
                    (
                        delegate() { oldObject.Remove(); }, _transitionDuration
                    );
            }
            else
            {
                jQuery.Select("#defaultContent").Remove();
            }
            _loadedHandler = null;
            _current = this;
            ((jQueryUiObject)_container).SwitchClass("commingIn", "currentPage", _transitionDuration);
        }
    }

}
