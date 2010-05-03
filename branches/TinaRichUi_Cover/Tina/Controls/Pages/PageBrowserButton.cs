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

namespace Tina.Controls.Pages
{
    public class PageBrowserButton
    {
        // Fields
        private MouseButtonEventHandler _checkedHandler;
        private bool _isMouseDown;
        private bool _isMouseOver;
        private string _pageBrowserButtonCurrentState;
        private Canvas _targetPageBrowserButton;
        private MouseButtonEventHandler _uncheckedHandler;

        // Methods
        public PageBrowserButton(Canvas targetPageBrowserButton, MouseButtonEventHandler checkedHandler, MouseButtonEventHandler uncheckedHandler)
        {
            this._targetPageBrowserButton = targetPageBrowserButton;
            this._checkedHandler = checkedHandler;
            this._uncheckedHandler = uncheckedHandler;
            this._pageBrowserButtonCurrentState = "unchecked";
            this._isMouseOver = false;
            this._isMouseDown = false;
            targetPageBrowserButton.MouseEnter += new MouseEventHandler(this.targetPageBrowserButton_MouseEnter);
            targetPageBrowserButton.MouseLeave += new MouseEventHandler(this.targetPageBrowserButton_MouseLeave);
            targetPageBrowserButton.MouseLeftButtonDown += new MouseButtonEventHandler(this.targetPageBrowserButton_MouseLeftButtonDown);
            targetPageBrowserButton.MouseLeftButtonUp += new MouseButtonEventHandler(this.targetPageBrowserButton_MouseLeftButtonUp);
        }

        private void targetPageBrowserButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_over");
            Image image2 = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_normal");
            Image image3 = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_down");
            if (this._isMouseDown)
            {
                image2.Opacity = 0.0;
                image.Opacity = 0.0;
                image3.Opacity = 1.0;
            }
            else
            {
                image2.Opacity = 0.0;
                image.Opacity = 1.0;
            }
            this._isMouseOver = true;
        }

        private void targetPageBrowserButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_over");
            Image image2 = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_normal");
            Image image3 = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_down");
            if (this._isMouseDown)
            {
                image2.Opacity = 0.0;
                image.Opacity = 1.0;
                image3.Opacity = 0.0;
            }
            else
            {
                image2.Opacity = 1.0;
                image.Opacity = 0.0;
            }
            this._isMouseOver = false;
        }

        private void targetPageBrowserButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_over");
            Image image2 = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_down");
            image2.Opacity = 1.0;
            image.Opacity = 0.0;
            this._isMouseDown = true;
            this._targetPageBrowserButton.CaptureMouse();
        }

        private void targetPageBrowserButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_over");
            Image image2 = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_normal");
            Image image3 = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_down");
            if (this._isMouseOver)
            {
                if (this._pageBrowserButtonCurrentState == "unchecked")
                {
                    this._pageBrowserButtonCurrentState = "checked";
                    if (this._checkedHandler != null)
                    {
                        this._checkedHandler(sender, e);
                    }
                }
                else
                {
                    this._pageBrowserButtonCurrentState = "unchecked";
                    if (this._uncheckedHandler != null)
                    {
                        this._uncheckedHandler(sender, e);
                    }
                }
                Image image4 = (Image)this._targetPageBrowserButton.FindName(this._pageBrowserButtonCurrentState + "_over");
                image4.Opacity = 1.0;
                image3.Opacity = 0.0;
            }
            else
            {
                image2.Opacity = 1.0;
                image3.Opacity = 0.0;
                image.Opacity = 0.0;
            }
            this._isMouseDown = false;
            this._targetPageBrowserButton.ReleaseMouseCapture();
        }
    }


}
