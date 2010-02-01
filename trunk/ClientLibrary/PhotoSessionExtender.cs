using System;
using Sys;

namespace ClientLibrary
{
    public class PhotoSessionExtender : Component
    {
        EventHandler updating = null;
        EventHandler updated = null;

        public override void Initialize()
        {
            base.Initialize();
            updating = new EventHandler(Current_ContentUpdating);
            updated = new EventHandler(Current_ContentUpdated);;
            PageManager.Current.ContentUpdating += updating;
            PageManager.Current.ContentUpdated += updated;
        }

        void Current_ContentUpdated(object sender, EventArgs e)
        {
            Script.Alert("updated");
            Script.Literal("$('a.photoSession').fancybox();");
        }

        void Current_ContentUpdating(object sender, EventArgs e)
        {
            PageManager.Current.ContentUpdated -= updated;
            PageManager.Current.ContentUpdating -= updating;
            this.Dispose();
        }
    }
}
