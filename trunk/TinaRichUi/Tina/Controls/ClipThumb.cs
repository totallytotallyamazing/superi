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
using System.Windows.Media.Imaging;

namespace Tina
{
    public class ClipThumb : ContentControl
    {
        public static readonly DependencyProperty ImageUrlProperty = DependencyProperty.Register("ImageUrl", typeof(string), typeof(ClipThumb), new PropertyMetadata(ImageUrlPropertyChanged));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("ImageUrl", typeof(string), typeof(ClipThumb), new PropertyMetadata(TitlePropertyChanged));

        StackPanel panel = new StackPanel();
        Image image = new Image();
        TextBlock caption = new TextBlock();

        public ClipThumb()
        {
            this.Content = panel;
            panel.Orientation = Orientation.Vertical;
            panel.Children.Add(image);
            panel.Children.Add(caption);
            caption.Foreground = new SolidColorBrush(Colors.Green);
        }
        public string ImageUrl 
        { 
            get{return (string)GetValue(ImageUrlProperty);}
            set{SetValue(ImageUrlProperty, value);} 
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); } 
        }

        private static void ImageUrlPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        { 
            Uri uri = new Uri((string)e.NewValue, UriKind.RelativeOrAbsolute);
            (sender as ClipThumb).image.Source = new BitmapImage(uri);
        }

        private static void TitlePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ClipThumb).caption.Text = (string)e.NewValue;
            (sender as ClipThumb).caption.Width = 200;
            (sender as ClipThumb).caption.Height = 30;
            (sender as ClipThumb).caption.HorizontalAlignment = HorizontalAlignment.Center;
        }
    }
}

