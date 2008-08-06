using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Superi.CustomControls
{
    //[DefaultProperty("Text")]
    //[ToolboxData("<{0}:Scroll runat=server></{0}:Scroll>")]
    public class Scroll : WebControl
    {
        //[Bindable(true)]
        //[Category("Appearance")]
        //[DefaultValue("")]
        //[Localizable(true)]
        private int height = 0;
        private int width = 0;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptResource(this.GetType(), "Superi.Resources.scroll.js");
            HtmlGenericControl divContainer = new HtmlGenericControl("div");
            

        }
        
        //protected override void RenderContents(HtmlTextWriter output)
        //{
        //    output.Write(Text);
        //}

    }
}
