﻿using System;
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
            //Script.Literal("debugger");
            contentUpdating = new EventHandler(Current_ContentUpdating);
            contentUpdated = new EventHandler(Current_ContentUpdated); ;
            PageManager.Current.ContentUpdating += contentUpdating;
            PageManager.Current.ContentUpdated += contentUpdated;
        }

        void Current_ContentUpdated(object sender, EventArgs e)
        {
            Script.Alert("updated");
            //Script.Literal("debugger");
            if (GalleryIds != null)
            {
                int length = GalleryIds.Length;
                for (int i = 0; i < length; i++)
                {
                    string controlId = "carousel_" + GalleryIds[i];
                    JQueryProxy.jQuery(controlId).Jcarousel(null);
                }
            }
        }

        void Current_ContentUpdating(object sender, EventArgs e)
        {
            PageManager.Current.ContentUpdated -= contentUpdated;
            PageManager.Current.ContentUpdating -= contentUpdating;
            this.Dispose();
        }
    }
}