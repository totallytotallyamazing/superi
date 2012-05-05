// ScriptManager.cs
//

using System.Runtime.CompilerServices;
using jQueryApi;
using System.Html;

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
                                           Socials.Bind();

                                           jQuery.Select("#logo").Click(delegate
                                                                        {
                                                                            if(Window.Location.Hash.Length>1)
                                                                            {
                                                                                Window.Location.Href = "/";
                                                                            }
                                                                        });
                                       });
        }
    }
}
