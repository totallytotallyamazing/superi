// jQueryUi.cs
//

using jQueryApi;
using System.Runtime.CompilerServices;

namespace jQueryApi.jQueryUi
{
    public class jQueryUiObject : jQueryObject
    {
        public jQueryUiObject SwitchClass(string from, string to, int duration) { return null; }

        [AlternateSignature]
        public jQueryUiObject SwitchClass(string from, string to, string speed) { return null; }

        [AlternateSignature]
        public jQueryUiObject SwitchClass(string from, string to) { return null; }
    }
}

