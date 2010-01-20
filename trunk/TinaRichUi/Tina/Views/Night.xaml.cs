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

namespace Tina
{
    public partial class Night : Page
    {
		SongControl currentControl = null;
		string currentSong = null;
        bool eventBinded = false;
		
        public Night()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string url = (sender as Button).Tag.ToString();
            night.Stop();
            if (currentControl != null)
                currentControl.Deactivate();
            currentControl = ControlFinder.FindParent<SongControl>((sender as Button));
            
            if (url != currentSong)
            {
                night.SetValue(MediaElement.SourceProperty, new Uri(url, UriKind.Absolute));
                if (!eventBinded)
                {
                    night.MediaOpened += (source, ev) => { night.Play(); };
                    eventBinded = true;
                }
                currentControl.Activate();
                currentSong = url;
            }
            else
            {
                currentSong = null;
            }
        }
    }
}
