using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tina.Controls.Pages
{
    public class PageBrowserControl
    {
        // Fields
        private double _currMouseX;
        private NavigationManager _navigationManager;
        private int _numPages;
        private Storyboard _openPageBrowserStoryboard;
        private Canvas _pageBrowser;
        private Canvas _pageBrowserButton;
        private Canvas _pageBrowserWindow;
        private Canvas _targetPageBrowserControl;
        private DispatcherTimer _timer;
        private double _totalPageBrowserRealWidth;

        // Methods
        public PageBrowserControl(UserControl parent, Canvas targetPageBrowserControl, PageGenerator pageGenerator, NavigationManager navigationManager, int numPages)
        {
            this._targetPageBrowserControl = targetPageBrowserControl;
            this._navigationManager = navigationManager;
            this._numPages = numPages;
            this._pageBrowserButton = (Canvas)targetPageBrowserControl.FindName("pageBrowserButton");
            this._pageBrowserWindow = (Canvas)targetPageBrowserControl.FindName("pageBrowserWindow");
            this._pageBrowser = (Canvas)targetPageBrowserControl.FindName("pageBrowser");
            this._openPageBrowserStoryboard = (Storyboard)targetPageBrowserControl.FindName("openPageBrowserSB");
            new PageBrowserButton(this._pageBrowserButton, new MouseButtonEventHandler(this.onPageBrowserButtonChecked_MouseLeftButtonUp), new MouseButtonEventHandler(this.onPageBrowserButtonUnchecked_MouseLeftButtonUp));
            this._pageBrowserWindow.MouseEnter += new MouseEventHandler(this._pageBrowserWindow_MouseEnter);
            this._pageBrowserWindow.MouseLeave += new MouseEventHandler(this._pageBrowserWindow_MouseLeave);
            this._pageBrowserWindow.MouseMove += new MouseEventHandler(this._pageBrowserWindow_MouseMove);
            OnThumbnailClickedDelegate clickHandler = new OnThumbnailClickedDelegate(this.onThumbnailClicked);
            for (int i = 0; i <= ((this._numPages + 1) / 2); i++)
            {
                Thumbnail thumbnail = new Thumbnail(pageGenerator, i, clickHandler);
                thumbnail._xamlElement.SetValue(Canvas.LeftProperty, (i * 70) + 42.0);
                this._pageBrowser.Children.Add(thumbnail._xamlElement);
            }
            this._totalPageBrowserRealWidth = 70.0 + (Math.Floor((double)((this._numPages + 1) / 2)) * 70.0);
            this._timer = new DispatcherTimer();
            this._timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            this._timer.Tick += new EventHandler(this._timer_Tick);
        }

        private void _pageBrowserWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            this._currMouseX = e.GetPosition(null).X;
            this._timer.Start();
        }

        private void _pageBrowserWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            this._timer.Stop();
        }

        private void _pageBrowserWindow_MouseMove(object sender, MouseEventArgs e)
        {
            this._currMouseX = e.GetPosition(null).X;
            if (!this._timer.IsEnabled)
            {
                this._timer.Start();
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (this._currMouseX < 130.0)
            {
                double num = (double)this._pageBrowser.GetValue(Canvas.LeftProperty);
                double num2 = (130.0 - this._currMouseX) / 8.0;
                if (num < -num2)
                {
                    num += num2;
                    this._pageBrowser.SetValue(Canvas.LeftProperty, num);
                }
                else
                {
                    this._timer.Stop();
                    this._pageBrowser.SetValue(Canvas.LeftProperty, 0.0);
                }
            }
            else if (this._currMouseX > 720.0)
            {
                double num3 = (double)this._pageBrowser.GetValue(Canvas.LeftProperty);
                double num4 = (this._currMouseX - 720.0) / 8.0;
                if (num3 > ((840.0 - this._totalPageBrowserRealWidth) + num4))
                {
                    num3 -= num4;
                    this._pageBrowser.SetValue(Canvas.LeftProperty, num3);
                }
                else
                {
                    this._timer.Stop();
                    this._pageBrowser.SetValue(Canvas.LeftProperty, 840.0 - this._totalPageBrowserRealWidth);
                }
            }
            else
            {
                this._timer.Stop();
            }
        }

        public void onPageBrowserButtonChecked_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this._openPageBrowserStoryboard.Begin();
            this._pageBrowserWindow.IsHitTestVisible = true;
        }

        public void onPageBrowserButtonUnchecked_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this._openPageBrowserStoryboard.Stop();
            this._pageBrowserWindow.IsHitTestVisible = false;
        }

        private void onThumbnailClicked(int indexThumb)
        {
            this._navigationManager.JumpToPage((indexThumb * 2) - 1);
        }
    }


}
