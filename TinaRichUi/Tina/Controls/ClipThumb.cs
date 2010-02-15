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

namespace Tina.Controls
{
    public class ClipThumb : ContentControl
    {
        public static readonly DependencyProperty ImageUrlProperty = DependencyProperty.Register("ImageUrl", typeof(string), typeof(ClipThumb), new PropertyMetadata(PropertyChangedCallback(ImageUrlPropertyChanged)));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("ImageUrl", typeof(string), typeof(ClipThumb), null);

        StackPanel panel = new StackPanel();

        public ClipThumb()
        {
            this.Content = panel;
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

        private void ImageUrlPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        { 
            (sender as ClipThumb)
        }

        private void TitlePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        { 
            
        }
    }
}
