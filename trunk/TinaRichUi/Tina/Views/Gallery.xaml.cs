using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Tina.RichServiceReference;
using System.Windows.Media.Imaging;

namespace Tina
{
    public partial class Gallery : Page
    {
        public static List<GalleryImagePresentation> gallery = new List<GalleryImagePresentation>();

        bool createThumbnailsOnLoad = false;

        public Gallery()
        {
            InitializeComponent();

            RichServiceSoapClient client = new RichServiceSoapClient("RichServiceTest", "http://test.tinakarol.ua/RichService.asmx");
            //RichServiceSoapClient client = new RichServiceSoapClient("RichServiceSoap", "http://localhost:49516/RichService.asmx");

            if (gallery.Count == 0)
            {
                Busy.IsBusy = true;
                Busy.Visibility = Visibility.Visible;
                createThumbnailsOnLoad = true;
                client.GetGalleryCompleted += new EventHandler<Tina.RichServiceReference.GetGalleryCompletedEventArgs>(client_GetGalleryCompleted);
                client.GetGalleryAsync(0);
            }
        }

        void client_GetGalleryCompleted(object sender, Tina.RichServiceReference.GetGalleryCompletedEventArgs e)
        {
            gallery = e.Result.ToList();
            CreateThumbnails();
            Busy.IsBusy = false;
            Busy.Visibility = Visibility.Collapsed;
        }

        private void CreateThumbnails()
        {
            foreach (var item in gallery)
            {
                GalleryThumbnail thumbnail = new GalleryThumbnail();
                thumbnail.Margin = new Thickness(0, 0, 16, 16);
                thumbnail.ImageSource = new BitmapImage(new Uri("http://tinakarol.ua/Images/Gallery/" + item.Thumbnail, UriKind.Absolute));
                //thumbnail.Click += new EventHandler(thumbnail_Click);
                thumbnail.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(thumbnail_Click), true);
                panel.Children.Add(thumbnail);
            }
        }

        void thumbnail_Click(object sender, MouseButtonEventArgs e)
        {
            GallerySlideShow childWindow = new GallerySlideShow();
            childWindow.Show();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!createThumbnailsOnLoad)
                CreateThumbnails();
        }
    }
}
