using System;
using Sys.UI;
using Jquery;
using System.DHTML;
using Sys;

namespace ClientLibrary
{
    public class AudioPlayer : Control
    {
        ObjectElement player = null;

        public AudioPlayer(DOMElement element) : base (element)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Element.Style.Height = "0px";
//            player = (ObjectElement)Element.FirstChild;
            Application.Load += new ApplicationLoadEventHandler(Application_Load);
        }

        void Application_Load(object sender, ApplicationLoadEventArgs e)
        {
            Window.SetTimeout(InitializePlayer, 4000);

  //          ChangeSong("http://localhost:1719/Songs/f.mp3");
          //  Window.SetTimeout(Play, 4000);
        }

        void InitializePlayer()
        {
            Script.Literal(@"
            $(document).ready(function(){
        $('#audioPlayer').jPlayer({
        ready: function() { $(this).setFile('http://localhost:1719/Songs/f.mp3').play(); },
            swfPath:'/Scripts'
        })
     })
            ");
            JPlayerOptions options = new JPlayerOptions();
            options.Ready = PlayerReady;
            options.Volume = 100;
            options.CssPrefix = "bla";
            options.SwfPath = "/Scripts";
            JQueryProxy.jQuery(Element).jPlayer(options);
        }

        void PlayerReady()
        {
            ((JPlayer)(Object)JQueryProxy.jQuery((DOMElement)(object)this)).SetFile("http://localhost:1719/Songs/f.mp3").Play();
        }

        ObjectElement GetPlayer()
        {
            return (ObjectElement)Document.GetElementById(Element.ID + "_player");
        }


        void ChangeSong(string url)
        {
            GetPlayer().SetVariable("method:setUrl", url);
        }

        void Play()
        {
            GetPlayer().SetVariable("method:play", "");
        }

        void Stop()
        {
            GetPlayer().SetVariable("method:stop", "");
        }


    }
}
