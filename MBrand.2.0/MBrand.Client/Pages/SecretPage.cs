// SecretPage.cs
//

using jQueryApi;
using jQueryApi.JsRender;
using System.Runtime.CompilerServices;
using System;
using System.Html;

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
                BindAdminLinks();
            });
        }

        private static void BindAdminLinks()
        {
            jQuery.Select(".secretItem a.adminLink").Click(delegate(jQueryEvent e)
                                                           {
                                                               if (Script.Confirm("Are you sure?"))
                                                               {
                                                                   jQuery.Post(((AnchorElement) e.CurrentTarget).Href,
                                                                               delegate {
                                                                                            LoadData();
                                                                               });
                                                               }
                                                               e.PreventDefault();
                                                           });
        }
    }
}
