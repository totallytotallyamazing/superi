using System;
using Sys;
using Jquery;
using System.DHTML;

namespace ClientLibrary
{
    public class AlbumExtender : PageExtender
    {
        string currentId = "";

        JQuery currentSlider = null;

        public AlbumExtender() : base()
        {

        }

        protected override void ContentUpdated(object sender, EventArgs e)
        {
            JQueryProxy.jQuery("#content").css("padding", "0");
            AudioPlayer.Instance.PlayerPositionCanged += PlayerPositionCanged;
            AudioPlayer.Instance.SongChanged += SongChanged;
            InitializePlayers();

            base.ContentUpdated(sender,  e);
        }

        void SongChanged(object sender, EventArgs e)
        {
            OpenCurrentSong();
        }

        void PlayerPositionCanged(object sender, PlayerListenerEventArgs e)
        {
            currentSlider.Slider("option", "value", e.PlayedPercentAbsolute); 
        }

        protected override void ContentUpdating(object sender, EventArgs e)
        {
            JQueryProxy.jQuery("#content").css("padding", "");
            AudioPlayer.Instance.PlayerPositionCanged -= PlayerPositionCanged;
            AudioPlayer.Instance.SongChanged -= SongChanged;
            base.ContentUpdating(sender, e);
            this.Dispose();
        }

        void InitializePlayers()
        {
            Dictionary options = new Dictionary();
            options["max"] = 100;
            options["range"] = "min";
            options["animate"] = false;
            options["slide"] = (BasicCallback)Slide;

            JQueryProxy.jQuery(".song .player").Slider(options);
            JQueryProxy.jQuery(".songTitle").click((BasicCallback)TitleClick);
         
            OpenCurrentSong();
        }

        void OpenCurrentSong()
        {
            Array songs = AudioPlayer.Instance.Songs;

            if (AudioPlayer.Instance.State == PlayerState.Playing)
            {
                Dictionary song = (Dictionary)songs[AudioPlayer.Instance.CurrentSong];
                string id = (string)song["id"];
               
                JQueryProxy.jQuery(".player").not(".player[rel='" + id + "']").hide();
                currentSlider = JQueryProxy.jQuery(".player[rel='" + id + "']").show();
                currentSlider.Slider("option", "value", 0);
                currentId = id;
            }
        }

        Object Slide(Object rawEvent, Object ui)
        {
            AudioPlayer.Instance.PlayHead((int)Type.GetField(ui, "value"));
            JQueryProxy.jQuery("a").blur();
            return null;
        }

        Object TitleClick(Object rawEvent, Object ui)
        {
            Event evt = (Event)rawEvent;
            DOMElement element = (DOMElement)Type.GetField(evt, "target");
            string id = (string)element.GetAttribute("rel");

            if (id != currentId)
            {

                Array songs = AudioPlayer.Instance.Songs;
                int length = songs.Length;

                for (int i = 0; i < length; i++)
                {
                    Dictionary song = (Dictionary)songs[i];
                    if ((string)song["id"] == id)
                    {
                        AudioPlayer.Instance.CurrentSong = i;
                        AudioPlayer.Instance.ChangeSong((string)song["url"]);
                        AudioPlayer.Instance.Play();
                        break;
                    }
                }

                JQueryProxy.jQuery(".player").not(".player[rel='" + id + "']").hide();
                currentSlider = JQueryProxy.jQuery(".player[rel='" + id + "']").show();
                currentSlider.Slider("option", "value", 0);
                currentId = id;
            }
            else
            {
                AudioPlayer.Instance.Stop();
                JQueryProxy.jQuery(".player").hide();
            }
            return null;
        }
    }
}
