// ScriptManager.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace MBrand.Client
{
    [GlobalMethods]
    internal static class ScriptManager
    {
        static ScriptManager()
        {
            jQuery.OnDocumentReady(delegate()
            {
                PageManager manager = new PageManager();
                manager.Initialize();
            });
        }
    }
}
