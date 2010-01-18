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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tina
{
    public partial class MainPage : UserControl
    {
        string prevPage = "/Home";
        Dictionary<string, Color> pageColor = new Dictionary<string, Color>();
        Dictionary<string, Storyboard> pageBoard = new Dictionary<string, Storyboard>();

        public MainPage()
        {
            InitializeComponent();
            pageColor["/Home"] = Colors.Black;
            pageColor["/Night"] = Colors.Black;
            pageColor["/Show"] = Color.FromArgb(255, 115, 115, 115);
            pageColor["/Polus"] = Colors.White;

        }

        private Storyboard PrepareStoryboard(string from, string to)
        {
            string boardKey = from.Replace("/", "") + "_" + to.Replace("/", "");

            if (!pageBoard.ContainsKey(boardKey))
            {
                Storyboard storyboard = new Storyboard();
                Duration duration = new Duration(TimeSpan.FromMilliseconds(300));

                ColorAnimationUsingKeyFrames animation = new ColorAnimationUsingKeyFrames();

                EasingColorKeyFrame frameFrom = new EasingColorKeyFrame();
                frameFrom.KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero);
                frameFrom.Value = pageColor[from];
                EasingColorKeyFrame frameTo = new EasingColorKeyFrame();
                frameTo.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300));
                frameTo.Value = pageColor[to];

                animation.KeyFrames.Add(frameFrom);
                animation.KeyFrames.Add(frameTo);
                animation.BeginTime = TimeSpan.Zero;

                storyboard.Children.Add(animation);
                Storyboard.SetTarget(animation, ContentBorder);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));

                pageBoard[boardKey] = storyboard;

                LayoutRoot.Resources.Add(boardKey, storyboard);
            }
            return pageBoard[boardKey];
        }

        // After the Frame navigates, ensure the HyperlinkButton representing the current page is selected
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (UIElement child in LinksStackPanel.Children)
            {
                HyperlinkButton hb = child as HyperlinkButton;
                if (hb != null && hb.NavigateUri != null)
                {
                    if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
                    {
                        VisualStateManager.GoToState(hb, "ActiveLink", true);
                        hb.IsEnabled = false;
                    }
                    else
                    {
                        VisualStateManager.GoToState(hb, "InactiveLink", true);
                        hb.IsEnabled = true;
                    }
                }
            }
            NavigatedBoard.Begin();
            PrepareStoryboard(prevPage, e.Uri.ToString()).Begin();
            prevPage = e.Uri.ToString();
			
        }

        // If an error occurs during navigation, show an error window
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ChildWindow errorWin = new ErrorWindow(e.Uri);
            errorWin.Show();
        }

        private void ContentFrame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
//            VisualStateManager.GoToState(this, "Navigating", true);
        }

        private void Link3_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
          //  string path = ((Button)sender).Tag.ToString();
    //        Uri uri = new Uri(path, UriKind.Relative);
//            NavigatingBoard.Completed += (board, eventArgs) => {
      //          ContentFrame.Navigate(uri);
        //    };
  //          NavigatingBoard.Begin();
        }
    }
}