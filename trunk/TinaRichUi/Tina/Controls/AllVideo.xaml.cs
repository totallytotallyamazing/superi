using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Tina
{
    public partial class AllVideo : UserControl
    {
        Storyboard zoomCurrent = new Storyboard();
        Storyboard shrinkCurrent = new Storyboard();
        Storyboard slideBoard = new Storyboard();
        Image currentImage = null;
        int index = 0;

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(Dictionary<string, string>),
            typeof(AllVideo), new PropertyMetadata(new PropertyChangedCallback(OnItemsChanged)));

        public Dictionary<string, string> Items
        {
            get { return (Dictionary<string, string>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        private static void OnItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }

        void GoToItem(int to)
        {

        }

        void CreateStoryboards()
        {
            //(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)
            Duration duration = new Duration(TimeSpan.FromMilliseconds(100));
            DoubleAnimation zoomX = new DoubleAnimation();
            zoomX.Duration = duration;
            zoomX.From = 1;
            zoomX.To = 1.2;
            DoubleAnimation zoomY = new DoubleAnimation();
            zoomY.Duration = duration;
            zoomY.From = 1;
            zoomY.To = 1.2;
            Storyboard.SetTargetProperty(zoomX, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            Storyboard.SetTargetProperty(zoomY, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
            zoomCurrent.Children.Add(zoomX);
            zoomCurrent.Children.Add(zoomY);

            DoubleAnimation shrinkX = new DoubleAnimation();
            shrinkX.Duration = duration;
            shrinkX.From = 1.2;
            shrinkX.To = 1;
            Storyboard.SetTargetProperty(shrinkX, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            DoubleAnimation shrinkY = new DoubleAnimation();
            shrinkY.Duration = duration;
            shrinkY.From = 1.2;
            shrinkY.To = 1;
            Storyboard.SetTargetProperty(shrinkY, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
            shrinkCurrent.Children.Add(shrinkY);

            LayoutRoot.Resources.Add("zoomBoard", zoomCurrent);
            LayoutRoot.Resources.Add("shrinkBoard", shrinkCurrent);
        }

        void CreateItemsPanel()
        {

        }

        public AllVideo()
        {
            InitializeComponent();
            CreateStoryboards();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //rotateRight.Seek(GetSoryboardOffset());
        }

        double offset;

        private void rotatePanel_Rotate(object sender, Tina.RotatePanelItemChangedEventArgs e)
        {
            if (e.FromControl != null)
            {
                DoubleAnimation shrinkX = shrinkCurrent.Children[0] as DoubleAnimation;
                DoubleAnimation shrinkY = shrinkCurrent.Children[0] as DoubleAnimation;
                shrinkCurrent.Stop();
                Storyboard.SetTarget(shrinkX, e.FromControl);
                Storyboard.SetTarget(shrinkY, e.FromControl);
                shrinkCurrent.Begin();
                (e.FromControl as ClipThumb).HideCaption();
            }

            DoubleAnimation zoomX = zoomCurrent.Children[0] as DoubleAnimation;
            DoubleAnimation zoomY = zoomCurrent.Children[1] as DoubleAnimation;
            zoomCurrent.Stop();
            Storyboard.SetTarget(zoomX, e.ToControl);
            Storyboard.SetTarget(zoomY, e.ToControl);
            zoomCurrent.Begin();
            (e.ToControl as ClipThumb).ShowCaption();
        }

        //private TimeSpan GetSoryboardOffset()
        //{
        //    double offset = 360.0 + this.offset;
        //    int miliseconds = (int)Math.Floor(TimeSpan.FromSeconds(40).TotalMilliseconds * offset / 720.0);
        //    TimeSpan result = TimeSpan.FromMilliseconds(miliseconds);
        //    return result;
        //}

        //bool rotatingLeft = false;
        //bool rotatingRight = false;

        //private double EvaluateRatio(double relativePosition)
        //{
        //    double result = 1.0;
        //    if (relativePosition < 0.3)
        //        result = 0.01;
        //    else if (relativePosition < 0.53)
        //        result = 1.0;
        //    else if (relativePosition < 0.80)
        //        result = 1.5;
        //    else
        //        result = 2.0;
        //    return result;
        //}

        //private void rotatorGrid_MouseMove(object sender, MouseEventArgs e)
        //{
        //    stopOnNext = false;
        //    double pos = e.GetPosition(rotatePanel).X;
        //    double width = rotatePanel.ActualWidth;
        //    bool left = pos < width / 2;
        //    double relativePos = Math.Abs(width / 2 - pos) /(width / 2) ;
        //    double ratio = EvaluateRatio(relativePos);
        //    if (left)
        //    {
        //        if (!rotatingLeft)
        //        {
        //            rotatingLeft = true;
        //            if (rotatingRight)
        //            {
        //                offset = rotatePanel.Offset;
        //                rotateRight.Stop();
        //                rotatingRight = false;
        //            }
        //            rotatingLeft = true;
        //            rotateLeft.Begin();
        //            rotateLeft.Seek(GetSoryboardOffset());
        //        }
        //            rotateLeft.SpeedRatio = ratio;
        //            //rotateLeft.Seek(GetSoryboardOffset());
        //    }
        //    else
        //    {
        //        if (!rotatingRight)
        //        {
        //            rotatingRight = true;
        //            if (rotatingLeft)
        //            {
        //                offset = rotatePanel.Offset;
        //                rotateLeft.Stop();
        //                rotatingLeft = false;
        //            }
        //            rotatingRight = true;
        //            rotateRight.Begin();
        //            rotateRight.Seek(GetSoryboardOffset());
        //        }
        //        rotateRight.SpeedRatio = ratio;
        //        //rotateLeft.Seek(GetSoryboardOffset());
        //    }

        //}

        //bool stopOnNext = false;

        //private void rotatorGrid_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    stopOnNext = true;
        //}

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rotatePanel.Offset = e.NewValue;
        }

        private void brnRight_Click(object sender, System.Windows.RoutedEventArgs e)
        {
          if(rotatePanel.Offset >= 280) 
            rotatePanel.Offset= 0;
          rotatePanel.Offset += 80;
        }

        private void btnLeft_Click(object sender, System.Windows.RoutedEventArgs e)
        {
          if(rotatePanel.Offset <= -280) 
            rotatePanel.Offset= 0;
          rotatePanel.Offset -= 80;        	
        }
    }
}