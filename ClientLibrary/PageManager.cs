// Class1.cs
//

using System;
using System.DHTML;
using Sys;
using Sys.UI;
using Sys.Mvc;
using Jquery;

namespace ClientLibrary
{
    public class PageManager : Component, ILoadableComponent
    {
        private static PageManager instanse;
        private bool linkNavigation = false;
        AsyncRequestHandler asyncRequestHandler = null;

        public bool IsAuthenticated
        {
            get
            {
                Script.Literal("if(IsAuthenticated)return true");
                return false;
            }
        }

        public static PageManager Current
        {
            get { return instanse; }
        }


        #region Events
        public event EventHandler ContentUpdated
        {
            add { this.Events.AddHandler("contentUpdated", value); }
            remove { this.Events.RemoveHandler("contentUpdated", value); }
        }

        public event EventHandler ContentUpdating
        {
            add { this.Events.AddHandler("contentUpdating", value); }
            remove { this.Events.RemoveHandler("contentUpdating", value); }
        }
        #endregion


        public PageManager()
            : base()
        {
        }

        public void GoToUrl(string url)
        {
            Dictionary state = new Dictionary();
            state["url"] = url;
            RestoreSateFromHistory(state);
        }

        public static void AsyncRequest(string url, string verb, string body, DOMElement triggerElement, Object ajaxOptions)
        {
            Script.Literal("Sys.Mvc.MvcHelpers.$1(url, verb, body, triggerElement, ajaxOptions)");
        }

        #region Private Methods
        void CreateHistoryPoint(AnchorElement target, AjaxOptions options)
        {
            Dictionary result = new Dictionary();
            result["url"] = target.GetAttribute("href");
            Application.AddHistoryPoint(result);
        }

        void RestoreSateFromHistory(Dictionary state)
        {
            IvokeUpdating();
            AjaxOptions options = new AjaxOptions();
            options.UpdateTargetId = "content";
            options.InsertionMode = InsertionMode.Replace;
            if (asyncRequestHandler == null)
            {
                asyncRequestHandler = new AsyncRequestHandler(AsyncRequestCompleted);
            }
            options.OnComplete = asyncRequestHandler;
            if (state["url"] != null)
            {
                string url = (string)state["url"];
                AsyncRequest(url, "post", "", null, options);
                UpdateMenuSelection(url);
            }
            else
            {
                AsyncRequest("/Home/IndexContent", "post", "", null, options);
                UpdateMenuSelection("*");
            }
        }

        void InitializeAsyncAnchors()
        {
            DOMElement menuContainer = Document.GetElementById("menuContainer");
            DOMElementCollection anchors = menuContainer.GetElementsByTagName("a");
            for (int i = 0; i < anchors.Length; i++)
            {
                AnchorElement anchor = (AnchorElement)anchors[i];
                DomEvent.AddHandler(anchor, "click", new DomEventHandler(MenuItemClicked));
            }

            AnchorElement logoLink = (AnchorElement)Document.GetElementById("logo").GetElementsByTagName("a")[0];
            DomEvent.AddHandler(logoLink, "click", new DomEventHandler(MenuItemClicked));
        }

        void IvokeUpdating()
        {
            EventHandler handler = (EventHandler)this.Events.GetHandler("contentUpdating");
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

        }

        void InvokeUpdated()
        {
            EventHandler handler = (EventHandler)this.Events.GetHandler("contentUpdated");
            if (handler != null)
                handler(this, new EventArgs());
        }

        void UpdateMenuSelection(string url)
        {
            DOMElement target = (DOMElement)Utils.GetElementsByAttribute(Document.GetElementById("menuContainer"), "a", "href", url, null)[0];
            if (target != null)
                target = target.ParentNode;
            JQuery items = JQueryProxy.jQuery("#menuContainer div");
            if (target != null)
            {
                items = items.not(target);
                DomElement.AddCssClass(target, "current");
            }
            items.removeClass("current");
        }

        void CreatePageExtenders()
        {
            //Array scripts = Utils.GetElementsByAttribute(null, "script", "rel", "pageExtender", null);
            DOMElementCollection scripts = Document.GetElementById("content").GetElementsByTagName("script");
            for (int i = 0; i < scripts.Length; i++)
            {
                ScriptElement script = (ScriptElement)scripts[i];
                if (script != null)
                {
                    Script.Eval(script.InnerHTML);
                    if (script.GetAttribute("src") != null)
                    {
                        ScriptElement newScript = (ScriptElement)Document.CreateElement("script");
                        newScript.Type = "text/javascript";
                        newScript.Src = (string)script.GetAttribute("src");
                        Document.GetElementById("content").AppendChild(newScript);
                    }
                }
            }
        }
        #endregion

        #region EventHandlers
        void Application_Navigate(object sender, HistoryEventArgs e)
        {
            if (!linkNavigation)
            {
                RestoreSateFromHistory(e.State);
            }
        }
       
        void MenuItemClicked(DomEvent e)
        {
            IvokeUpdating();

            AjaxOptions options = new AjaxOptions();
            options.UpdateTargetId = "content";
            options.InsertionMode = InsertionMode.Replace;
            if (asyncRequestHandler == null)
            {
                asyncRequestHandler = new AsyncRequestHandler(AsyncRequestCompleted);
            }
            options.OnComplete = asyncRequestHandler;
            AnchorElement target = (e.Target.TagName == "A") ? (AnchorElement)e.Target : (AnchorElement)e.Target.ParentNode;
            string url = (string)target.GetAttribute("href");
            UpdateMenuSelection(url);
            linkNavigation = true;
            CreateHistoryPoint(target, options);
            AsyncHyperlink.HandleClick(target, e, options);
        }

        public void AsyncRequestCompleted(AjaxContext param)
        {
            linkNavigation = false;
            Window.SetTimeout(CreatePageExtenders, 200);
            Window.SetTimeout(InvokeUpdated, 400);
        }

        public override void Initialize()
        {
            instanse = this;
            base.Initialize();
            Application.EnableHistory = true;
            Application.Navigate += new HistoryEventHandler(Application_Navigate);

        }


        public void OnLoad()
        {
            InitializeAsyncAnchors();
            InvokeUpdated();
        }
        #endregion
    }
}
