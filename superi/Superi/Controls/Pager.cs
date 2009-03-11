using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Superi.CustomControls
{
    public enum PagerModes { Link, PostBack }

    [DefaultProperty("")]
    [ToolboxData("<{0}:Pager runat=server></{0}:Pager>")]
    public class Pager : WebControl
    {
        #region Events
        public event EventHandler PageChanged;
        #endregion

        #region Fields
        private int pageCount = 0;
        private int currentPage = -1;
        private int startPage = 1;
        private PagerModes mode;
        private string basePath = "";
        private string pageCssClass = "";
        private string currentPageCssClass = "";
        #endregion

        #region Public Properties
        public string PageCssClass
        {
            get
            {
                if (EnableViewState)
                {
                    if (ViewState["PageCssClass"] != null)
                        pageCssClass = ViewState["PageCssClass"].ToString();
                }
                return pageCssClass;
            }
            set
            {
                ViewState["PageCssClass"] = value;
                pageCssClass = value;
            }
        }


        public int StartPage
        {
            get
            {
                if (ViewState["StartPage"] != null)
                    startPage = Convert.ToInt32(ViewState["StartPage"]);
                return startPage;
            }
            set
            {
                ViewState["StartPage"] = value;
                startPage = value;
            }
        }

        public string CurrentPageCssClass
        {
            get
            {
                if (ViewState["CurrentPageCssClass"] != null)
                    currentPageCssClass = ViewState["CurrentPageCssClass"].ToString();
                return currentPageCssClass;
            }
            set
            {
                ViewState["CurrentPageCssClass"] = value;
                currentPageCssClass = value;
            }
        }

        public int PageCount
        {
            get
            {
                if (ViewState["PageCount"] != null)
                    pageCount = Convert.ToInt32(ViewState["PageCount"]);
                return pageCount;
            }
            set
            {
                ViewState["PageCount"] = value;
                pageCount = value;
            }
        }

        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] != null)
                    currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
                return currentPage;
            }
            set
            {
                ViewState["PageCount"] = value;
                currentPage = value;
            }
        }

        public PagerModes Mode
        {
            get
            {
                if (ViewState["Mode"] != null)
                    mode = (PagerModes)Convert.ToInt32(ViewState["Mode"]);
                return mode;
            }
            set
            {
                ViewState["Mode"] = value;
                mode = value;
            }
        }

        public string BasePath
        {
            get
            {
                if (ViewState["BasePath"] != null)
                    basePath = ViewState["BasePath"].ToString();
                return basePath;
            }
            set
            {
                ViewState["BasePath"] = value;
                basePath = value;
            }
        }
        #endregion

        #region Methods

        protected override void CreateChildControls()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.Controls.Clear();
            base.CreateChildControls();
            LinkButton postedPage;
            HyperLink page;
            Label currentPageLabel;
            int pageNumber;
            Visible = pageCount > 1;
            for (int i = 0; i < pageCount; i++)
            {
                pageNumber = i + startPage;
                if (currentPage == i)
                {
                    currentPageLabel = new Label();
                    currentPageLabel.Text = pageNumber.ToString();
                    currentPageLabel.CssClass = currentPageCssClass;
                    this.Controls.Add(currentPageLabel);
                }
                else if (mode == PagerModes.PostBack)
                {
                    postedPage = new LinkButton();
                    postedPage.Text = pageNumber.ToString();
                    postedPage.Click += postedPage_Click;
                    postedPage.CssClass = pageCssClass;
                    this.Controls.Add(postedPage);
                }
                else
                {
                    page = new HyperLink();
                    page.NavigateUrl = basePath + i;
                    page.Text = pageNumber.ToString();
                    page.CssClass = pageCssClass;
                    this.Controls.Add(page);
                }
            }
        }

        void postedPage_Click(object sender, EventArgs e)
        {
            Initialize();
            OnPageChanged(e);
        }

        protected virtual void OnPageChanged(EventArgs e)
        {
            if (PageChanged != null)
                PageChanged(this, e);
        }
        #endregion

    }
}
