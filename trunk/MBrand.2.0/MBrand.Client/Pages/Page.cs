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
        public const int TransitionDuration = 500;

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

        #region Static Methods
        public static Page Create(Type page)
        {
            string key = page.Name;
            Page result;
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
            Page pageInstance = Create(page);
            Dictionary pageProperties = new Dictionary();
            pageProperties["id"] = pageInstance.Name;
            pageProperties["class"] = "commingIn content";
            jQueryObject container = jQuery.FromHtml("<div>", pageProperties).AppendTo("#page");
            pageInstance.LoadContent(container);
        }

        #endregion

        private void LoadContent(jQueryObject container)
        {
            _container = container;
            _loadedHandler = Loaded;
            _container.Load(Url, null, _loadedHandler);
        }

        private void Loaded(object data, string status, jQueryDataHttpRequest<object> request)
        {
            Initialize();
            if (Current != null)
            {
                Type.InvokeMethod(_current, "beforeChange");
                jQueryUiObject oldObject = ((jQueryUiObject)jQuery.Select("#" + Current.Name));
                Dictionary vanishProps = new Dictionary();
                vanishProps["opacity"] = 0;
                vanishProps["height"] = "toggle";
                vanishProps["minHeight"] = "toggle";
                oldObject.Animate(vanishProps, TransitionDuration);
                Window.SetTimeout
                    (
                        delegate {
                            oldObject.Remove(); 
                        }, 
                        TransitionDuration
                    );
            }
            else
            {
                jQuery.Select("#defaultContent").Remove();
            }
            _loadedHandler = null;
            _current = this;
            Dictionary comeInProps = new Dictionary();
            comeInProps["opacity"] = 1;
            _container.Animate(comeInProps, TransitionDuration);
            Window.SetTimeout(TransitionComplete, TransitionDuration);
        }

        protected abstract void Initialize();

        protected virtual void TransitionComplete() { }

        protected virtual void BeforeChange() { }
    }

}
