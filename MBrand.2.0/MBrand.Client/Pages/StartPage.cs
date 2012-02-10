// StartPage.cs
//

using System;
using System.Collections.Generic;
using jQueryApi.BxSlider;
using jQueryApi;
using System.Collections;
using System.Html;

namespace MBrand.Client.Pages
{
    public class StartPage : Page
    {
        public override string Url
        {
            get { return "/Home/Start"; }
        }

        public override string Name
        {
            get { return "StartPage"; }
        }

        protected override void Initialize()
        {
            BxSlider.Select("#statements").BxSlider();
        }

        protected override void TransitionComplete()
        {
            base.TransitionComplete();
            Dictionary maxAnimation = new Dictionary();
            maxAnimation["opacity"] = 1;
            maxAnimation["right"] = 0;
            jQuery.Select("#maks").Animate(maxAnimation, Page.TransitionDuration);
        }

        protected override void BeforeChange()
        {
            base.BeforeChange();
            jQuery.Select("#maks").Hide(0);
        }
    }
}
