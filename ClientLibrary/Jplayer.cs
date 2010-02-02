using System;

namespace Jquery
{
    public class JPlayerOptions
    {
        public Callback Ready;
        public string SwfPath;
        public string CssPrefix;
        public int Volume;
    }

    [Imported]
    public class JPlayer
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

        public JPlayer OnSoundComplete(Callback callback)
        {
            return null;
        }
    }

    public partial class JQuery
    {
        public JQuery jPlayer(JPlayerOptions options)
        {
            return null;
        }
    }
}
