using System;
using Sys;

namespace ClientLibrary
{
    public class PhotoSessionExtender : PageExtender
    {
        protected override void ContentUpdated(object sender, EventArgs e)
        {
            Script.Literal("$('a.photoSession').fancybox();");
        }
    }
}
