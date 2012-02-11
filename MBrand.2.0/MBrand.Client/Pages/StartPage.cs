// StartPage.cs
//

using jQueryApi.BxSlider;
using jQueryApi;
using System.Collections;
using System.Html;
using System;

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
            SliderOptions options = new SliderOptions();
            options.OnNextSlide = options.OnPrevSlide = delegate
                                                            {
                                                                jQuery.Select("a.bx-prev, a.bx-next").Blur();
                                                            };
            BxSlider.Select("#statements").BxSlider(options);
        }

        protected override void TransitionComplete()
        {
            base.TransitionComplete();
            Dictionary maxAnimation = new Dictionary();
            maxAnimation["opacity"] = 1;
            maxAnimation["right"] = 0;
            jQuery.Select("#maks").Animate(maxAnimation, TransitionDuration);
        }

        protected override void BeforeChange()
        {
            base.BeforeChange();
            jQuery.Select("#maks").Hide(0);
        }
    }
}
