// SecretPage.cs
//

using jQueryApi;
using jQueryApi.JsRender;
using System.Runtime.CompilerServices;
using System;

namespace MBrand.Client.Pages
{
    public class SecretPage : Page
    {
        public override string Url
        {
            get { return "/Home/SecretLink"; }
        }

        public override string Name
        {
            get { return "SecretLink"; }
        }

        protected override void Initialize()
        {
            LoadData();
        }

        [PreserveCase]
        public static void LoadData()
        {
            jQuery.Get("/Home/SecretItems", delegate(object data)
            {
                jQuery.Select("#secretImages").Empty().Html(
                    JsRender.Select("#secretItemTemplate").Render(data));
            });
        }
    }
}
