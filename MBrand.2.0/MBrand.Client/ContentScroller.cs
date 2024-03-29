// ContentScroller.cs
//

using System;
using jQueryApi;
using System.Html;
using jQueryApi.MouseWheel;

namespace MBrand.Client
{
    [Flags]
    enum ScrollDirection
    {
        None = 0,
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8
    }

    public class ScrollerOptions
    {
        public bool MouseScrollHorizontally = true;
        public bool MouseScrollVertically = true;
        public bool WheelScroll = true;
    }

    public delegate void ScrollCallback();

    public class ContentScroller
    {
        const int ScrollSpeed = 100;
        const int ScrollStep = 3;
        const int IntervalsQuantity = 20;
        const int ScrollMargin = 100;

        ScrollDirection _scrollDirection = ScrollDirection.None;
        static Array _topIntervals = new Array();
        static Array _rightIntervals = new Array();
        static Array _bottomIntervals = new Array();
        static Array _leftIntervals = new Array();

        private ScrollerOptions options;

        public static void Enable(ScrollerOptions options)
        {
            if (options == null)
            {
                options = new ScrollerOptions();
            }


            if (options.WheelScroll)
            {
                MouseWheel.Select("body").MouseWheel(delegate(jQueryEvent e, int delta)
                                                     {
                                                         Document.Body.ScrollTop -= delta * 40;
                                                     });
            }
            if (options.MouseScrollHorizontally || options.MouseScrollVertically)
            {
                ContentScroller scroller = new ContentScroller();
                scroller.options = options;
                scroller.Attach();
            }
        }

        protected void Attach()
        {
            jQuery.Document.MouseMove(MouseMove);
        }

        private void MouseMove(jQueryEvent e)
        {
            ScrollDirection scrollDirection = GetScrollDirection(e.ClientX, e.ClientY);

            if (scrollDirection == ScrollDirection.None || scrollDirection != _scrollDirection)
            {
                ClearIntervals();
                _scrollDirection = ScrollDirection.None;
            }
            StartScrolling(scrollDirection);
            _scrollDirection = scrollDirection;
        }

        private ScrollDirection GetScrollDirection(int x, int y)
        {
            int bodyScrollLeft = jQuery.Select("body").GetScrollLeft();
            int bodyScrollTop = jQuery.Select("body").GetScrollTop();

            ScrollDirection result = ScrollDirection.None;
            if (x < ScrollMargin && bodyScrollLeft > 0)
                result = ScrollDirection.Left;
            if (y < ScrollMargin && bodyScrollTop > 0)
                result |= ScrollDirection.Top;
            if (result != ScrollDirection.None)
                return result;

            int height = jQuery.FromElement(Document.Body).GetHeight();
            int width = jQuery.FromElement(Document.Body).GetWidth();

            if (x > width - ScrollMargin && bodyScrollLeft < Document.Body.ScrollWidth)
                result = ScrollDirection.Right;
            if (y > height - ScrollMargin && bodyScrollTop < Document.Body.ScrollHeight)
                result |= ScrollDirection.Bottom;

            return result;
        }

        private void StartScrolling(ScrollDirection scrollDirection)
        {
            if (scrollDirection == ScrollDirection.None)
                return;
            if (options.MouseScrollVertically && (scrollDirection & ScrollDirection.Top) == ScrollDirection.Top)
            {
                if (Document.Body.ScrollTop == 0)
                {
                    _scrollDirection = ScrollDirection.None;
                    ClearInterval(_topIntervals);
                }
                else if ((_scrollDirection & ScrollDirection.Top) != ScrollDirection.Top)
                    SetInterval(delegate
                                {
                                    Document.Body.ScrollTop -= ScrollStep;
                                }, _topIntervals);
            }
            if (options.MouseScrollHorizontally && (scrollDirection & ScrollDirection.Right) == ScrollDirection.Right)
            {
                if (Document.Body.ScrollLeft == Document.Body.ScrollWidth)
                {
                    _scrollDirection = ScrollDirection.None;
                    ClearInterval(_rightIntervals);
                }
                else if ((_scrollDirection & ScrollDirection.Right) != ScrollDirection.Right)
                    SetInterval(delegate
                    {
                        Document.Body.ScrollLeft += ScrollStep;
                    }, _rightIntervals);
            }
            if (options.MouseScrollVertically && (scrollDirection & ScrollDirection.Bottom) == ScrollDirection.Bottom)
            {
                if (Document.Body.ScrollTop == Document.Body.ScrollHeight)
                {
                    _scrollDirection = ScrollDirection.None;
                    ClearInterval(_bottomIntervals);
                }
                else if ((_scrollDirection & ScrollDirection.Bottom) != ScrollDirection.Bottom)
                    SetInterval(delegate
                    {
                        Document.Body.ScrollTop += ScrollStep;
                    }, _bottomIntervals);
            }
            if (options.MouseScrollHorizontally && (scrollDirection & ScrollDirection.Left) == ScrollDirection.Left)
            {
                if (Document.Body.ScrollLeft == 0)
                {
                    _scrollDirection = ScrollDirection.None;
                    ClearInterval(_leftIntervals);
                }
                else if ((_scrollDirection & ScrollDirection.Left) != ScrollDirection.Left)
                    SetInterval(delegate
                    {
                        Document.Body.ScrollLeft -= ScrollStep;
                    }, _leftIntervals);
            }
        }

        private void SetInterval(Callback callback, Array interval)
        {
            for (int i = 0; i < IntervalsQuantity; i++)
            {
                interval[i] = Window.SetInterval(callback, ScrollSpeed + i * 10);
            }
        }

        private static void ClearIntervals()
        {
            ClearInterval(_topIntervals);
            ClearInterval(_rightIntervals);
            ClearInterval(_bottomIntervals);
            ClearInterval(_leftIntervals);
        }

        public static void GoToTop()
        {
            ClearIntervals();
            Document.Body.ScrollTop = 0;
        }

        private static void ClearInterval(Array interval)
        {
            foreach (int i in interval)
            {
                Window.ClearInterval(i);
            }
        }
    }
}
