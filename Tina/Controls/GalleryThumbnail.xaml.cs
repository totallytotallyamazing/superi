using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Tina
{
    public partial class GalleryThumbnail : UserControl
    {
        public static DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource",
            typeof(ImageSource),
            typeof(GalleryThumbnail),
            new PropertyMetadata(new PropertyChangedCallback(OnImageSourcePropertyChanged)));

        public event EventHandler Click;

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public GalleryThumbnail()
        {
            // Required to initialize variables
            InitializeComponent();
        }

        private static void OnImageSourcePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            (source as GalleryThumbnail).Thumbnail.Source = e.NewValue as ImageSource;
        }

        private void HyperlinkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(this, new EventArgs());
            }
        }


    }
}