using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

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
    }
}
