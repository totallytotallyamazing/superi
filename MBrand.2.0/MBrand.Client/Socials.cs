// Socials.cs
//

using System;
using System.Collections.Generic;
using MBrand.Client.Pages;
using System.Html;
using jQueryApi;
using System.Collections;

namespace MBrand.Client
{
    public class Socials
    {
        private static string GetUrl()
        {
            return "http://eugene-miller.com/" + Window.Location.Hash;
        }

        private static void UpdateFacebook()
        {
            try
            {
                string url = GetUrl();
                jQueryObject elem = jQuery.FromElement(Document.CreateElement("fb:like"));
                Dictionary attributes = new Dictionary();
                attributes["href"] = url;
                attributes["send"] = false;
                attributes["layout"] = "button_count";
                attributes["show_faces"] = false;
                elem.Attribute(attributes);
                //<fb:like href="http://www.asas.com" send="false" layout="button_count" width="450" show_faces="false"></fb:like>
                jQuery.Select("div#likeContainer").Empty().Append(elem);
                Script.Literal("FB.XFBML.parse($('div#Container').get(0))");
            }
            catch (Exception) { }
        }

        private static void UpdateVK()
        {
            jQuery.Select(".vk-share").Html((string)Script.Literal("VK.Share.button(false, {type:'button', text: '&hearts;'})"));
        }

        private static void UpdateTwitter()
        {
            jQuery.Select(".twitter-share-button").Attribute("data-href", GetUrl());
            Script.Literal("twttr.widgets.load()");
        }

        private static void UpdatePlusOne()
        {
            jQuery.Select("#plusOne").Empty().Append(jQuery.FromElement(Document.CreateElement("g:plusone")).Attribute("size", "medium"));
            Script.Literal("gapi.plusone.go()");
        }

        public static void Bind()
        {
            Page.PageChanged += delegate
                              {
                                  UpdateFacebook();
                                  UpdateVK();
                                  UpdateTwitter();
                                  UpdatePlusOne();
                              };
        }

    }
}
