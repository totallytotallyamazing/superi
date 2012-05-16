using System.Runtime.CompilerServices;

namespace jQueryApi.Address
{
    public delegate void AddressChangeCallback(ChangeOptions options);

    [Imported, ScriptName("$"), IgnoreNamespace]
    public class Address
    {
        [IntrinsicProperty, ScriptName("address")]
        public static Address Make { get { return null; } }

        public Address Change(AddressChangeCallback callback) { return null; }

        public Address Init(AddressChangeCallback callback) { return null; }

        public Address InternalChange(AddressChangeCallback callback) { return null; }

        public Address ExternalChange(AddressChangeCallback callback) { return null; }

        public Address AutoUpdate(bool enable) { return null; }

        [ScriptName("crawlable")]
        public bool GetCrawlable() { return false; }

        public Address Crawlable(bool value) { return null; }
    }
}
