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

namespace Tina
{
    public partial class GallerySlideShow : ChildWindow
    {
        public GallerySlideShow()
        {
            InitializeComponent();
        }

        public GallerySlideShow(int startIndex)
        {
            InitializeComponent();
            SlideShowControl slideShow = new SlideShowControl(startIndex);
            LayoutRoot.Children.Add(slideShow);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.DialogResult = true;
        }
    }
}

