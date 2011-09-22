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

    public enum PlayerState
    { 
        Playing = 0, Paused = 1, Stopped = 2
    }

    public class PlayerListenerEventArgs : EventArgs
    {
        int loadPercent;
        int playedPercentRelative;
        int playedPercentAbsolute;
        int playedTime;
        int totalTime;

        public int LoadPercent
        {
            get { return loadPercent; }
            set { loadPercent = value; }
        }

        public int PlayedPercentRelative
        {
            get { return playedPercentRelative; }
            set { playedPercentRelative = value; }
        }

        public int PlayedPercentAbsolute
        {
            get { return playedPercentAbsolute; }
            set { playedPercentAbsolute = value; }
        }

        public int PlayedTime
        {
            get { return playedTime; }
            set { playedTime = value; }
        }

        public int TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }
    }

    public delegate void PlayerListenerCallback(object sender, PlayerListenerEventArgs e);

    public class AudioPlayer : Control, ILoadableComponent
    {
        private static AudioPlayer instance;

        public static AudioPlayer Instance
        {
            get { return AudioPlayer.instance; }
        }

        int currentSong = 0;

        PlayerState state;

        public PlayerState State
        {
            get { return state; }
            set { state = value; }
        }

        public int CurrentSong
        {
            get { return currentSong; }
            set { currentSong = value; }
        }

        public Array Songs
        {
            get { return GlobalMethods.GetSongs(); }
        }

        private AudioPlayer(DOMElement element)
            : base(element)
        {
            instance = this;
        }

        public event PlayerListenerCallback PlayerPositionCanged
        {
            add { this.Events.AddHandler("positionChanged", value); }
            remove { this.Events.RemoveHandler("positionChanged", value); }
        }

        public event EventHandler SongChanged
        {
            add { this.Events.AddHandler("songChanged", value); }
            remove { this.Events.RemoveHandler("songChanged", value); }
        }

        public PlayerProgressChangeCallback ProgressChangedHandler
        {
            get { return ProgressChanged; }
        }

        private void ProgressChanged(int loadPercent, int playedPercentRelative,
            int playedPercentAbsolute, int playedTime, int totalTime)
        {
            EventHandler handler = (EventHandler)this.Events.GetHandler("positionChanged");
            if (handler != null)
            {
                PlayerListenerEventArgs args = new PlayerListenerEventArgs();
                args.LoadPercent = loadPercent;
                args.PlayedPercentRelative = playedPercentRelative;
                args.PlayedPercentAbsolute = playedPercentAbsolute;
                args.PlayedTime = playedTime;
                args.TotalTime = totalTime;
                handler(this, args);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Element.Style.Height = "0px";
        }

        /// <summary>
        /// Member of ILoadableComponent. Occurs after page is loaded.
        /// </summary>
        public void OnLoad()
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

            JQueryProxy.jQuery(Element).jPlayer(options).OnProgressChange(this.ProgressChangedHandler);
        }

        void InitializeControls()
        {
            JQueryProxy.jQuery("#playerPresentation .controls a").click(ControlClick);
        }

        void SetInitialControlState()
        {
            ((DOMElement)((Array)(object)JQueryProxy.jQuery("a[rel='prev']"))[0]).ClassName = "disabled";

            if (Songs == null || Songs.Length == 0)
            {
                JQueryProxy.jQuery("#playerPresentation .controls a").addClass("disabled");
            }
            else if (Songs.Length == 1)
            {
                JQueryProxy.jQuery("a[rel='next']").addClass("disabled");
            }
        }

        void UpdateNavigationState()
        {
            if (Songs.Length <= currentSong + 1)
            {
                JQueryProxy.jQuery("a[rel='next']").addClass("disabled");
                JQueryProxy.jQuery("a[rel='prev']").removeClass("disabled");
            }
            if (currentSong == 0)
            {
                JQueryProxy.jQuery("a[rel='prev']").addClass("disabled");
                JQueryProxy.jQuery("a[rel='next']").removeClass("disabled");
            }
            if (currentSong > 0)
            {
                JQueryProxy.jQuery("a[rel='prev']").removeClass("disabled");
            }
            if (Songs.Length > currentSong + 1)
            {
                JQueryProxy.jQuery("a[rel='next']").removeClass("disabled");
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
            SetInitialControlState();
            if (Songs != null && Songs.Length > 0)
            {
                Dictionary firstSong = (Dictionary)Songs[0];
                if(!PageManager.Current.IsAuthenticated)
                    ((JPlayer)(Object)JQueryProxy.jQuery(Element)).SetFile((string)firstSong["url"]).Play();
                else
                    ((JPlayer)(Object)JQueryProxy.jQuery(Element)).SetFile((string)firstSong["url"]);
                UpdateSongTitle((string)firstSong["name"], (string)firstSong["album"]);
                JQueryProxy.jQuery("a[rel='play']").addClass("disabled");
            }
        }

        public void ChangeSong(string url)
        {
            ((JPlayer)JQueryProxy.jQuery(Element)).SetFile(url);
        }

        public void PlayHead(int percentOfLoaded)
        {
            ((JPlayer)JQueryProxy.jQuery(Element)).PlayHead(percentOfLoaded);
        }

        public void Play()
        {
            ((JPlayer)JQueryProxy.jQuery(Element)).Play();
            JQueryProxy.jQuery("a[rel='play']").addClass("disabled");
            JQueryProxy.jQuery("a[rel='pause']").removeClass("disabled");
            State = PlayerState.Playing;
        }

        public void Pause()
        {
            ((JPlayer)JQueryProxy.jQuery(Element)).Pause();
            JQueryProxy.jQuery("a[rel='play']").removeClass("disabled");
            JQueryProxy.jQuery("a[rel='pause']").addClass("disabled");
            State = PlayerState.Paused;
        }

        public void Stop()
        {
            ((JPlayer)JQueryProxy.jQuery(Element)).Stop();
            JQueryProxy.jQuery("a[rel='play'], a[rel='pause']").toggleClass("disabled");
            State = PlayerState.Stopped;
        }

        void Next()
        {
            currentSong++;
            UpdateNavigationState();
            Dictionary song = (Dictionary)Songs[currentSong];
            ChangeSong((string)song["url"]);
            UpdateSongTitle((string)song["name"], (string)song["album"]);
            Play();

            EventHandler handler = (EventHandler)this.Events.GetHandler("songChanged");
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        void Prev()
        {
            currentSong--;
            UpdateNavigationState();
            Dictionary song = (Dictionary)Songs[currentSong];
            ChangeSong((string)song["url"]);
            UpdateSongTitle((string)song["name"], (string)song["album"]);
            Play();

            EventHandler handler = (EventHandler)this.Events.GetHandler("songChanged");
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        void UpdateSongTitle(string name, string album)
        {
            Document.GetElementById("playerSongName").InnerHTML = name;
            //Document.GetElementById("playerAlbumName").InnerHTML = album;
        }
        #endregion

    }
}
