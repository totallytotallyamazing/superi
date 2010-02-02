using System;
using Sys;

namespace ClientLibrary
{
    public class PhotoSessionExtender : Component
    {
        EventHandler contentUpdating = null;
        EventHandler contentUpdated = null;

        public override void Initialize()
        {
            contentUpdating = new EventHandler(Current_ContentUpdating);
            contentUpdated = new EventHandler(Current_ContentUpdated); ;
            PageManager.Current.ContentUpdating += contentUpdating;
            PageManager.Current.ContentUpdated += contentUpdated;
        }

        void Current_ContentUpdated(object sender, EventArgs e)
        {
            Script.Literal("$('a.photoSession').fancybox();");
        }

        void Current_ContentUpdating(object sender, EventArgs e)
        {
            PageManager.Current.ContentUpdated -= contentUpdated;
            PageManager.Current.ContentUpdating -= contentUpdating;
            this.Dispose();
        }
    }
}
