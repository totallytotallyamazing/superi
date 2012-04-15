using System.Collections.Generic;
using System;
using jQueryApi;
using System.Collections;
using jQueryApi.jQueryUi;
using System.Html;

namespace MBrand.Client.Pages
{
    public abstract class Page : IDisposable
    {
        #region Constants
        public const int TransitionDuration = 500;
        #endregion

        #region Fields
        static readonly Dictionary<string, Page> PageCache = new Dictionary<string, Page>();
        AjaxRequestCallback<object> _loadedHandler;
        private Array _path = new Array();
        private static Page _current;
        private jQueryObject _container;
        #endregion

        #region Properties
        public static Page Current
        {
            get { return _current; }
        }

        public Array Path
        {
            get { return _path; }
        }
        #endregion

        #region Abstract members
        public abstract string Url { get; }
        public abstract string Name { get; }
        protected abstract void Initialize();
        #endregion

        #region Static Methods
        public static Page Create(Type page, string[] values)
        {
            string key = page.Name;
            Page result;
            if (!PageCache.ContainsKey(key))
            {
                result = (Page)Type.CreateInstance(page);
                PageCache[key] = result;
            }
            else
            {
                result = PageCache[key];
            }

            for (int i = 0; values != null && i < values.Length; i++)
            {
                result.Path[i] = values[i];
            }
            return result;
        }

        public static void ChangePage(Type page, string[] values)
        {
            Page pageInstance = Create(page, values);
            pageInstance._path = values;
            pageInstance = pageInstance.UpdateInstance();
            jQueryObject container = CreateContainer(pageInstance);
            pageInstance.LoadContent(container);
        }

        protected static jQueryObject CreateContainer(Page pageInstance)
        {
            Dictionary pageProperties = new Dictionary();
            pageProperties["id"] = pageInstance.Name;
            pageProperties["class"] = "commingIn content";
            return jQuery.FromHtml("<div>", pageProperties).AppendTo("#page");
        }
        #endregion

        #region Internal, private and protected methods
        internal void SetPath(string[] values)
        {
            BeforePathSet();
            _path = values;
            PathSet();
        }

        private void LoadContent(jQueryObject container)
        {
            _container = container;
            _loadedHandler = Loaded;
            _container.Load(Url, null, _loadedHandler);
        }

        private void Loaded(object data, string status, jQueryDataHttpRequest<object> request)
        {
            Initialize();
            jQueryUiObject oldObject = null;
            if (Current != null)
            {
                Type.InvokeMethod(_current, "beforeChange");
                oldObject = ((jQueryUiObject)jQuery.Select("#" + Current.Name));
            }
            else
            {
                jQuery.Select("#defaultContent").Remove();
            }
            _loadedHandler = null;
            if (_current != null)
            {
                _current.Dispose();
            }
            _current = this;

            PerformTransition(oldObject, _container);
        }

        protected void PerformTransition(jQueryObject oldObject, jQueryObject newObject)
        {
            if (oldObject != null)
            {
                Dictionary vanishProps = new Dictionary();
                vanishProps["opacity"] = 0;
                vanishProps["height"] = "toggle";
                vanishProps["minHeight"] = "toggle";
                try
                {
                    oldObject.Animate(vanishProps, TransitionDuration);
                }
                catch
                {
                    
                }
                Window.SetTimeout
                    (
                        delegate
                        {
                            oldObject.Remove();
                        },
                        TransitionDuration
                    );
            }

            Dictionary comeInProps = new Dictionary();
            comeInProps["opacity"] = 1;
            Document.Body.ScrollTop = 0;
            newObject.Animate(comeInProps, TransitionDuration);
            ContentScroller.GoToTop();
            Window.SetTimeout(TransitionComplete, TransitionDuration);
        }
        #endregion

        #region Virtual Methods
        protected virtual void TransitionComplete() { }

        protected virtual void BeforeChange() { }

        protected virtual void PathSet() { }

        protected virtual void BeforePathSet() { }
        #endregion

        public virtual void Dispose()
        {

        }

        public virtual Page UpdateInstance()
        {
            return this;
        }
    }

}
