using System;
using Sys;
using Sys.Serialization;
using Jquery;

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
            contentUpdated = new EventHandler(Current_ContentUpdated); ;
            PageManager.Current.ContentUpdating += contentUpdating;
            PageManager.Current.ContentUpdated += contentUpdated;
        }

        void InitializeAdminArea()
        {
            if (PageManager.Current.IsAuthenticated)
            {
                FancyBoxOptions options = new FancyBoxOptions();
                options.Width = 150;
                options.Height = 100;
                options.HideOnContentClick = false;
                options.HideOnOverlayClick = false;
                options.AutoDimensions = false;
                options.AutoScale = false;
                options.Padding = 10;
                JQueryProxy.jQuery(".adminLink").Fancybox(options);
            }
        }

        void Current_ContentUpdated(object sender, EventArgs e)
        {
            if (GalleryIds != null)
            {
                int length = GalleryIds.Length;
                for (int i = 0; i < length; i++)
                {
                    string controlId = "carousel_" + GalleryIds[i];
                    JQueryProxy.jQuery(controlId).Jcarousel(null);
                }
            }
            InitializeAdminArea();
        }

        void Current_ContentUpdating(object sender, EventArgs e)
        {
            PageManager.Current.ContentUpdated -= contentUpdated;
            PageManager.Current.ContentUpdating -= contentUpdating;
            this.Dispose();
        }
    }
}
