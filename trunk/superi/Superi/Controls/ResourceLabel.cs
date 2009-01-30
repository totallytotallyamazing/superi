using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Superi.Features;

namespace Superi.CustomControls
{
    public class ResourceLabel:Label
    {
        #region Fields
        private string resourceName;
        private int resourceId = int.MinValue;
        private string language;
        #endregion

        #region Properties
        public string ResourceName
        {
            get { return resourceName; }
            set { resourceName = value; }
        }

        public int ResourceId
        {
            get { return resourceId; }
            set { resourceId = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        #endregion

        protected override void  OnPreRender(EventArgs e)
        {
            base.OnInit(e);
            if(string.IsNullOrEmpty(language))
                throw new ArgumentException("The language must be set");
            if (!string.IsNullOrEmpty(resourceName) && resourceId > 0)
                throw new ArgumentException("Cannot process content when both ResourceName and ResourceId are set.");
            Features.Text text = null;
            if(resourceId>0)
                text = new Text(resourceId);
            if(!string.IsNullOrEmpty(resourceName))
                text = new Text(resourceName);
            if(text.ID>0)
                this.Text = text.TextResource[language];
        }

    }
}
