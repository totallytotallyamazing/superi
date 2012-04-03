// WorkPage.cs
//

using System;
using System.Collections.Generic;
using jQueryApi.Address;

namespace MBrand.Client.Pages
{
    public class WorkPage : Page
    {
        public string WorkId
        {
            get { return (string)Path[0]; }
        }

        public override string Url
        {
            get { return "/Works/Show/" + WorkId; }
        }

        public override string Name
        {
            get { return "WorkPage"; }
        }

        protected override void Initialize()
        {
            PageManager.Current.AddressChanged += AddressChanged;
        }

        void AddressChanged(AddressChangeEventArgs args)
        {
            PageManager.Current.Reset();
        }

        public override void Dispose()
        {
            PageManager.Current.AddressChanged -= AddressChanged;
        }
    }
}
