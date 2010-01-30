using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Tina
{
    public partial class SlideShowControl : UserControl
    {
        public static readonly DependencyProperty StartIndexProperty = DependencyProperty.Register("StartIndex", typeof(int), typeof(SlideShowControl), null);

        public int StartIndex
        {
            get { return (int)GetValue(StartIndexProperty); }
            set { SetValue(StartIndexProperty, value); }
        }

        #region '" Constructor and SlideShowControl events"'

        private bool bInitialLayoutUpdateComplete = false;

        private System.Windows.Threading.DispatcherTimer mTimer = new System.Windows.Threading.DispatcherTimer();


        public SlideShowControl(int startIndex)
        {
            StartIndex = startIndex;

            InitializeComponent();

            AddImages();

            RefreshNavigationImages(true, startIndex);
        }

        public void AddImages()
        {
            ImageList = new List<string>();

            foreach (var item in Gallery.gallery)
            {
                string imageUrl = "http://tinakarol.ua/Images/Gallery/" + item.Picture;
                ImageList.Add(imageUrl);
            }
        }


        private void SlideShowControl_LayoutUpdated(object sender, System.EventArgs e)
        {

            if (bInitialLayoutUpdateComplete == true)
            {
                return;
            }

            mTimer.Interval = TimeSpan.FromSeconds(4);
            mTimer.Tick += mTimer_Tick;
            mTimer.Start();

            bInitialLayoutUpdateComplete = true;

        }



        #endregion


        #region '" Control Events"'

        private void Image_MouseLeftButtonDown(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Image img = ((Image)(sender));

            string url = img.Tag.ToString();

            ShowImage(url);

        }



        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Image img = ((Image)(sender));
            img.Opacity = 1;

        }



        private void Image_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Image img = ((Image)(sender));
            img.Opacity = 0.65;

        }




        private void btnNext_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {

            RefreshNavigationImages( /* TRANSERROR: named argument: bForward:= */ true);

            mTimer.Stop();
            mTimer.Start();

        }

        private void btnPrevious_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {

            RefreshNavigationImages( /* TRANSERROR: named argument: bForward:= */ false);

            mTimer.Stop();
            mTimer.Start();

        }

        private void Grid_MouseEnter(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            Grid g = ((System.Windows.Controls.Grid)(sender));
            g.Opacity = 0.85;

            Image img = null;
            for (int i = 1; i <= 6; i++)
            {

                img = ((System.Windows.Controls.Image)(this.FindName("Image" + i)));
                img.Opacity = 0.65;

            }

        }

        private void Grid_MouseLeave(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            Grid g = ((System.Windows.Controls.Grid)(sender));
            g.Opacity = 0;

        }

        private void mTimer_Tick(object sender, System.EventArgs e)
        {

            string url = System.Convert.ToString(mainImage.Tag);

            int index = ImageList.IndexOf(url);

            if (index == ImageList.Count - 1)
            {

                index = 0;

                RefreshNavigationImages(true, -1);

            }
            else
            {
                index += 1;

                Image img = null;

                for (int i = 1; i <= 6; i++)
                {

                    img = ((System.Windows.Controls.Image)(this.FindName("Image" + i)));

                    if ((img.Tag + "") == url)
                    {

                        if (i == 6)
                        {
                            RefreshNavigationImages( /* TRANSERROR: named argument: bForward:= */ true);
                        }

                        break; /* TRANSWARNING: check that break is in correct scope */

                    }

                }

            }

            ShowImage(ImageList[index]);

        }



        #endregion


        #region '" Custom Methods"'

        private void RefreshNavigationImages(bool bForward, int startIndex)
        {

            string url = string.Empty;
            Image img = null;
            Border imgBorder = null;
            int imageIndex = startIndex;

            if (startIndex == 0)
            {

                if (bForward == true)
                {

                    for (int i = 6; i >= 1; i += -1)
                    {

                        img = ((System.Windows.Controls.Image)(this.FindName("Image" + i)));

                        if ((img.Tag + "").Trim() != "")
                        {

                            url = System.Convert.ToString(img.Tag);

                            startIndex = ImageList.IndexOf(url);
                            imageIndex = startIndex;

                            break;

                        }

                    }

                }
                else
                {
                    img = ((System.Windows.Controls.Image)(this.FindName("Image1")));

                    if ((img.Tag + "").Trim() != "")
                    {

                        url = System.Convert.ToString(img.Tag);

                        startIndex = ImageList.IndexOf(url);
                        imageIndex = startIndex;

                        if ((startIndex - 5) >= 0)
                        {
                            startIndex -= 5;
                        }

                    }

                }

            }
            else
            {
                if (startIndex == -1)
                {
                    startIndex = 0;
                }

            }


            for (int i = 1; i <= 6; i++)
            {

                img = ((System.Windows.Controls.Image)(this.FindName("Image" + i)));
                imgBorder = ((System.Windows.Controls.Border)(this.FindName("Image" + i + "Border")));

                if (((i - 1) + startIndex) >= ImageList.Count)
                {

                    img.Source = null;
                    img.Tag = "";
                    img.Opacity = 0;
                    imgBorder.Opacity = 0;

                    btnNext.IsEnabled = false;

                    continue;
                }
                else
                {
                    img.Opacity = 1;
                    imgBorder.Opacity = 1;

                    btnNext.IsEnabled = true;
                }

                url = ImageList[(i - 1) + startIndex];

                System.Windows.Media.Imaging.BitmapImage bi = new System.Windows.Media.Imaging.BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));

                img.Source = bi;
                img.Tag = url;

            }

            ShowImage(ImageList[imageIndex]);

        }

        private void RefreshNavigationImages(bool bForward)
        {
            RefreshNavigationImages(bForward, 0);
        }

        public void ShowImage(string url)
        {

            Image imag = null;
            Border imgBorder = null;

            //Loop through each image in the list, set the border color to white or yellow
            for (int i = 1; i <= 6; i++)
            {

                //Get the Image control
                imag = (Image)this.FindName("Image" + i);
                imgBorder = (Border)this.FindName(string.Format("Image{0}Border", i));

                //Check to see if the url of the image is the same as the url passed in
                if ((imag.Tag + "") == url)
                {

                    imgBorder.BorderBrush = new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    imgBorder.BorderBrush = new SolidColorBrush(Colors.White);

                }
            }

            //Enable or disable the buttons
            btnPrevious.IsEnabled = (ImageList.IndexOf(url) > 0);
            btnNext.IsEnabled = (ImageList.IndexOf(url) < (ImageList.Count - 1));


            //Show the image
            Storyboard sb = new Storyboard();

            Duration duration = new Duration(TimeSpan.FromMilliseconds(800));

            DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();

            //Create a new image with the url
            System.Windows.Media.Imaging.BitmapImage img = new System.Windows.Media.Imaging.BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));

            //Set the image as the Source, and store a reference to the url in the Tag
            mainImage.Source = img;
            mainImage.Tag = url;

            sb.Duration = duration;

            sb.Children.Add(myDoubleAnimation1);

            Storyboard.SetTarget(myDoubleAnimation1, mainImage);
            Storyboard.SetTargetProperty(myDoubleAnimation1, new PropertyPath("Opacity"));

            myDoubleAnimation1.From = 0;
            myDoubleAnimation1.To = 1;
            myDoubleAnimation1.Duration = duration;
            myDoubleAnimation1.AutoReverse = false;


            sb.Begin();

        }


        #endregion


        #region '" Properties"'

        private List<string> mImageList;
        public List<string> ImageList
        {
            get
            {
                return mImageList;
            }
            set
            {
                mImageList = value;
            }
        }


        private bool mShowDemoImages = true;
        public bool ShowDemoImages
        {
            get
            {
                return mShowDemoImages;
            }
            set
            {
                mShowDemoImages = value;
            }
        }

        #endregion


    }


}
