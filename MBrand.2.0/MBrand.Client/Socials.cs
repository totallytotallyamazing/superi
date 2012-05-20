// Socials.cs
//

using System;
using System.Collections.Generic;
using MBrand.Client.Pages;
using System.Html;
using jQueryApi;
using System.Collections;
using System.Runtime.CompilerServices;

namespace MBrand.Client
{
    public class Socials
    {
        private static string GetUrl()
        {
            return "http://eugene-miller.com/" + Window.Location.Hash;
        }


        private static void UpdateFacebook(bool secret, int id)
        {
            try
            {
                string url = GetUrl();
                if (secret)
                {
                    url += "/" + id;
                }
                jQueryObject elem = jQuery.FromElement(Document.CreateElement("fb:like"));
                Dictionary attributes = new Dictionary();
                attributes["href"] = url;
                attributes["send"] = false;
                attributes["layout"] = "button_count";
                attributes["show_faces"] = false;
                elem.Attribute(attributes);
                jQuery.Select("div#likeContainer").Empty().Append(elem);
                Script.Literal("FB.XFBML.parse($('div#Container').get(0))");
            }
            catch (Exception) { }
        }

        private static void UpdateVK(bool secret, int id)
        {
            jQuery.Select(".vk-share").Empty().Html((string)Script.Literal("VK.Share.button(false, {type:'button', text: '&hearts;'})"));
        }

        private static void UpdateTwitter(bool secret, int id)
        {
            try
            {
                jQuery.Select(".twitter-share-button").Attribute("data-href", GetUrl());
                Script.Literal("twttr.widgets.load()");
            }
            catch { /*whatever*/ }
        }

        private static void UpdatePlusOne(bool secret, int id)
        {
            jQuery.Select("#plusOne").Empty().Append(jQuery.FromElement(Document.CreateElement("g:plusone")).Attribute("size", "medium"));
            Script.Literal("gapi.plusone.go()");
        }

        public static void Bind()
        {
            Page.PageChanged += delegate { UpdateAll(false, 0); };
        }

        [PreserveCase]
        public static void UpdateAll(bool secret, int id)
        {
            UpdateFacebook(secret, id);
            UpdateVK(secret, id);
            UpdateTwitter(secret, id);
            UpdatePlusOne(secret, id);
        }
    }
}
