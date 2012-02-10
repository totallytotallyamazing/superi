// ContentScroller.cs
//

using System;
using System.Collections.Generic;
using jQueryApi;
using System.Html;

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


    public class ContentScroller
    {
        const int ScrollSpeed = 100;
        const int ScrollStep = 3    ;
        const int IntervalsQuantity = 20;
        ScrollDirection _scrollDirection = ScrollDirection.None;

        int _scrollMargin = 100;
        Array _topIntervals = new Array();
        Array _rightIntervals = new Array();
        Array _bottomIntervals = new Array();
        Array _leftIntervals = new Array();

        public static void Enable()
        {
            ContentScroller scroller = new ContentScroller();
            scroller.Attach();
        }

        protected void Attach()
        {
            jQuery.Document.MouseMove(MouseMove);
        }

        private void MouseMove(jQueryEvent e)
        {
            ScrollDirection scrollDirection = GetScrollDirection(e.PageX, e.PageY);

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
            ScrollDirection result = ScrollDirection.None;
            if (x < _scrollMargin && Document.Body.ScrollLeft > 0)
                result = ScrollDirection.Left;
            if (y < _scrollMargin && Document.Body.ScrollTop > 0)
                result |= ScrollDirection.Top;
            if (result != ScrollDirection.None)
                return result;

            int height = jQuery.FromElement(Document.Body).GetHeight();
            int width = jQuery.FromElement(Document.Body).GetWidth();

            if (x > width - _scrollMargin && Document.Body.ScrollLeft < Document.Body.ScrollWidth)
                result = ScrollDirection.Right;
            if (y > height - _scrollMargin && Document.Body.ScrollTop < Document.Body.ScrollHeight)
                result |= ScrollDirection.Bottom;

            return result;
        }

        private void StartScrolling(ScrollDirection scrollDirection)
        {
            if (scrollDirection == ScrollDirection.None)
                return;
            if ((scrollDirection & ScrollDirection.Top) == ScrollDirection.Top)
            {
                if (Document.Body.ScrollTop == 0)
                {
                    _scrollDirection = ScrollDirection.None;
                    ClearInterval(_topIntervals);
                }
                else if (!((_scrollDirection & ScrollDirection.Top) == ScrollDirection.Top))
                    SetInterval(delegate
                                {
                                    Document.Body.ScrollTop -= ScrollStep;
                                }, _topIntervals);
            }
            if ((scrollDirection & ScrollDirection.Right) == ScrollDirection.Right)
            {
                if (Document.Body.ScrollLeft == Document.Body.ScrollWidth)
                {
                    _scrollDirection = ScrollDirection.None;
                    ClearInterval(_rightIntervals);
                }
                else if (!((_scrollDirection & ScrollDirection.Right) == ScrollDirection.Right))
                    SetInterval(delegate
                    {
                        Document.Body.ScrollLeft += ScrollStep;
                    }, _rightIntervals);
            }
            if ((scrollDirection & ScrollDirection.Bottom) == ScrollDirection.Bottom)
            {
                if (Document.Body.ScrollTop == Document.Body.ScrollHeight)
                {
                    _scrollDirection = ScrollDirection.None;
                    ClearInterval(_bottomIntervals);
                }
                else if (!((_scrollDirection & ScrollDirection.Bottom) == ScrollDirection.Bottom))
                    SetInterval(delegate
                    {
                        Document.Body.ScrollTop += ScrollStep;
                    }, _bottomIntervals);
            }
            if ((scrollDirection & ScrollDirection.Left) == ScrollDirection.Left)
            {
                if (Document.Body.ScrollLeft == 0)
                {
                    _scrollDirection = ScrollDirection.None;
                    ClearInterval(_leftIntervals);
                }
                else if (!((_scrollDirection & ScrollDirection.Left) == ScrollDirection.Left))
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
                interval[i] = Window.SetInterval(callback, ScrollSpeed + i*10);
            }
        }

        private void ClearIntervals()
        {
            ClearInterval(_topIntervals);
            ClearInterval(_rightIntervals);
            ClearInterval(_bottomIntervals);
            ClearInterval(_leftIntervals);
        }

        private void ClearInterval(Array interval)
        {
            for (int i = 0; i < interval.Length; i++)
            {
                Window.ClearInterval((int)interval[i]);
            }
        }
    }
}
