// JsRender.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace jQueryApi.JsRender
{
    [GlobalMethods]
    public static class JsRender
    {
        [ScriptName("$")]
        public static jQueryJsRenderObject Select(string selector) { return null; }
    }

    [Imported]
    [IgnoreNamespace]
    public sealed class jQueryJsRenderObject : jQueryObject
    {
        public string Render(object data)
        {
            return null;
        }
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("$.views")]
    public sealed class jQueryJsViewObject
    {
        [IntrinsicProperty]
        public static bool AllowCode { get; set; }

        public static void RegisterTags(string key, Delegate callBack)
        {
        }
    }

}
