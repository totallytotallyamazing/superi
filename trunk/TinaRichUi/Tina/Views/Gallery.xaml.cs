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
        List<GalleryImagePresentation> gallery = new List<GalleryImagePresentation>();

        public Gallery()
        {
            InitializeComponent();

            RichServiceSoapClient client = new RichServiceSoapClient("RichServiceTest", "http://test.tinakarol.ua/RichService.asmx");
            //RichServiceSoapClient client = new RichServiceSoapClient("RichServiceSoap", "http://localhost:49516/RichService.asmx");
            client.GetGalleryCompleted += new EventHandler<Tina.RichServiceReference.GetGalleryCompletedEventArgs>(client_GetGalleryCompleted);
            client.GetGalleryAsync(0);

        }

        void client_GetGalleryCompleted(object sender, Tina.RichServiceReference.GetGalleryCompletedEventArgs e)
        {
            gallery = e.Result.ToList();
            foreach (var item in gallery)
            {
                Image image = new Image();
                image.Width = 80;
                image.Height = 80;
                image.Margin = new Thickness(0, 0, 16, 16);
                image.HorizontalAlignment = HorizontalAlignment.Center;
                image.Source = new BitmapImage(new Uri("http://tinakarol.ua/Images/Gallery/"+item.Thumbnail, UriKind.Absolute));
                panel.Children.Add(image);
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
