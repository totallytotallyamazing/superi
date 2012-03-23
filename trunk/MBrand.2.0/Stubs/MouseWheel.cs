// MouseWheel.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace jQueryApi.MouseWheel
{
    [GlobalMethods]
    public static class MouseWheel
    {
        [ScriptName("$")]
        public static MouseWheelObject Select(string selector) { return null; }
    }

    public class MouseWheelObject : jQueryObject
    {
        [ScriptName("mousewheel")]
        public MouseWheelObject MouseWheel(Action<jQueryEvent, int> handler)
        {
            return null;
        }
    }
}
