using System;
using Jquery;

namespace ClientLibrary
{
    public class VideoExtender : PageExtender
    {
        protected override void ContentUpdated(object sender, Sys.EventArgs e)
        {
            base.ContentUpdated(sender, e);

            JQueryProxy.jQuery("#content").css("padding", "0");
        }

        protected override void ContentUpdating(object sender, Sys.EventArgs e)
        {
            JQueryProxy.jQuery("#content").css("padding", "");
            base.ContentUpdating(sender, e);
        }
    }
}
