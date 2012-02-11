// ScriptManager.cs
//

using System.Runtime.CompilerServices;
using jQueryApi;

namespace MBrand.Client
{
    [GlobalMethods]
    internal static class ScriptManager
    {
        static ScriptManager()
        {
            jQuery.OnDocumentReady(delegate
                                       {
                PageManager manager = new PageManager();
                manager.Initialize();
            });
        }
    }
}
