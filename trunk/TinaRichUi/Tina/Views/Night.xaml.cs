using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Tina
{
    public partial class Night : Page
    {
        SongControl currentControl = null;
        Slider currentSlider = null;
        DispatcherTimer timer = null;
        object locker = new object();
        bool timerChange = false;
        int currentIndex = 0;

        string[] songs = { 
                             "http://tinakarol.ua/Albums/Night/night.mp3", 
                             "http://tinakarol.ua/Albums/Night/high.mp3",
                             "http://tinakarol.ua/Albums/Night/draw.mp3",
                             "http://tinakarol.ua/Albums/Night/pups.mp3",
                             "http://tinakarol.ua/Albums/Night/let.mp3",
                             "http://tinakarol.ua/Albums/Night/highr.mp3",
                         };

        public Night()
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
            currentControl = (SongControl)SongsPanel.Children[index];

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

        void night_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (night.CurrentState == MediaElementState.Stopped)
            {
                if (timer != null)
                    timer.Stop();
            }
        }

        private void Video_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ChildWindow videoDilog = new ShowVideo((sender as Button).Tag.ToString());
            videoDilog.Show();
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

        private void SongControl_Stop(object sender, EventArgs e)
        {
            currentControl.Deactivate();
            currentSlider.Visibility = Visibility.Collapsed;
            currentSlider.Value = 0;
            night.Stop();
        }

        private void night_MediaEnded(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex < songs.Length)
                StartSong(currentIndex);
        }

    }
}
