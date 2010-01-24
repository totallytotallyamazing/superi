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
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using Tina.Controls;
using System.Windows.Threading;

namespace Tina
{
    public partial class Show : Page
    {
        SmylSong currentControl = null;
        Slider currentSlider = null;
        DispatcherTimer timer = null;
        object locker = new object();
        bool timerChange = false;
        int currentIndex = 0;

        string[] songs = { 
                             "http://tinakarol.ua/Albums/Smyl/money.mp3", 
                             "http://tinakarol.ua/Albums/Smyl/rboy.mp3",
                             "http://tinakarol.ua/Albums/Smyl/notenough.mp3",
                             "http://tinakarol.ua/Albums/Smyl/honey.mp3",
                             "http://tinakarol.ua/Albums/Smyl/loml.mp3",
                             "http://tinakarol.ua/Albums/Smyl/show.mp3",
                             "http://tinakarol.ua/Albums/Smyl/silent.mp3",
                             "http://tinakarol.ua/Albums/Smyl/honeyf.mp3",
                             "http://tinakarol.ua/Albums/Smyl/moneyr.mp3",
                             "http://tinakarol.ua/Albums/Smyl/showr.mp3",
                             "http://tinakarol.ua/Albums/Smyl/moneyc.mp3",
                             "http://tinakarol.ua/Albums/Smyl/above.mp3"
                         };

        public Show()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void StartSong(int index)
        {
            int currentIndex = index;
            string url = songs[currentIndex];
            night.Stop();

            if (currentSlider != null)
                currentSlider.Visibility = Visibility.Collapsed;

            if (currentControl != null)
                currentControl.Deactivate();
            currentControl = (SmylSong)SongsPanel.Children[index];

            currentSlider = (currentControl.Child as Grid).Children[1] as Slider;
            currentSlider.Visibility = Visibility.Visible;

            night.SetValue(MediaElement.SourceProperty, new Uri(url, UriKind.Absolute));
            night.MediaOpened += NightMediaLoaded;
            night.CurrentStateChanged += new RoutedEventHandler(night_CurrentStateChanged);

            currentControl.Activate();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentIndex = Convert.ToInt32((sender as Button).Tag) - 1; ;
            StartSong(currentIndex);
        }

        private void SmylSong_Stop(object sender, EventArgs e)
        {
            currentControl.Deactivate();
            currentSlider.Visibility = Visibility.Collapsed;
            currentSlider.Value = 0;
            night.Stop();
        }

        private void NightMediaLoaded(object sender, EventArgs e)
        {
            night.MediaOpened -= NightMediaLoaded;
            night.Play();
            currentSlider.Maximum = night.NaturalDuration.TimeSpan.TotalMilliseconds;


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += (s, ev) =>
            {
                lock (locker)
                {
                    currentSlider.Value = night.Position.TotalMilliseconds;
                    timerChange = true;
                }
            };

            currentSlider.ValueChanged += SliderValueChanged;
            currentSlider.AddHandler(FrameworkElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(SliderMouseDown), true);
            timer.Start();

        }

        private void SliderValueChanged(object sender, EventArgs e)
        {
            if (!timerChange)
            {
                Slider slider = sender as Slider;
                night.Position = TimeSpan.FromMilliseconds(slider.Value);
            }
        }

        private void SliderMouseDown(object sender, MouseEventArgs e)
        {

            lock (locker)
            {
                timerChange = false;
            }

            Slider slider = sender as Slider;
            Point point = e.GetPosition(slider);
            double position = (slider.Maximum * point.X) / slider.ActualWidth;
            slider.Value = position;
        }

        void night_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (night.CurrentState == MediaElementState.Stopped)
            {
                if (timer != null)
                    timer.Stop();
            }
        }
        
        private void night_MediaEnded(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if(currentIndex < songs.Length)
                StartSong(currentIndex);
        }
    }
}
