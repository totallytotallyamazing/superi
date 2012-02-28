// WorkPage.cs
//

using System;
using System.Collections.Generic;

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
            get { return "WorkPage" + Path[0]; }
        }

        protected override void Initialize()
        {
            
        }
    }
}
