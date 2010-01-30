using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Tina.Controls;

namespace Tina
{
    public partial class showClip : UserControl
    {
        bool paused = false;

        public event EventHandler Maximizing;
        public event EventHandler Minimizing;

        //public event RoutedEventHandler MediaOpened
        //{
        //    add { mediaElement.MediaOpened += value; }
        //    remove { mediaElement.MediaOpened -= value; }
        //}


        public static DependencyProperty MediaSourceProperty = DependencyProperty.Register(
            "MediaSource",
            typeof(Uri),
            typeof(showClip),
            new PropertyMetadata(MediaSourcePropertyChanged));

        public Uri MediaSource
        {
            set { this.SetValue(MediaSourceProperty, value); }
            get { return (Uri)this.GetValue(MediaSourceProperty); }
        }

        public showClip()
        {
            // Required to initialize variables
            InitializeComponent();
        }

        private static void MediaSourcePropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as showClip).mediaElement.Source = args.NewValue as Uri;
        }

        #region Pubblic Methods
        public void Stop()
        {
            mediaElement.Stop();
        }

        public void Play()
        {
            mediaElement.Play();
        }

        public void SetSource(string url)
        {
            mediaElement.SetValue(MediaElement.SourceProperty, new Uri(url, UriKind.Absolute));
        }
        #endregion

        #region Component Event Handlers
        private void mediaElement_MediaOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            mediaElement.Play();
            slider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            slider.SmallChange = slider.Maximum / 10;
            AdjustDimensions();
        }

        private void slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Position = TimeSpan.FromMilliseconds(slider.Value);
        }

        private void maximize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Maximizing != null)
                Maximizing(this, new EventArgs());
            Maximize.Begin();
            maximize.Visibility = Visibility.Collapsed;
            minimize.Visibility = Visibility.Visible;
            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.Margin = new Thickness(0, 0, 0, 0);
			this.Width = 800;
			this.Height = 600;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
           // this.DialogResult = true;
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
            if (Minimizing != null)
                Minimizing(this, new EventArgs());
            Minimize.Begin();
            minimize.Visibility = Visibility.Collapsed;
            maximize.Visibility = Visibility.Visible;
			this.Width = 400;
			this.Height = 300;

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
        #endregion

        private void AdjustDimensions()
        {
            mediaElement.Width = this.Width;
            mediaElement.Height = this.Height;
            grid.Width = this.Width;
            grid.Height = this.Height;
            rectangle.Width = this.Width;
            rectangle.Height = this.Height;
        }
    }
}