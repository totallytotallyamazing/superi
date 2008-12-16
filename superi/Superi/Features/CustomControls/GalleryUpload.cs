using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

namespace Superi.CustomControls
{
    public class GalleryUpload : Control
    {
        private FileUpload fuPreview;
        private FileUpload fuPicture;

        public FileUpload FuPreview
        {
            get { return fuPreview; }
            set { fuPreview = value; }
        }

        public FileUpload FuPicture
        {
            get { return fuPicture; }
            set { fuPicture = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fuPreview = new FileUpload();
            fuPicture = new FileUpload();
            Controls.Add(fuPreview);
            Controls.Add(fuPicture);
        }
    }
}
