using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trips.Web.Models;

namespace Trips.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string res = Resources.WebResources.LanguageSwitch;

            using (CarAdStorage context = new CarAdStorage())
            {
            
            }
        }
    }
}
