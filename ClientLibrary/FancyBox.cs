using System;

namespace Jquery
{
    public class FancyBoxOptions
    {
        public object Padding;
        public object Margin;
        public object Width;
        public object Height;
        public bool Opacity;
        public bool Modal;
        public bool Cyclic;
        public bool AutoScale = true;
        public bool AutoDimensions = true;
        public bool CenterOnScroll;
        public bool HideOnOverlayClick = true;
        public bool HideOnContentClick = true;
        public bool OverlayShow = true;
        public double OverlayOpacity = 0.3;
        public string OverlayColor;
        public string Scrolling;
    }

    public partial class JQuery
    {
        public JQuery Fancybox(FancyBoxOptions options)
        {
            return null;
        }
    }
}
