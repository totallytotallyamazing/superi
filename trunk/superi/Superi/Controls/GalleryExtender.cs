using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using AjaxControlToolkit;
using System.ComponentModel;
using System.Web.UI.WebControls;

[assembly: WebResource("Superi.Resources.GalleryExtenderBehavior.js" , "text/javascript")]
[assembly: WebResource("Superi.Resources.jquery.galleria.js" , "text/javascript")]
[assembly: WebResource("Superi.Resources.galleria.css", "text/css")]

namespace Superi.CustomControls
{
    [ClientScriptResource("Superi.CustomControls.GalleryExtender", "Superi.Resources.GalleryExtenderBehavior.js")]
  //  [ClientScriptResource(null, "Superi.Resources.jquery.galleria.js")]
    [ClientCssResource("Superi.Resources.galleria.css")]
    [TargetControlType(typeof(Control))]
    public class GalleryExtender : ExtenderControlBase
    {
        #region Properties
        [ExtenderControlProperty]
        [ClientPropertyName("imagePlaceHolderID")]
        [DefaultValue(null)]
        //[IDReferenceProperty(typeof(WebControl))]
        public string ImagePlaceHoldeID
        {
            get { return GetPropertyValue<string>("ImagePlaceHoldeID", null); }
            set 
            { 
                if(string.IsNullOrEmpty(value))
                    SetPropertyValue<string>("ImagePlaceHoldeID", null); 
                else
                    SetPropertyValue("ImagePlaceHoldeID", value); 
            }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("cssClass")]
        [DefaultValue("")]
        public string CssClass
        {
            get { return GetPropertyValue("CssClass", ""); }
            set { SetPropertyValue("CssClass", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("nextImageCaption")]
        [DefaultValue("")]
        public string NextImageCaption
        {
            get { return GetPropertyValue("NextImageCaption", ""); }
            set { SetPropertyValue("NextImageCaption", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("fadeInCaption")]
        [DefaultValue(true)]
        public bool FadeInCaption
        {
            get { return GetPropertyValue("FadeInCaption", true); }
            set { SetPropertyValue("FadeInCaption", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("fadeInImage")]
        [DefaultValue(true)]
        public bool FadeInImage
        {
            get { return GetPropertyValue("FadeInImage", true); }
            set { SetPropertyValue("FadeInImage", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("fadeInThumbnailsOnLoad")]
        [DefaultValue(true)]
        public bool FadeInThumbnailsOnLoad
        {
            get { return GetPropertyValue("FadeInThumbnailsOnLoad", true); }
            set { SetPropertyValue("FadeInThumbnailsOnLoad", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("fadeOutInactiveThumbnails")]
        [DefaultValue(true)]
        public bool FadeOutInactiveThumbnails
        {
            get { return GetPropertyValue("FadeOutInactiveThumbnails", true); }
            set { SetPropertyValue("FadeOutInactiveThumbnails", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("fadeInActiveThumbnail")]
        [DefaultValue(true)]
        public bool FadeInActiveThumbnail
        {
            get { return GetPropertyValue("FadeInActiveThumbnail", true); }
            set { SetPropertyValue("FadeInActiveThumbnail", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("enableHistory")]
        [DefaultValue(true)]
        public bool EnableHistory
        {
            get { return GetPropertyValue("EnableHistory", true); }
            set { SetPropertyValue("EnableHistory", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("nextImageOnClick")]
        [DefaultValue(true)]
        public bool NextImageOnClick
        {
            get { return GetPropertyValue("NextImageOnClick", true); }
            set { SetPropertyValue("NextImageOnClick", value); }
        }

        [ExtenderControlProperty]
        [ClientPropertyName("useHoverEffects")]
        [DefaultValue(true)]
        public bool UseHoverEffects
        {
            get { return GetPropertyValue("UseHoverEffects", true); }
            set { SetPropertyValue("UseHoverEffects", value); }
        } 
        #endregion

        public GalleryExtender() 
        { 
        }
    }
}
