﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Pandemiia.Models;
using System.Threading;

namespace Pandemiia.Helpers
{
    public static class YoutubeVerifier
    {
        public static bool Queried { get; set; }

        public static int Status { get; set; }

        public static List<EntityVideoPresentation> Result { get; set; }

        static YoutubeVerifier()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Queried = false;
            Result = new List<EntityVideoPresentation>();
            Status = 0;
        }

        public static void RunVerification()
        {
            Initialize();
            Thread thread = new Thread(VerificationProcess);
            thread.Start();
        }

        private static void VerificationProcess()
        {
            List<EntityVideoPresentation> videos = new List<EntityVideoPresentation>();
            using (EntitiesDataContext context = new EntitiesDataContext())
            {
                videos = context.EntityVideos.Select(v => new EntityVideoPresentation 
                { 
                    Id = v.ID,
                    EntityName = v.Entity.Title,
                    Name = v.Name,
                    Source = v.Source
                }).ToList();
            }

            int length = videos.Count;
            for (int i = 0; i < length; i++)
            {
                if (!CheckVideo(videos[i].Source))
                    Result.Add(videos[i]);
                double part = ((double)i / (double)length);
                Status = (int)Math.Floor(part * 100);
                Thread.Sleep(5000);
            }
            Queried = true;
            Thread.CurrentThread.Abort();
        }

        private static bool CheckVideo(string objectTag)
        {
            bool result = true;
            Regex regex = new Regex("/v/([^\\&^\"]+?)\\&hl");
            Match match = regex.Match(objectTag);
            if (match.Success)
            {
                string videoId = match.Groups[1].Value;
                result = QueryYoutube(videoId);
            }
            return result;
        }

        private static bool QueryYoutube(string videoId)
        {
            bool result = true;
            Uri uri = new Uri("http://gdata.youtube.com/feeds/api/videos/" + videoId);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            string responseString = "<?xml version='1.0'";
            webRequest.Method = "GET";
            StreamReader reader = null;
            WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            catch (Exception exception)
            {
                if (exception.Message.IndexOf("404") > -1)
                    responseString = "";
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                reader = null;
                if (response != null)
                    response.Close();
                response = null;
            }
            result = (responseString.IndexOf("<?xml version='1.0'") > -1);
            return result;
        }
    }
}
