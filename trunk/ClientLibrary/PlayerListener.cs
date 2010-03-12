using System;
using Sys;
using Jquery;

namespace ClientLibrary
{
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

    public delegate void PlayerListenerCallback(PlayerListenerEventArgs e);

    public class PlayerListener : Component
    {
        private static PlayerListener instance;

        public static PlayerListener Instance
        {
            get { return PlayerListener.instance; }
        }

        public PlayerListener()
            : base()
        {
            instance = this;
        }

        public event PlayerListenerCallback PlayerPositionCanged
        {
            add { this.Events.AddHandler("positionChanged", value); }
            remove { this.Events.RemoveHandler("positionChanged", value); }
        }

        public PlayerProgressChangeCallback ProgressChangedHandler
        {
            get { return ProgressChanged; }
        }

        private void ProgressChanged(int loadPercent, int playedPercentRelative,
    int playedPercentAbsolute, int playedTime, int totalTime)
        {
            Script.Literal("debugger");
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
    }
}
