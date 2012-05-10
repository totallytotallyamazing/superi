using System;
using System.Collections.Generic;
using MBrand.Client.Utility;
using jQueryApi;

namespace MBrand.Client.Pages
{
    public class ContentPage : Page
    {
        private jQueryObject _oldObject = null;

        public override string Url
        {
            get { return "/Content/Get/" + Path[0]; }
        }

        public override string Name
        {
            get { return "ContentPage" + Path[0]; }
        }

        protected override void Initialize()
        {
            
        }

        protected override void PathSet()
        {
            base.PathSet();
            jQueryObject container = CreateContainer(this);
            container.Load(Url, null, delegate(object data, string status, jQueryDataHttpRequest<object> request)
            {
                PerformTransition(_oldObject, container);                                              
            });
        }

        protected override void BeforePathSet()
        {
            _oldObject = jQuery.Select("#" + Name);
            base.BeforePathSet();
        }
    }
}