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
using System.Windows.Markup;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace Tina.Controls.Pages
{
    public partial class Page : UserControl
    {
        // Fields
        private int _currentDownload = -1;
        private NavigationManager _navigationManager;
        private int _numPages;
        private PageGenerator _pageGenerator;
        private List<PageInfo> _pages;
        private WebClient _webClient;

        // Methods
        public Page()
        {
            this.InitializeComponent();
        }

        private void AddEvenPages()
        {
            int num;
            string str = "<Canvas x:Name='page0$0' xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>";
            str = (((((((str + "  <Canvas.Clip>") + "    <PathGeometry>" + "      <PathFigure>") + "        <LineSegment Point='0,0'/>" + "        <LineSegment Point='0, 570'/>") + "        <LineSegment x:Name='page$0Point1' Point='420, 570'/>" + "        <LineSegment x:Name='page$0Point2' Point='420, 570'/>") + "        <LineSegment x:Name='page$0Point3' Point='420, 0'/>" + "        <LineSegment Point='0,0'/>") + "      </PathFigure>" + "    </PathGeometry>") + "  </Canvas.Clip>" + "  $1") + "  $2" + "</Canvas>";
            string newValue = "  <Rectangle Height='570' Width='30' Opacity='1'>";
            newValue = (((newValue + "    <Rectangle.Fill>") + "      <LinearGradientBrush StartPoint='0,0' EndPoint='1,0'>" + "        <GradientStop Color='#80202020' Offset='0'/>") + "        <GradientStop Color='#00A0A0A0' Offset='1'/>" + "      </LinearGradientBrush>") + "    </Rectangle.Fill>" + "  </Rectangle>";
            if (Utils.IsEven(this._numPages))
            {
                num = this._numPages;
            }
            else
            {
                num = this._numPages - 1;
            }
            for (int i = num; i >= 0; i -= 2)
            {
                string xaml = str.Replace("$0", Utils.GetTwoDigitInt(i)).Replace("$1", this._pageGenerator.GetPageString(i));
                if (i == 0)
                {
                    xaml = xaml.Replace("$2", "");
                }
                else
                {
                    xaml = xaml.Replace("$2", newValue);
                }
                Canvas canvas = (Canvas)XamlReader.Load(xaml);
                this.evenPageCanvas.Children.Add(canvas);
                this._pages[i].Canvas = canvas;
            }
        }

        private void AddOddPages()
        {
            int num;
            string str = "<Canvas x:Name='page0$0' Cursor='Hand' xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>";
            str = ((((((((((((((((str + "  <Canvas.RenderTransform>") + "    <TransformGroup>" + "      <RotateTransform x:Name='page$0Rotate' CenterX='0' CenterY='570' Angle='0'/>") + "      <TranslateTransform x:Name='page$0Translate' X='0' Y='0'/>" + "    </TransformGroup>") + "  </Canvas.RenderTransform>" + "  <Canvas.Clip>") + "    <PathGeometry>" + "      <PathFigure>") + "        <LineSegment Point='0,570'/>" + "        <LineSegment x:Name='page$0Point1' Point='0, 570'/>") + "        <LineSegment x:Name='page$0Point2' Point='0, 570'/>" + "        <LineSegment x:Name='page$0Point3' Point='0, 570'/>") + "        <LineSegment Point='0,570'/>" + "      </PathFigure>") + "    </PathGeometry>" + "  </Canvas.Clip>") + "  $1" + "  <Rectangle Height='1000' Width='20' Opacity='0.6' x:Name='page$0FoldShadow'>") + "    <Rectangle.RenderTransform>" + "      <TransformGroup>") + "        <RotateTransform x:Name='page$0FoldShadowRotate' CenterX='0' CenterY='0' Angle='0'/>" + "        <TranslateTransform x:Name='page$0FoldShadowTranslate' X='0' Y='0'/>") + "      </TransformGroup>" + "    </Rectangle.RenderTransform>") + "    <Rectangle.Fill>" + "      <LinearGradientBrush StartPoint='0,0' EndPoint='1,0'>") + "        <GradientStop Color='#00000000' Offset='0'/>" + "        <GradientStop Color='#FF000000' Offset='1'/>") + "      </LinearGradientBrush>" + "    </Rectangle.Fill>") + "  </Rectangle>" + "</Canvas>";
            if (Utils.IsEven(this._numPages))
            {
                num = this._numPages - 1;
            }
            else
            {
                num = this._numPages;
            }
            for (int i = 1; i <= num; i += 2)
            {
                Canvas canvas = (Canvas)XamlReader.Load(str.Replace("$0", Utils.GetTwoDigitInt(i)).Replace("$1", this._pageGenerator.GetPageString(i)));
                canvas.MouseLeftButtonDown += new MouseButtonEventHandler(this._navigationManager.newOddPage_MouseLeftButtonDown);
                canvas.MouseLeftButtonUp += new MouseButtonEventHandler(this._navigationManager.newOddPage_MouseLeftButtonUp);
                canvas.MouseMove += new MouseEventHandler(this._navigationManager.newOddPage_MouseMove);
                this.oddPageCanvas.Children.Add(canvas);
                this._pages[i].Canvas = canvas;
            }
        }

        private void DownloadAssets()
        {
            this._webClient = new WebClient();
            this.progressText.Text = "Downloading: pageContent.xml";
            this._webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(this.DownloadAssets_OpenReadCompleted);
            this._webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.DownloadAssets_DownloadProgressChanged);
            this._webClient.OpenReadAsync(new Uri("pageContent.xml", UriKind.Relative));
        }

        private void DownloadAssets_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressRect.Width = (e.ProgressPercentage * 450) / 100;
        }

        private void DownloadAssets_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this._currentDownload++;
            if (this._currentDownload <= this._numPages)
            {
                this.progressText.Text = "Downloading: " + this._pages[this._currentDownload].Path;
                this.progressRect.Width = 0.0;
                this._webClient.DownloadStringAsync(new Uri(this._pages[this._currentDownload].Path, UriKind.Relative));
            }
            else
            {
                this.fadeDownloadUI.Begin();
                this.downloadUI.IsHitTestVisible = false;
                this.AddOddPages();
                this.AddEvenPages();
                this.shadowBehindPageNN.Opacity = 0.8;
                this._navigationManager.BeginPageAnimation("showFold");
            }
        }

        private void DownloadAssets_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            StreamReader textReader = new StreamReader(e.Result);
            IEnumerable<PageInfo> collection = XDocument.Load(textReader).Descendants("page").Select<XElement, PageInfo>(delegate(XElement m)
            {
                return new PageInfo { Path = m.Attribute("path").Value, Title = m.Attribute("title").Value, Subtitle = m.Attribute("subtitle").Value, Foreground = m.Attribute("foreground").Value };
            });
            this._pages = new List<PageInfo>();
            this._pages.AddRange(collection);
            this._numPages = this._pages.Count<PageInfo>() - 1;
            this._webClient.OpenReadCompleted -= new OpenReadCompletedEventHandler(this.DownloadAssets_OpenReadCompleted);
            this._webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(this.DownloadAssets_DownloadStringCompleted);
            this.DownloadAssets_DownloadStringCompleted(null, null);
            this._navigationManager = new NavigationManager(this._numPages, this);
            new PageBrowserControl(this, this.pageBrowserControl, this._pageGenerator, this._navigationManager, this._numPages);
        }

        public Canvas GetPageCanvas(int pageNumber)
        {
            return this._pages[pageNumber].Canvas;
        }

        public int GetPageCount()
        {
            return this._pages.Count;
        }

        public string GetPageForeground(int pageNumber)
        {
            return this._pages[pageNumber].Foreground;
        }

        public string GetPagePath(int pageNumber)
        {
            return this._pages[pageNumber].Path;
        }

        public string GetPageSubtitle(int pageNumber)
        {
            return this._pages[pageNumber].Subtitle;
        }

        public string GetPageTitle(int pageNumber)
        {
            return this._pages[pageNumber].Title;
        }


        private void MainCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            this._pageGenerator = new PageGenerator(this);
            this.DownloadAssets();
        }
    }


}
