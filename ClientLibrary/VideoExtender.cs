using System;
using Jquery;
using System.DHTML;

namespace ClientLibrary
{
    public class VideoExtender : PageExtender
    {
        DOMElement current = null;

        protected override void ContentUpdated(object sender, Sys.EventArgs e)
        {
            base.ContentUpdated(sender, e);
            Init();
        }

        protected override void ContentUpdating(object sender, Sys.EventArgs e)
        {
            Cleanup();
            base.ContentUpdating(sender, e);
            this.Dispose();
        }


        void Init()
        {
            AudioPlayer.Instance.Pause();
            JQueryProxy.jQuery("#content").css("padding", "0");
            JQueryProxy.jQuery("#clipThumbnails .thumbnail").click((BasicCallback)Click);
            JQueryProxy.jQuery("#clipThumbnails .thumbnail").mouseover((BasicCallback)ThumbnailOver);
            JQueryProxy.jQuery("#clipThumbnails .thumbnail").mouseout((BasicCallback)ThumbnailOut);

            JQueryProxy.jQuery("#clipThumbnails .thumbnail").eq(0).click();
        }

        void Cleanup()
        {
            JQueryProxy.jQuery("#content").css("padding", "");
            JQueryProxy.jQuery("#clipThumbnails .thumbnail").unbind("click", null).unbind("mouseover", null).unbind("mouseout", null);
            AudioPlayer.Instance.Play();
        }

        Object ThumbnailOver(object rawEvent, object ui)
        {
            DOMElement target = (DOMElement)Type.GetField(rawEvent, "target");
            JQueryProxy.jQuery(target).addClass("hover");
            return null;
        }

        Object ThumbnailOut(object rawEvent, object ui)
        {
            DOMElement target = (DOMElement)Type.GetField(rawEvent, "target");
            JQueryProxy.jQuery(target).removeClass("hover");
            return null;
        }

        Object Click(object rawEvent, object ui)
        {
            DOMElement target = (DOMElement)Type.GetField(rawEvent, "target");
            if (target.TagName != "DIV")
            {
                target = target.ParentNode;
            }

            

            JQueryProxy.jQuery(target)
                .unbind("mouseover", null)
                .unbind("click", null)
                .removeClass("hover")
                .addClass("current");

            string title = JQueryProxy.jQuery(target).children("p.title").html();
            string description = JQueryProxy.jQuery(target).children("p.clipDescription").html();

            JQueryProxy.jQuery("#clipDetails h1").html(title);
            JQueryProxy.jQuery("#clipDetails p").html(description);

            string source = ((InputElement)target.GetElementsByTagName("input")[0]).Value;
            JQueryProxy.jQuery("#clip").fadeTo("slow", 10, 
                delegate(object a, object b) 
                { 
                    JQueryProxy.jQuery("#clip").html(source); 
                    JQueryProxy.jQuery("#clip").fadeIn("slow", null); 
                    return null; 
                });
            
            
            JQueryProxy.jQuery(current).removeClass("current").mouseover((BasicCallback)ThumbnailOver).click((BasicCallback)Click);

            current = target;
            return null;
        }
    }
}
