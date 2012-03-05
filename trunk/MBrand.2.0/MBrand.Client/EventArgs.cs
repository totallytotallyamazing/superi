// EventArgs.cs
//

using System;
using System.Collections.Generic;

namespace MBrand.Client
{
    public class AddressChangeEventArgs
    {
        private bool _preventDefault;
        private string[] _path;

        public bool PreventDefault
        {
            get { return _preventDefault; }
            set { _preventDefault = value; }
        }

        public string[] Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}
