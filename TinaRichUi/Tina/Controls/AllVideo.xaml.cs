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
            DoubleAnimation zoom = new DoubleAnimation();
            zoom.Duration = duration;
            zoom.From = 1;
            zoom.To = 1.2;
            zoomCurrent.Children.Add(zoom);

            DoubleAnimation shrink = new DoubleAnimation();
            shrink.Duration = duration;
            shrink.From = 1.2;
            shrink.To = 1;
            shrinkCurrent.Children.Add(shrink);

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
    }
}