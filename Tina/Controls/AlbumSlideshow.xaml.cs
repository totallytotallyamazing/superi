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
using System.Windows.Threading;

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
        Image topImage = null;
        Image backImage = null;
        string album = "";
        int currentIndex = 0;
        Storyboard fadeOut = new Storyboard();
        Storyboard fadeIn = new Storyboard();
        DispatcherTimer timer = new DispatcherTimer();


        public AlbumSlideshow()
        {
            topImage = image1;
            backImage = image2;
            image1.Opacity = 1;
            image2.Opacity = 0;
            string[] night = { "noch01.jpg", "noch02.jpg", "noch03.jpg", "noch04.jpg", "noch05.jpg", "noch06.jpg", "noch07.jpg", "noch08.jpg" };
            string[] pupsik = { "pupsik01.jpg", "pupsik02.jpg", "pupsik03.jpg", "pupsik04.jpg", "pupsik05.jpg", "pupsik06.jpg", "pupsik07.jpg", "pupsik08.jpg" };
            string[] high = { "high1.jpg", "high2.jpg", "high3.jpg", "high4.jpg", "high5.jpg" };
            string[] key = { "kluchik1.jpg", "kluchik2.jpg", "kluchik3.jpg", "kluchik4.jpg", "kluchik5.jpg", "kluchik6.jpg", "kluchik7.jpg", "kluchik8.jpg", "kluchik9.jpg" };
            string[] love = { "love01.jpg", "love02.jpg", "love03.jpg", "love04.jpg", "love05.jpg", "love06.jpg", "love07.jpg", "love08.jpg", "love09.jpg", "love10.jpg", "love11.jpg", "love12.jpg", "love13.jpg", "love14.jpg", "love15.jpg", "love16.jpg" };

            pictures.Add("night", night);
            pictures.Add("pupsik", pupsik);
            pictures.Add("high", high);
            pictures.Add("key", key);
            pictures.Add("love", love);
            InitializeComponent();
            LayoutRoot.Children.Add(image1);
            LayoutRoot.Children.Add(image2);

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromMilliseconds(1200);
            CreateStoryboards();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            SwitchImages();
        }

        private void SwitchImages()
        {
            fadeIn.Stop();
            fadeOut.Stop();

            Storyboard.SetTarget(fadeOut, topImage);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath("(Opacity)"));

            Storyboard.SetTarget(fadeIn, backImage);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath("(Opacity)"));

            currentIndex++;
            currentIndex = currentIndex % pictures[album].Length;

            Uri imageUri = new Uri("http://test.tinakarol.ua/Images/SlideShow/" + album + "/" + pictures[album][currentIndex], UriKind.RelativeOrAbsolute);
            backImage.Source = new BitmapImage(imageUri);

            fadeOut.Begin();
            fadeIn.Begin();

            Image temp = topImage;
            topImage = backImage;
            backImage = temp;
        }

        public void ResetSlideShow()
        { 
            fadeIn.Stop();
            fadeOut.Stop();
            currentIndex = -1;
            SwitchImages();
            timer.Stop();
        }

        private void CreateStoryboards()
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(1000));
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

            LayoutRoot.Resources.Add("fadeIn", fadeIn);
            LayoutRoot.Resources.Add("fadeOut", fadeOut);
        }

        private static void AlbumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            AlbumSlideshow slideshow = sender as AlbumSlideshow;
            string albumName = (string)e.NewValue;
            string firstImage = slideshow.pictures[albumName][0];
            Uri imageUri = new Uri("http://test.tinakarol.ua/Images/SlideShow/" + albumName + "/" + firstImage, UriKind.RelativeOrAbsolute);
            slideshow.image1.Source = new BitmapImage(imageUri);
            slideshow.album = albumName;
        }

        private void LayoutRoot_MouseEnter(object sender, MouseEventArgs e)
        {
            SwitchImages();
            timer.Start();
        }

        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            ResetSlideShow();
            timer.Stop();
        }
    }
}
