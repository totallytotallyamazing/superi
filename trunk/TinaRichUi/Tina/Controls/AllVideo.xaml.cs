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
        	Storyboard1.Begin();
        }

        private void rotatePanel_Rotate(object sender, Tina.RotatePanelItemChangedEventArgs e)
        {
            if (e.FromControl != null)
            {
                DoubleAnimation shrinkX = shrinkCurrent.Children[0] as DoubleAnimation;
                DoubleAnimation shrinkY = shrinkCurrent.Children[0] as DoubleAnimation;
                shrinkCurrent.Stop();
                Storyboard.SetTarget(shrinkX, e.FromControl);
                Storyboard.SetTarget(shrinkY, e.FromControl);
                e.FromControl.SetValue(Canvas.ZIndexProperty, 0);
                shrinkCurrent.Begin();
            }

            DoubleAnimation zoomX = zoomCurrent.Children[0] as DoubleAnimation;
            DoubleAnimation zoomY = zoomCurrent.Children[1] as DoubleAnimation;
            zoomCurrent.Stop();
            Storyboard.SetTarget(zoomX, e.ToControl);
            Storyboard.SetTarget(zoomY, e.ToControl);
            zoomCurrent.Begin();
            e.ToControl.SetValue(Canvas.ZIndexProperty, 999);
        }
    }
}