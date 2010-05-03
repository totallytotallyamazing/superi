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
using System.Windows.Markup;

namespace Tina.Controls.Pages
{
    public delegate void OnThumbnailClickedDelegate(int indexThumb);

    public class Thumbnail
    {
        // Fields
        private OnThumbnailClickedDelegate _clickHandler;
        private int _index;
        private bool _isMouseDown;
        private bool _isMouseOver;
        public Canvas _xamlElement;

        // Methods
        public Thumbnail(PageGenerator pageGenerator, int index, OnThumbnailClickedDelegate clickHandler)
        {
            this._index = index;
            this._clickHandler = clickHandler;
            string str = "<Canvas xmlns='http://schemas.microsoft.com/client/2007' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' Canvas.Top='42' x:Name='thumb$1' Opacity='0.5'>";
            string xaml = (((((((((((((((((str + "  <Canvas.Resources>") + "        <Storyboard BeginTime='0' Duration='00:00:00.5' FillBehavior='Stop' x:Name='storyZoomIn$1'>" + "          <DoubleAnimationUsingKeyFrames BeginTime='00:00:00' Storyboard.TargetProperty='ScaleX' Storyboard.TargetName='scale$1'>") + "            <SplineDoubleKeyFrame KeySpline='0.7,0,0.4,1' Value='0.25' KeyTime='00:00:00.3'/>" + "          </DoubleAnimationUsingKeyFrames>") + "          <DoubleAnimationUsingKeyFrames BeginTime='00:00:00' Storyboard.TargetProperty='ScaleY' Storyboard.TargetName='scale$1'>" + "            <SplineDoubleKeyFrame KeySpline='0.7,0,0.4,1' Value='0.25' KeyTime='00:00:00.3'/>") + "          </DoubleAnimationUsingKeyFrames>" + "          <DoubleAnimationUsingKeyFrames BeginTime='00:00:00' Storyboard.TargetProperty='Y' Storyboard.TargetName='pos$1'>") + "            <SplineDoubleKeyFrame KeySpline='0.7,0,0.4,1' Value='-30' KeyTime='00:00:00.3'/>" + "          </DoubleAnimationUsingKeyFrames>") + "          <DoubleAnimationUsingKeyFrames BeginTime='00:00:00' Storyboard.TargetProperty='Opacity' Storyboard.TargetName='thumb$1'>" + "            <SplineDoubleKeyFrame KeySpline='0.7,0,0.4,1' Value='1' KeyTime='00:00:00.3'/>") + "          </DoubleAnimationUsingKeyFrames>" + "        </Storyboard>") + "  </Canvas.Resources>" + "  <Rectangle x:Name='thumbBackground$1' Height='44' Width='63' Fill='#37000000' Opacity='1' Canvas.Left='-31' Canvas.Top='-42'/>") + "  <Canvas>" + "    <Canvas.RenderTransform>") + "      <TransformGroup>" + "        <ScaleTransform x:Name='scale$1' ScaleX='0.07' ScaleY='0.07'/>") + "        <TranslateTransform x:Name='pos$1' X='0' Y='0'/>" + "      </TransformGroup>") + "    </Canvas.RenderTransform>" + "    <!--Rectangle x:Name='thumbOver$1' Height='630' Width='900' Fill='#66FF0000' Opacity='1' Canvas.Left='-450' Canvas.Top='-600' /-->") + "    <Canvas Canvas.Top='-570' Canvas.Left='-420'>" + "      $2") + "    </Canvas>" + "    <Canvas Canvas.Top='-570' Canvas.Left='0'>") + "      $3" + "    </Canvas>") + "  </Canvas>" + "</Canvas>").Replace("$1", index.ToString()).Replace("$2", pageGenerator.GetPageString((2 * index) - 1)).Replace("$3", pageGenerator.GetPageString(2 * index));
            this._xamlElement = (Canvas)XamlReader.Load(xaml);
            this._xamlElement.MouseEnter += new MouseEventHandler(this._xamlElement_MouseEnter);
            this._xamlElement.MouseLeave += new MouseEventHandler(this._xamlElement_MouseLeave);
            this._xamlElement.MouseLeftButtonDown += new MouseButtonEventHandler(this._xamlElement_MouseLeftButtonDown);
            this._xamlElement.MouseLeftButtonUp += new MouseButtonEventHandler(this._xamlElement_MouseLeftButtonUp);
            ((Storyboard)this._xamlElement.FindName("storyZoomIn" + index.ToString())).Completed += new EventHandler(this.xamlElement_StoryZoomIn_Completed);
            this._isMouseOver = false;
            this._isMouseDown = false;
        }

        private void _xamlElement_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!this._isMouseDown)
            {
                this._xamlElement.SetValue(Canvas.ZIndexProperty, 1);
                ((Storyboard)this._xamlElement.FindName("storyZoomIn" + this._index)).Begin();
            }
            else
            {
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(0x37, 0x23, 0xa3, 0xe0);
                ((Rectangle)this._xamlElement.FindName("thumbBackground" + this._index)).Fill = brush;
            }
            this._isMouseOver = true;
        }

        private void _xamlElement_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!this._isMouseDown)
            {
                this._xamlElement.SetValue(Canvas.ZIndexProperty, 0);
                ((Storyboard)this._xamlElement.FindName("storyZoomIn" + this._index)).Stop();
                this.setThumbZoom(false);
            }
            else
            {
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(0x37, 0xff, 0xff, 0xff);
                ((Rectangle)this._xamlElement.FindName("thumbBackground" + this._index)).Fill = brush;
            }
            this._isMouseOver = false;
        }

        private void _xamlElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromArgb(0x37, 0x23, 0xa3, 0xe0);
            ((Rectangle)this._xamlElement.FindName("thumbBackground" + this._index)).Fill = brush;
            ((Canvas)sender).CaptureMouse();
            this._isMouseDown = true;
        }

        private void _xamlElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this._isMouseOver && (this._clickHandler != null))
            {
                this._clickHandler(this._index);
            }
            this._xamlElement.SetValue(Canvas.ZIndexProperty, 0);
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromArgb(0x37, 0xff, 0xff, 0xff);
            ((Storyboard)this._xamlElement.FindName("storyZoomIn" + this._index)).Stop();
            this.setThumbZoom(false);
            ((Rectangle)this._xamlElement.FindName("thumbBackground" + this._index)).Fill = brush;
            ((Canvas)sender).ReleaseMouseCapture();
            this._isMouseDown = false;
        }

        private void setThumbZoom(bool on)
        {
            if (on)
            {
                ((ScaleTransform)this._xamlElement.FindName("scale" + this._index)).ScaleX = 0.25;
                ((ScaleTransform)this._xamlElement.FindName("scale" + this._index)).ScaleY = 0.25;
                ((TranslateTransform)this._xamlElement.FindName("pos" + this._index)).Y = -30.0;
                this._xamlElement.Opacity = 1.0;
            }
            else
            {
                ((ScaleTransform)this._xamlElement.FindName("scale" + this._index)).ScaleX = 0.07;
                ((ScaleTransform)this._xamlElement.FindName("scale" + this._index)).ScaleY = 0.07;
                ((TranslateTransform)this._xamlElement.FindName("pos" + this._index)).Y = 0.0;
                this._xamlElement.Opacity = 0.5;
            }
        }

        private void xamlElement_StoryZoomIn_Completed(object sender, EventArgs e)
        {
            this.setThumbZoom(true);
        }
    }
}
