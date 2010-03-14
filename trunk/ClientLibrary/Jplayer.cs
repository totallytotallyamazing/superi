using System;

namespace Jquery
{
    public class JPlayerOptions
    {
        public Callback Ready;
        public string SwfPath;
        public string CssPrefix;
        public int Volume;
        public PlayerProgressChangeCallback PlayerProgressChange;
    }

    /// <summary>
    /// This method is used to define a function that takes 5 parameters and is executed every time 
    /// the plugin updates the progress of the load bar or play bar. 
    /// This event occurs every 100ms when an MP3 [or OGG] file is playing. 
    /// </summary>
    /// <param name="loadPercent">Number (0 to 100) defining the percentage downloaded</param>
    /// <param name="playedPercentRelative">Number (0 to 100) defining the percentage played when compared to the percentage downloaded.</param>
    /// <param name="playedPercentAbsolute">Number (0 to 100) defining the the current play position in percentage</param>
    /// <param name="playedTime">Number defining the current play position in milliseconds</param>
    /// <param name="totalTime">Number defining the total play time in milliseconds</param>
    public delegate void PlayerProgressChangeCallback(int loadPercent, int playedPercentRelative, 
    int playedPercentAbsolute, int playedTime, int totalTime);

    [Imported]
    public class JPlayer : JQuery
    {
        public JPlayer SetFile(string mp3)
        {
            return null;
        }

        public JPlayer Play()
        {
            return null;
        }
        public JPlayer Pause()
        {
            return null;
        }
        public JPlayer Stop()
        {
            return null;
        }

        public JPlayer Volume(int percent)
        {
            return null;
        }

        public JPlayer PlayHead(int percentOfLoaded)
        {
            return null;
        }

        public JPlayer PlayHeadTime(int playedTime)
        {
            return null; 
        }

        public JPlayer OnSoundComplete(Callback callback)
        {
            return null;
        }

        public JPlayer OnProgressChange(PlayerProgressChangeCallback callback)
        {
            return null;
        }
    }

    public partial class JQuery
    {
        public JPlayer jPlayer(JPlayerOptions options)
        {
            return null;
        }
    }
}