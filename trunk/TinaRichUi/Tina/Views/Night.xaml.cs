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

namespace Tina
{
    public partial class Night : Page
    {
        private bool mouseDown = false;
		private bool startDrag = false;
        int mouseY = 0;

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

        private void ScrollViewer_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	ScrollViewerAutomationPeer svAutomation = (ScrollViewerAutomationPeer)ScrollViewerAutomationPeer.CreatePeerForElement((ScrollViewer)sender);
			IScrollProvider scrollingAutomationProvider = (IScrollProvider)svAutomation.GetPattern(PatternInterface.Scroll); 

        }

        private void ScrollViewer_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	mouseDown = true;
            
        }

        private void ScrollViewer_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	mouseDown = false;
        }
    }
}
