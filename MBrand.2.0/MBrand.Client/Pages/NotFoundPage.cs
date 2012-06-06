// NotFoundPage.cs
//

using System;
using System.Collections.Generic;

namespace MBrand.Client.Pages
{
    public class NotFoundPage : Page
    {
        public override string Url
        {
            get { return "/Home/NotFound"; }
        }

        public override string Name
        {
            get { return "NotFoundPage"; }
        }

        protected override void Initialize()
        {
        }
    }
}
