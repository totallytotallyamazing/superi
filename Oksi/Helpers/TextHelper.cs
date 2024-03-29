﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;

namespace Helpers
{
    public static class TextHelper
    {
        public static string GetYoutubeId(string objectTag)
        {
            string result = null;
            Regex regex = new Regex("/v/([^\\&^\"]+?)\\&hl");
            Match match = regex.Match(objectTag);
            if (match.Success)
            {
                result = match.Groups[1].Value;
            }
            return result;
        }

        public static string GetYoutubeId2(string url)
        {
            string[] x = url.Split(new[] { "watch?v=", "/v/" }, StringSplitOptions.RemoveEmptyEntries);
            return x[1];
        }

        public static string GetYoutubeId3(string url)
        {
            string[] x = url.Split(new[] { "/v/", "&", "?" }, StringSplitOptions.RemoveEmptyEntries);
            return x[1];
        }

        public static string Transliterate(string source)
        {
            string[] russian = "aбвгдеёжзийклмнопрстуфхцчшщъыьэюя"
                .ToCharArray().Select(c => new String(c, 1)).ToArray();
            string[] english = "a/b/v/g/d/e/e/zh/z/i/y/k/l/m/n/o/p/r/s/t/u/f/h/ts/ch/sh/shch//y/'/e/iu/ia"
                .Split('/');
            string result = source;
            for (int i = 0; i < russian.Length; i++)
            {
                result = result.Replace(russian[i], english[i]);
            }
            return result;
        }
    }
}
