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
using System.Windows.Media.Imaging;

namespace Tina
{
    public partial class AlbumSlideshow : UserControl
    {
        public static readonly DependencyProperty AlbumProperty = DependencyProperty.Register("Album",
            typeof(string), typeof(AlbumSlideshow),
            new PropertyMetadata(new PropertyChangedCallback(AlbumChanged)));

        public string Album
        {
            get
            {
                return (string)GetValue(AlbumProperty);
            }
            set
            {
                SetValue(AlbumProperty, value);
            }
        }

        private Dictionary<string, string[]> pictures = new Dictionary<string, string[]>();

        Image image1 = new Image();
        Image image2 = new Image();
        Image currentImage = null;
        string album = "";
        int currentIndex = 0;
        Storyboard fadeOut = new Storyboard();
        Storyboard fadeIn = new Storyboard();


        public AlbumSlideshow()
        {
            currentImage = image1;
            image1.Opacity = 1;
            image2.Opacity = 0;
            string[] night = { "noch01.jpg", "noch02.jpg", "noch03.jpg", "noch04.jpg", "noch05.jpg", "noch06.jpg", "noch07.jpg", "noch08.jpg" };
            string[] pupsik = { "pupsik01.jpg", "pupsik02.jpg", "pupsik03.jpg", "pupsik04.jpg", "pupsik05.jpg", "pupsik06.jpg", "pupsik07.jpg", "pupsik08.jpg" };
            pictures.Add("night", night);
            pictures.Add("pupsik", pupsik);
            InitializeComponent();
            LayoutRoot.Children.Add(image1);
            LayoutRoot.Children.Add(image2);

            CreateStoryboards();
        }

        private void CreateStoryboards()
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
            DoubleAnimation inAnimation = new DoubleAnimation();
            inAnimation.From = 0;
            inAnimation.To = 1;
            inAnimation.Duration = duration;

            DoubleAnimation outAnimation = new DoubleAnimation();
            outAnimation.From = 1;
            outAnimation.To = 0;
            outAnimation.Duration = duration;

            fadeIn.Children.Add(inAnimation);
            fadeOut.Children.Add(outAnimation);
            Storyboard.SetTarget(fadeOut, image1);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath("(Opacity)"));

            Storyboard.SetTarget(fadeIn, image2);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath("(Opacity)"));

            LayoutRoot.Resources.Add("fadeIn", fadeIn);
            LayoutRoot.Resources.Add("fadeOut", fadeOut);
        }
        

        private static void AlbumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            AlbumSlideshow slideshow = sender as AlbumSlideshow;
            string albumName = (string)e.NewValue;
            string firstImage = slideshow.pictures[albumName][0];
            Uri imageUri = new Uri("http://localhost:49516/Images/SlideShow/" + albumName + "/" + firstImage, UriKind.RelativeOrAbsolute);
            slideshow.image1.Source = new BitmapImage(imageUri);
            slideshow.album = albumName;

            string secondImage = slideshow.pictures[albumName][1];
            Uri secondImageUri = new Uri("http://localhost:49516/Images/SlideShow/" + albumName + "/" + secondImage, UriKind.RelativeOrAbsolute);
            slideshow.image2.Source = new BitmapImage(secondImageUri);
            slideshow.album = albumName;
        }

        private void ShowImage(int index)
        {
            Uri imageUri = new Uri("http://localhost:49516/Images/SlideShow/" + album + "/" + pictures[album][index], UriKind.RelativeOrAbsolute);
            image1.Source = new BitmapImage(imageUri);
        }

        private void LayoutRoot_MouseEnter(object sender, MouseEventArgs e)
        {
            fadeOut.Begin();
            fadeIn.Begin();
        }

        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }
    }
}
