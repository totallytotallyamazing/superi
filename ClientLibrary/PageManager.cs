// Class1.cs
//

using System;
using System.DHTML;
using Sys;
using Sys.UI;
using Sys.Mvc;

namespace ClientLibrary
{
    public class PageManager : Component
    {
        private static PageManager instanse;
        private bool linkNavigation = false;
        AsyncRequestHandler asyncRequestHandler = null;

        public static PageManager Current
        {
            get { return instanse; }
        }

        public PageManager() : base()
        {

        }

        public override void Initialize()
        {
            instanse = this;
            base.Initialize();
            Application.EnableHistory = true;

            Application.Navigate += new HistoryEventHandler(Application_Navigate);
            Application.Load += new ApplicationLoadEventHandler(Application_Load);
            
        }

        void Application_Load(object sender, ApplicationLoadEventArgs e)
        {
            InitializeAsyncAnchors();
        }

        void Application_Navigate(object sender, HistoryEventArgs e)
        {
            if (!linkNavigation)
            {
                RestoreSateFromHistory(e.State);
            }
        }

        void RestoreSateFromHistory(Dictionary state)
        {
            AjaxOptions options = new AjaxOptions();
            options.UpdateTargetId = "content";
            options.InsertionMode = InsertionMode.Replace;
            options.OnComplete = asyncRequestHandler;
            if (state["url"] != null)
            {
                string url = (string)state["url"];
                AsyncRequest(url, "post", "", null, options);
            }
            else
            {
                AsyncRequest("/Home/IndexContent", "post", "", null, options);
            }
        }

        public static void AsyncRequest(string url, string verb, string body, DOMElement triggerElement, Object ajaxOptions)
        {
            Script.Literal("Sys.Mvc.MvcHelpers.$1(url, verb, body, triggerElement, ajaxOptions)");
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

            AnchorElement logoLink = (AnchorElement)Document.GetElementById("logo").FirstChild;
            DomEvent.AddHandler(logoLink, "click", new DomEventHandler(MenuItemClicked));
        }

        void MenuItemClicked(DomEvent e)
        {
            AjaxOptions options = new AjaxOptions();
            options.UpdateTargetId = "content";
            options.InsertionMode = InsertionMode.Replace;
            if (asyncRequestHandler == null)
            {
                asyncRequestHandler =new AsyncRequestHandler(AsyncRequestCompleted); 
            }
            options.OnComplete = asyncRequestHandler;
            AnchorElement target = (e.Target.TagName == "A") ? (AnchorElement)e.Target : (AnchorElement)e.Target.ParentNode;
            linkNavigation = true;
            CreateHistoryPoint(target, options);

            AsyncHyperlink.HandleClick(target, e, options);
        }

        void CreateHistoryPoint(AnchorElement target, AjaxOptions options)
        {
            Dictionary result = new Dictionary();
            result["url"] = target.Href;
            Application.AddHistoryPoint(result);
        }

        public void AsyncRequestCompleted(AjaxContext param)
        {
            linkNavigation = false;
        }
    }
}
