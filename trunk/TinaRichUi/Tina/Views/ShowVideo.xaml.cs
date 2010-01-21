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
    public partial class ShowVideo : ChildWindow
    {
        string url = "";
        public ShowVideo()
        {
            InitializeComponent();
        }

        public ShowVideo(string url)
        {
            InitializeComponent();
            this.url = url;
        }

        private void ChildWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            mediaElement.SetValue(MediaElement.SourceProperty, new Uri(url, UriKind.Absolute));
        }

        private void mediaElement_MediaOpened(object sender, System.Windows.RoutedEventArgs e)
        {
        	mediaElement.Play();
			slider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
        	mediaElement.Position = TimeSpan.FromMilliseconds(slider.Value);
        }

        private void maximize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	VisualStateManager.GoToState(this, "Large", true);
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void mediaElement_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MouseOver.Begin();
            //grid.SetValue(Grid.OpacityProperty, (double)1);
        	//VisualStateManager.GoToState(this, "MouseOver", true);
        }

        private void mediaElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //MoueLeave.Begin();
            //grid.SetValue(Grid.OpacityProperty, (double)1);
            //VisualStateManager.GoToState(this, "MouseOver", true);
        }

        private void play_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	MoueLeave.Begin();
			// TODO: Add event handler implementation here.
        }
    }
}

