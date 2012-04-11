// jQueryUi.cs
//

using System.Html;
using jQueryApi;
using System.Runtime.CompilerServices;

namespace jQueryApi.jQueryUi
{
    [GlobalMethods]
    public static class jQueryUi
    {
        [ScriptName("$")]
        public static jQueryUiObject Select(string selector) { return null; }

        [AlternateSignature]
        public static jQueryUiObject Select(string selector, Element context) { return null; }
    }

    public class jQueryUiObject : jQueryObject
    {
        public jQueryUiObject SwitchClass(string from, string to, int duration) { return null; }

        [AlternateSignature]
        public jQueryUiObject SwitchClass(string from, string to, string speed) { return null; }

        [AlternateSignature]
        public jQueryUiObject SwitchClass(string from, string to) { return null; }

        public jQueryUiObject AddClass(string className, int duration) { return null; }

        [AlternateSignature]
        public jQueryUiObject AddClass(string className, string speed) { return null; }

        [AlternateSignature]
        public jQueryUiObject AddClass(string className) { return null; }

        public jQueryUiObject RemoveClass(string className, int duration) { return null; }
                              
        [AlternateSignature]  
        public jQueryUiObject RemoveClass(string className, string speed) { return null; }
                              
        [AlternateSignature]  
        public jQueryUiObject RemoveClass(string className) { return null; }
    }
}

