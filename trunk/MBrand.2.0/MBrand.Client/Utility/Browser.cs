// Browser.cs
//

using System;
using System.Collections.Generic;
using System.Html;

namespace MBrand.Client.Utility
{
    public static class Browser
    {
        public static bool IsFirefox { get { return Window.Navigator.UserAgent.IndexOf("Firefox") > -1; }}

        public static bool IsIpad { get { return Window.Navigator.UserAgent.IndexOf("iPad") > -1; } }

        public static bool IsIphone { get { return Window.Navigator.UserAgent.IndexOf("iPhone") > -1; } }
    }
}
