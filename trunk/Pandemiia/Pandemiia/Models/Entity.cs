using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandemiia.Models
{
    public partial class Entity
    {
        public bool HasAdditionalContent()
        {
            return (this.EntityMusics.Count > 0 || this.EntityPictures.Count > 0 || this.EntityVideos.Count > 0);
        }

        public string GetTagString()
        {
            string result = "";
            bool first = true;
            foreach (EntityTagMapping tm in this.EntityTagMappings)
            {
                if (!first)
                {
                    result += " ";
                    first = false;
                }
                result += tm.Tag.TagName;
            }
            return result;
        }
    }
}
