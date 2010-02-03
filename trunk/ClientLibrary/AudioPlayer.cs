using System;
using Sys.UI;
using Jquery;
using System.DHTML;
using Sys;

namespace ClientLibrary
{
    [Imported]
    [IgnoreNamespace]
    [GlobalMethods]
    class GlobalMethods
    {
        public static Array GetSongs() { return null; }
    }

    public class AudioPlayer : Control
    {
        int currentSong = 0;

        public Array Songs
        {
            get { return GlobalMethods.GetSongs(); }
        }

        public AudioPlayer(DOMElement element)
            : base(element)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Element.Style.Height = "0px";
            Application.Load += new ApplicationLoadEventHandler(Application_Load);
        }

        void Application_Load(object sender, ApplicationLoadEventArgs e)
        {
            InitializePlayer();
            InitializeControls();
        }

        void InitializePlayer()
        {
            JPlayerOptions options = new JPlayerOptions();
            options.Ready = PlayerReady;
            options.Volume = 100;
            options.SwfPath = "/Scripts";
            JQueryProxy.jQuery(Element).jPlayer(options);
        }

        void InitializeControls()
        {
            JQueryProxy.jQuery("#playerPresentation .controls a").click(ControlClick);
        }

        void SetInitialControlState()
        {
            if (Songs == null || Songs.Length == 0)
            {
                JQueryProxy.jQuery("#playerPresentation .controls a").addClass("disabled");
            }
            else if (Songs.Length == 1)
            {
                JQueryProxy.jQuery("a[rel='prev'], a[rel='next']").addClass("disabled");
            }
        }

        BasicCallback ControlClick(object rawEvent, object stub)
        {
            Event evt = (Event)rawEvent;
            DOMElement srcElement = evt.SrcElement;
            if (srcElement == null)
            {
                srcElement = (DOMElement)Type.GetField(evt, "target");
            }
            DOMElement target = (srcElement.TagName == "IMG") ? srcElement.ParentNode : srcElement;
            bool disabled = target.ClassName == "disabled";
            if (!disabled)
            {
                string operation = (string)target.GetAttribute("rel");
                switch (operation)
                {
                    case "play":
                        Play();
                        break;
                    case "pause":
                        Pause();
                        break;
                    case "prev":
                        Prev();
                        break;
                    case "next":
                        Next();
                        break;
                }
            }
            return null;
        }

        #region Player controls
        void PlayerReady()
        {
            if (Songs != null && Songs.Length > 0)
            {
                Dictionary firstSong = (Dictionary)Songs[0];
                ((JPlayer)(Object)JQueryProxy.jQuery(Element)).SetFile((string)firstSong["url"]).Play();
                UpdateSongTitle((string)firstSong["name"], (string)firstSong["album"]);
                JQueryProxy.jQuery("a[rel='play']").addClass("disabled");
            }
        }

        void ChangeSong(string url)
        {
            ((JPlayer)(Object)JQueryProxy.jQuery(Element)).SetFile(url);
        }

        void Play()
        {
            ((JPlayer)(Object)JQueryProxy.jQuery(Element)).Play();
            JQueryProxy.jQuery("a[rel='play'], a[rel='pause']").toggleClass("disabled");
        }

        void Pause()
        {
            ((JPlayer)(Object)JQueryProxy.jQuery(Element)).Pause();
            JQueryProxy.jQuery("a[rel='play'], a[rel='pause']").toggleClass("disabled");
        }

        void Stop()
        {
            ((JPlayer)(Object)JQueryProxy.jQuery(Element)).Stop();
            JQueryProxy.jQuery("a[rel='play'], a[rel='pause']").toggleClass("disabled");
        }

        void Next()
        {
            Stop();
            currentSong++;
            if (Songs.Length <= currentSong + 1)
            {
                JQueryProxy.jQuery("a[rel='next']").addClass("disabled");
                JQueryProxy.jQuery("a[rel='prev']").removeClass("disabled");
            }
            Dictionary song = (Dictionary)Songs[currentSong];
            ChangeSong((string)song["url"]);
            UpdateSongTitle((string)song["name"], (string)song["album"]);
            Play();

        }

        void Prev()
        {
            Stop();
            currentSong--;
            if (currentSong == 0)
            {
                JQueryProxy.jQuery("a[rel='prev']").addClass("disabled");
                JQueryProxy.jQuery("a[rel='next']").removeClass("disabled");
            }
            Dictionary song = (Dictionary)Songs[currentSong];
            ChangeSong((string)song["url"]);
            UpdateSongTitle((string)song["name"], (string)song["album"]);
            Play();
        }

        void UpdateSongTitle(string name, string album)
        {
            Document.GetElementById("playerSongName").InnerHTML = name;
            Document.GetElementById("playerSongName").InnerHTML = album;
        }
        #endregion

    }
}
