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
            Script.Alert(this.ID);
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
            e.PreventDefault();
            AjaxOptions options = new AjaxOptions();
            options.OnComplete = new AsyncRequestHandler(AsyncRequestCompleted);
            AsyncHyperlink.HandleClick((AnchorElement)e.Target, e, options);
            
        }

        public void AsyncRequestCompleted(AjaxContext param)
        {
            
        }
    }
}
