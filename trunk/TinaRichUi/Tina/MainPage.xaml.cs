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
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace Tina
{
    public partial class MainPage : UserControl
    {
        string prevPage = "/Home";
        Dictionary<string, Color> pageColor = new Dictionary<string, Color>();
        Dictionary<string, Storyboard> pageBoard = new Dictionary<string, Storyboard>();
        Dictionary<string, string> navigationStyles = new Dictionary<string, string>();

        public MainPage()
        {
            InitializeComponent();
            pageColor["/Home"] = Colors.Black;
            pageColor["/Night"] = Colors.Black;
            pageColor["/Show"] = Color.FromArgb(255, 115, 115, 115);
            pageColor["/Polus"] = Colors.White;

            navigationStyles["/Home"] = "LinksStackPanelStyle";
            navigationStyles["/Night"] = "NightNavigationStyle";
            navigationStyles["/Show"] = "ShowNavigationStyle";
            navigationStyles["/Polus"] = "PolusNavigationStyle";
        }


        private void ScrollViewer_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {

            ScrollViewerAutomationPeer svAutomation = (ScrollViewerAutomationPeer)ScrollViewerAutomationPeer.CreatePeerForElement((ScrollViewer)sender);
            IScrollProvider scrollingAutomationProvider = (IScrollProvider)svAutomation.GetPattern(PatternInterface.Scroll);
            if (scrollingAutomationProvider.VerticallyScrollable)
            {
                if (e.Delta > 0)
                {
                    // content goes down:
                    scrollingAutomationProvider.Scroll(ScrollAmount.NoAmount, ScrollAmount.LargeDecrement);
                }
                else
                {
                    // content goes up:
                    scrollingAutomationProvider.Scroll(ScrollAmount.NoAmount, ScrollAmount.LargeIncrement);
                }
            }
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
            HyperlinkButton current = null;

            foreach (UIElement child in LinksStackPanel.Children)
            {
                HyperlinkButton hb = child as HyperlinkButton;
                if (hb != null && hb.NavigateUri != null)
                {
                    if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
                    {
                        VisualStateManager.GoToState(hb, "ActiveLink", true);
                        hb.IsEnabled = false;
                        current = hb;
                    }
                    else
                    {
                        VisualStateManager.GoToState(hb, "InactiveLink", true);
                        hb.IsEnabled = true;
                    }
                }
            }

            if (current != null)
            {
                LinksStackPanel.Children.Remove(current);
                LinksStackPanel.Children.Insert(0, current);
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
            LinksStackPanel.Style = (Style)Resources[navigationStyles[e.Uri.ToString()]];
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