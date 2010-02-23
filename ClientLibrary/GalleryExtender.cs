using System;
using System.DHTML;
using Sys;
using Sys.Serialization;
using Jquery;
using Sys.Mvc;

namespace ClientLibrary
{
    public class GalleryExtender : Component
    {
        EventHandler contentUpdating = null;
        EventHandler contentUpdated = null;

        private string serializedIdArray;

        public string SerializedIdArray
        {
            get { return serializedIdArray; }
            set { serializedIdArray = value; }
        }

        private int[] GalleryIds
        {
            get
            {
                if (SerializedIdArray != "")
                    return (int[])JavaScriptSerializer.Deserialize(SerializedIdArray);
                else
                    return null;
            }
        }

        public override void Initialize()
        {
            contentUpdating = new EventHandler(Current_ContentUpdating);
            contentUpdated = new EventHandler(Current_ContentUpdated);
            PageManager.Current.ContentUpdating += contentUpdating;
            PageManager.Current.ContentUpdated += contentUpdated;
        }

        void InitializeAdminArea()
        {
            if (PageManager.Current.IsAuthenticated)
            {
                FancyBoxOptions options = new FancyBoxOptions();
                options.Width = 200;
                options.Height = 150;
                options.HideOnContentClick = false;
                options.HideOnOverlayClick = false;
                options.AutoDimensions = false;
                options.AutoScale = false;
                options.Padding = 10;

                JQueryProxy.jQuery(".adminLink").Fancybox(options);

                JQueryProxy.jQuery(".adminConfirmLink").click(new BasicCallback(ConfirmClick));
            }
        }


        object ConfirmClick(object rawEvent, object stub)
        {
            Event evt = (Event)rawEvent;
            AnchorElement element = (AnchorElement)evt.SrcElement;
            if (Script.Confirm("Вы уверены?"))
            {
                AjaxOptions options = new AjaxOptions();
                options.OnSuccess = delegate(AjaxContext context)
                {
                    PageManager.Current.GoToUrl("/Gallery");
                };

                PageManager.AsyncRequest(element.Href, "GET", "", element, options);
            }
            evt.ReturnValue = false;
            Type.InvokeMethod(evt, "stopPropagation");
            return false;
        }

        void ClearAdminHandlers()
        {
            JQueryProxy.jQuery(".adminConfirmLink").unbind("click", null);
        }

        void Current_ContentUpdated(object sender, EventArgs e)
        {
            if (GalleryIds != null)
            {
                JQueryProxy.jQuery(".photoSession").Fancybox(null);
                int length = GalleryIds.Length;
                for (int i = 0; i < length; i++)
                {
                    string controlId = "#carousel_" + GalleryIds[i];
                    JQueryProxy.jQuery(controlId).Jcarousel(null);
                }
            }

            JQueryProxy.jQuery("#content").css("padding", "0");
            InitializeAdminArea();
        }

        void Current_ContentUpdating(object sender, EventArgs e)
        {
            PageManager.Current.ContentUpdated -= contentUpdated;
            PageManager.Current.ContentUpdating -= contentUpdating;
            JQueryProxy.jQuery("#content").css("padding", "");
            ClearAdminHandlers();
            this.Dispose();
        }

        public static void Update()
        {
            jQuery.Fancybox.Close();

            PageManager.Current.GoToUrl("/Gallery");
        }
    }
}
