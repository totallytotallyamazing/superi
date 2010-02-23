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

    [Imported]
    public class FancyBoxGlobals
    {
        public void ShowActivity(){}

        public void HideActivity(){}

        public void Next(){}

        public void Prev(){}

        public void Pos(int pos){}

        public void Canel(){}

        public void Close(){}

        public void Resize(){}

        public void Center() { }
    }

    public partial class JQuery
    {
        public JQuery Fancybox(FancyBoxOptions options)
        {
            return null;
        }
    }

    [Imported]
    [IgnoreNamespace]
    public static class jQuery
    {
        public static FancyBoxGlobals Fancybox;
    }
}
