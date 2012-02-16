using System;
using System.Collections.Generic;

namespace MBrand.Client.Pages
{
    public class ContentPage : Page
    {
        public override string Url
        {
            get { return "/Content/" + Path[0]; }
        }

        public override string Name
        {
            get { return "ContentPage" + Path[0]; }
        }


        protected override void Initialize()
        {
            
        }
    }
}
