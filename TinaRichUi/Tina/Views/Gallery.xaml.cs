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

namespace Tina
{
    public partial class Gallery : Page
    {
        List<GalleryImagePresentation> gallery = new List<GalleryImagePresentation>();

        public Gallery()
        {
            InitializeComponent();

            RichServiceSoapClient client = new RichServiceSoapClient();
            client.GetGalleryCompleted += new EventHandler<Tina.RichServiceReference.GetGalleryCompletedEventArgs>(client_GetGalleryCompleted);
            client.GetGalleryAsync(-1);

        }

        void client_GetGalleryCompleted(object sender, Tina.RichServiceReference.GetGalleryCompletedEventArgs e)
        {
            gallery = e.Result.ToList();
            StackPanel panel = new StackPanel();
            foreach (var item in gallery)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Foreground = new SolidColorBrush(Colors.White);
                textBlock.Text = item.Picture;
                panel.Children.Add(textBlock);
            }
            LayoutRoot.Children.Add(panel);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
