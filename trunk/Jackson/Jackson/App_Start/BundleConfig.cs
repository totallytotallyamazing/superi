using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Jackson
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                "~/Scripts/jquery.jeditable.mini.js",
                "~/Scripts/jquery.ui.widget.js",
                "~/Scripts/jquery.ui.core.js",
                "~/Scripts/jquery.ui.mouse.js",
                "~/Scripts/jquery.ui.sortable.js",
                "~/Scripts/FileUpload/jquery.iframe-transport.js",
                "~/Scripts/FileUpload/jquery.fileupload.js",
                "~/Scripts/admin.js"
                ));
        }
    }
}