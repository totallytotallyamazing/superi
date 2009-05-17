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
    }
}
