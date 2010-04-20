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
using Tina.Controls;

namespace Tina
{
    public partial class ShowVideo : ChildWindow
    {
        string url = "";
        bool paused = false;

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
            slider.SmallChange = slider.Maximum / 10;
        }

        private void slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Position = TimeSpan.FromMilliseconds(slider.Value);
        }

        private void maximize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Maximize.Begin();
            maximize.Visibility = Visibility.Collapsed;
            minimize.Visibility = Visibility.Visible;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void mediaElement_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!paused)
                MouseOver.Begin();
        }

        private void mediaElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!paused)
                MoueLeave.Begin();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            Minimize.Begin();
            minimize.Visibility = Visibility.Collapsed;
            maximize.Visibility = Visibility.Visible;
        }

        private void pauseBottom_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            pauseBottom.Visibility = Visibility.Collapsed;
            play.Visibility = Visibility.Visible;
            playBottom.Visibility = Visibility.Visible;
            grid.Opacity = 1;
            paused = true;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            pauseBottom.Visibility = Visibility.Visible;
            play.Visibility = Visibility.Collapsed;
            playBottom.Visibility = Visibility.Collapsed;
            paused = false;
        }


        private void slider_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(slider);
            double progress = slider.Maximum * position.X / slider.ActualWidth;
            slider.Value = progress;
        }

        #region Volume
        private bool playVideoWhenSliderDragIsOver = false;

        private Slider GetSliderParent(object sender)
        {
          FrameworkElement element = (FrameworkElement)sender;
          do
          {
            element = (FrameworkElement)VisualTreeHelper.GetParent(element);
          } while (!(element is Slider));
          return (Slider)element;
        }

        private void LeftTrack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          e.Handled = true;
          FrameworkElement lefttrack = (sender as FrameworkElement).FindName("LeftTrack") as FrameworkElement;
          FrameworkElement righttrack = (sender as FrameworkElement).FindName("RightTrack") as FrameworkElement;
          double position = e.GetPosition(lefttrack).X;
          double width = righttrack.TransformToVisual(lefttrack).Transform(new Point(righttrack.ActualWidth, righttrack.ActualHeight)).X;
          double percent = position / width;
          Slider slider = GetSliderParent(sender);
          slider.Value = percent;
        }

        private void HorizontalThumb_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
          if (GetSliderParent(sender) != slider) return;

          bool notPlaying = (mediaElement.CurrentState == MediaElementState.Paused
              || mediaElement.CurrentState == MediaElementState.Stopped);

          if (notPlaying)
          {
            playVideoWhenSliderDragIsOver = false;
          }
          else
          {
            playVideoWhenSliderDragIsOver = true;
            mediaElement.Pause();
          }
        }

        private void HorizontalThumb_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
          if (playVideoWhenSliderDragIsOver)
            mediaElement.Play();
        }


        #endregion

    }
}

