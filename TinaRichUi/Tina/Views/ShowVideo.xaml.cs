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
        bool eventAttached = false;
        string url = "";
        public ShowVideo()
        {
            InitializeComponent();
        }

        public ShowVideo(string url)
        {
            this.url = url;
            //this.Style = (Style)Resources["ChildWindowStyle1"];
        }

        private void ChildWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            mediaElement.SetValue(MediaElement.SourceProperty, new Uri(url, UriKind.Absolute));
            if(!eventAttached)
            {
                mediaElement.MediaOpened += (source, ev) => { mediaElement.Play(); };
                eventAttached = true;
            }
        }
    }
}

