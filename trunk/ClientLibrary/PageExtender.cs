using System;
using Sys;

namespace ClientLibrary
{
    public abstract class PageExtender : Component
    {
        EventHandler contentUpdating = null;
        EventHandler contentUpdated = null;

        public override void Initialize()
        {
            contentUpdating = new EventHandler(ContentUpdating);
            contentUpdated = new EventHandler(ContentUpdated);
            PageManager.Current.ContentUpdating += contentUpdating;
            PageManager.Current.ContentUpdated += contentUpdated;
        }

        protected virtual void ContentUpdated(object sender, EventArgs e)
        {
        }

        protected virtual void ContentUpdating(object sender, EventArgs e)
        {
            PageManager.Current.ContentUpdated -= contentUpdated;
            PageManager.Current.ContentUpdating -= contentUpdating;
        }
    }
}
