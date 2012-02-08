using System;
using System.Runtime.CompilerServices;


namespace jQueryApi.Address
{
    [Imported, ScriptName("Object")]
    public class ChangeOptions
    {
        [IntrinsicProperty]
        public string Value { get; set; }

        [IntrinsicProperty]
        public string Path { get; set; }

        [IntrinsicProperty]
        public string[] PathNames { get; set; }

        [IntrinsicProperty]
        public string[] ParameterNames { get; set; }

        [IntrinsicProperty]
        public string[] Parameters { get; set; }

        [IntrinsicProperty]
        public string[] QueryString { get; set; }
    }
}
