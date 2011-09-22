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
        int currentTopImage = 0;
        const int imagesNumber = 2;

        public bool IsAuthenticated
        {
            get
            {
                Script.Literal("if(typeof(window.IsAuthenticated) !=='undefined' && IsAuthenticated)return true");
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
        void UpdateTopImage()
        {
            currentTopImage++;
            if (currentTopImage >= imagesNumber)
                currentTopImage = 0;
            JQueryProxy.jQuery("#header").css("background", "transparent url(/Content/topImages/top" + currentTopImage + ".jpg) no-repeat");
        }

        void CreateHistoryPoint(AnchorElement target, AjaxOptions options)
        {
            UpdateTopImage();
            Dictionary result = new Dictionary();
            result["url"] = target.GetAttribute("href");
            Application.AddHistoryPoint(result);
        }

        void RestoreSateFromHistory(Dictionary state)
        {
            IvokeUpdating();
            KillAsyncAnchors();
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

        void InitializeMenuAnchors()
        {
            DOMElement menuContainer = Document.GetElementById("menuContainer");
            DOMElementCollection menuAnchors = menuContainer.GetElementsByTagName("a");
            InitializeAsyncAnchors((Array)(object)menuAnchors);
        }

        void InitializePageAnchors()
        {
            Array anchors = Utils.GetElementsByAttribute(Document.GetElementById("content"), "a", "rel", "async", null);
            InitializeAsyncAnchors(anchors);
        }

        void InitializeAsyncAnchors(Array anchors)
        { 
            for (int i = 0; i < anchors.Length; i++)
            {
                AnchorElement anchor = (AnchorElement)anchors[i];
                DomEvent.AddHandler(anchor, "click", new DomEventHandler(MenuItemClicked));
            }

            AnchorElement logoLink = (AnchorElement)Document.GetElementById("logo").GetElementsByTagName("a")[0];
            DomEvent.AddHandler(logoLink, "click", new DomEventHandler(MenuItemClicked));
        }

        void KillAsyncAnchors()
        {
            Array anchors = Utils.GetElementsByAttribute(Document.GetElementById("content"), "a", "rel", "async", null);
            for (int i = 0; i < anchors.Length; i++)
            {
                AnchorElement anchor = (AnchorElement)anchors[i];
                DomEvent.ClearHandlers(anchor);
            }
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
            AttributeComparer comparer = new AttributeComparer(delegate(string a, string b)
                {
                    return (b.IndexOf(a) > -1 && b.IndexOf(a) < 1);
                });

            DOMElement target = (DOMElement)Utils.GetElementsByAttribute(Document.GetElementById("menuContainer"), "a", "href", url, comparer)[0];
            if (target != null)
                target = target.ParentNode;
            JQuery items = JQueryProxy.jQuery("#menuContainer div");
            if (target != null)
            {
                items = items.not(target);
                DomElement.AddCssClass(target, "current");
                DomElement.RemoveCssClass(target, "hover");
            }
            items.removeClass("current");
        }

        void CreatePageExtenders()
        {
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
            KillAsyncAnchors();
            
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
            Window.SetTimeout(InitializePageAnchors, 400);
        }

        public override void Initialize()
        {
            instanse = this;
            base.Initialize();
            Application.EnableHistory = true;
            Application.Navigate += new HistoryEventHandler(Application_Navigate);

            if (Window.Location.Href.IndexOf("#") > -1)
            {
                string url = Window.Location.Href.Replace(new RegularExpression("^.*#url="), "");
                Dictionary state = new Dictionary();
                state["url"] = url;
                RestoreSateFromHistory(state);
            }
        }

        private void InitializeMainMenu()
        {
            InitializeMenuAnchors();
            Array arr = (Array)(object)JQueryProxy.jQuery(".menuItem").not(".current");

            for (int i = 0; i < arr.Length; i++)
            {
                DivElement elem = (DivElement)arr[i];
                DomEvent.AddHandler(elem.GetElementsByTagName("a")[0], "mouseover", delegate(DomEvent e)
                {
                    if (e.Target.ClassName != "current")
                    {
                        DomElement.AddCssClass(e.Target.ParentNode, "hover");
                    }
                });

                DomEvent.AddHandler(elem.GetElementsByTagName("a")[0], "mouseout", delegate(DomEvent e)
                {
                    if (e.Target.ClassName != "current")
                    {
                        DomElement.RemoveCssClass(e.Target.ParentNode, "hover");
                    }
                });
            }
        }

        public void OnLoad()
        {
            InitializeMainMenu();
            InitializePageAnchors();
            InvokeUpdated();
        }
        #endregion
    }
}
