using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using FredCK.FCKeditorV2;
using Superi.Features;

/// <summary>
/// Summary description for ResourceEditor
/// </summary>
namespace Superi.CustomControls
{
    /// <summary>
    /// Possible input types for the resource editor
    /// </summary>
    public enum ResourceEditorType
    {
        SingleLine,
        MultiLine,
        RichText
    }

    /// <summary>
    /// The resource editor control
    /// </summary>
    public class ResourceEditor : Control
    {
        #region Private fields
        //private string aPrefix = "";
        //private string divPrefix = "";
        private readonly string _script = "function toggleDivs(lang, id, prefix)" + Environment.NewLine +
        "{" + Environment.NewLine +
            "var lng;" + Environment.NewLine +
            "for (lng in langs)" + Environment.NewLine +
            "{" + Environment.NewLine +
                "var lngVal = langs[lng];" + Environment.NewLine +
                "var el = document.getElementById(prefix + '_div_' +lngVal);" + Environment.NewLine +
                "var aEl = document.getElementById(prefix + '_a_' +lngVal);" + Environment.NewLine +
                "if(lngVal===lang)" + Environment.NewLine +
                "{" + Environment.NewLine +
"                    el.style.display='block';" + Environment.NewLine +
"                    aEl.style.border='1px solid #8c8c8c';" + Environment.NewLine +
                "}" + Environment.NewLine +
                "else" + Environment.NewLine +
                "{" + Environment.NewLine +
"                    el.style.display='none';" + Environment.NewLine +
"                    aEl.style.border='none';" + Environment.NewLine +
                "}" + Environment.NewLine +
            "}" + Environment.NewLine +
        "}";
        /*
                private string _dimensionsScript = "var lng1;" + Environment.NewLine +
                    "for (lng1 in langs)" + Environment.NewLine +
                    "{" + Environment.NewLine +
                        "var lngVal = langs[lng1];" + Environment.NewLine +
                        "var el = document.getElementById('%DIV_PREFIX%'+lngVal);" + Environment.NewLine +
        "                    el.childNodes[0].style.height='90%';" + Environment.NewLine +
                    "}";
        */
        private int _TextID = int.MinValue;
        private Resource _Values = new Resource();
        private string _DefaultValue = "";
        private LanguageList _LanguageList = new LanguageList(true);
        //  private Hashtable LangusgeControls = new Hashtable();
        private object DefaultControl = null;
        private ResourceEditorType _Type = ResourceEditorType.SingleLine;
        private bool _DisplayDefault = false;
        private int richHeight = 0;
        #endregion

        private Hashtable LanguageControls
        {
            get
            {
                if (ViewState["lc"] == null)
                    ViewState["lc"] = new Hashtable();
                return (Hashtable)ViewState["lc"];
            }
            set { ViewState["lc"] = value; }
        }

        #region Public properties
        public ResourceEditorType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public int TextID
        {
            get { return _TextID; }
            set { _TextID = value; }
        }

        public Resource Values
        {
            get
            {
                Resource values = new Resource(TextID);
                values.Items.Clear();
                LanguageControls = (Hashtable)Context.Session["LanguageControls_" + ID];
                //            switch (Type)
                //          {
                //                    case ResourceEditorType.SingleLine:
                foreach (string key in LanguageControls.Keys)
                {
                    values.Items.Add(key, Context.Request.Form[LanguageControls[key].ToString()]);
                }
                //                      break;
                //    case ResourceEditorType.MultiLine:
                //        foreach (string key in LangusgeControls.Keys)
                //        {
                //            values.Items.Add(key, Context.Request.Form[((TextBox) LangusgeControls[key]).UniqueID]);
                //        }
                //        break;

                //    case ResourceEditorType.RichText:
                //        foreach (string key in LangusgeControls.Keys)
                //        {
                //            values.Items.Add(key, Context.Request.Form[((FCKeditor) LangusgeControls[key]).UniqueID]);
                //        }
                //        break;
                //}
                return values;
            }
        }

        public string DefaultValue
        {
            get
            {
                DefaultControl = Context.Session["DefaultControl_" + ID];
                if (DefaultControl != null)
                {
                    switch (Type)
                    {
                        case ResourceEditorType.SingleLine:
                            if (string.IsNullOrEmpty(Context.Request.Form[((TextBox)DefaultControl).UniqueID]))
                                _DefaultValue = ((TextBox)DefaultControl).Text;
                            else
                                _DefaultValue = Context.Request.Form[((TextBox)DefaultControl).UniqueID];
                            return _DefaultValue;
                        case ResourceEditorType.MultiLine:
                            if (string.IsNullOrEmpty(Context.Request.Form[((TextBox)DefaultControl).UniqueID]))
                                _DefaultValue = ((TextBox)DefaultControl).Text;
                            else
                                _DefaultValue = Context.Request.Form[((TextBox)DefaultControl).UniqueID];
                            return _DefaultValue;
                        case ResourceEditorType.RichText:
                            if (string.IsNullOrEmpty(Context.Request.Form[((FCKeditor)DefaultControl).UniqueID]))
                                _DefaultValue = ((FCKeditor)DefaultControl).Value;
                            else
                                _DefaultValue = Context.Request.Form[((FCKeditor)DefaultControl).UniqueID];
                            return _DefaultValue;
                    }
                }
                return _DefaultValue;
            }
            set
            {
                DefaultControl = Context.Session["DefaultControl_" + ID];
                if (DefaultControl != null)
                {
                    switch (Type)
                    {
                        case ResourceEditorType.SingleLine:
                            ((TextBox)DefaultControl).Text = value;
                            break;
                        case ResourceEditorType.MultiLine:
                            ((TextBox)DefaultControl).Text = value;
                            break;
                        case ResourceEditorType.RichText:
                            ((FCKeditor)DefaultControl).Value = value;
                            break;
                    }
                }
                _DefaultValue = value;
            }
        }

        public LanguageList LanguageList
        {
            get { return _LanguageList; }
            set { _LanguageList = value; }
        }

        public bool DisplayDefault
        {
            get { return _DisplayDefault; }
            set { _DisplayDefault = value; }
        }

        public int RichHeight
        {
            get { return richHeight; }
            set { richHeight = value; }
        }

        #endregion

        #region Constructors

        #endregion

        #region Private methods
        private void GenerateLangsTable()
        {

            HtmlTable table = new HtmlTable();
            table.CellPadding = 5;
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell;

            if (DisplayDefault)
            {
                HtmlAnchor aDefault = new HtmlAnchor();
                aDefault.InnerText = "Default";
                aDefault.ID = ID + "_a_Default";
                aDefault.HRef = "javascript:toggleDivs('Default', '" + ID + "', '" + ClientID + "')";
                aDefault.Style["border"] = "1px solid #8c8c8c";
                cell = new HtmlTableCell();
                cell.Controls.Add(aDefault);
                row.Controls.Add(cell);
            }
            bool isFirst = true;
            foreach (Language language in LanguageList)
            {
                HtmlAnchor a = new HtmlAnchor();
                a.InnerText = language.Name;
                a.HRef = "javascript:toggleDivs('" + language.Code + "', '" + ID + "', '" + ClientID + "')";
                a.ID = ID + "_a_" + language.Code;
                cell = new HtmlTableCell();
                cell.Controls.Add(a);
                row.Controls.Add(cell);
                //aPrefix = a.ClientID.Replace(ID + "_a_" + language.Code, "");
                if (!DisplayDefault)
                    if (isFirst)
                    {
                        a.Style["border"] = "1px solid #8c8c8c";
                        isFirst = false;
                    }
            }
            table.Controls.Add(row);
            Controls.Add(table);
        }

        private void GenerateLangDivs()
        {
            HtmlGenericControl div;
            // string divPrefix = "";
            if (DisplayDefault)
            {
                div = new HtmlGenericControl("div");
                div.ID = ID + "_div_Default";
                Controls.Add(div);
                //divPrefix = div.ClientID.Replace(ID + "_div_Default", "");
                div.Style["width"] = "100%";
                div.Style["height"] = "100%";

                switch (Type)
                {
                    case ResourceEditorType.SingleLine:
                        TextBox textBox = new TextBox();
                        textBox.Text = DefaultValue;
                        textBox.Width = new Unit(98, UnitType.Percentage);
                        div.Controls.Add(textBox);
                        DefaultControl = textBox;
                        break;
                    case ResourceEditorType.MultiLine:
                        TextBox textBoxMulti = new TextBox();
                        textBoxMulti.TextMode = TextBoxMode.MultiLine;
                        textBoxMulti.Rows = 5;
                        textBoxMulti.Text = DefaultValue;
                        textBoxMulti.Width = new Unit(98, UnitType.Percentage);
                        div.Controls.Add(textBoxMulti);
                        DefaultControl = textBoxMulti;
                        break;
                    case ResourceEditorType.RichText:
                        FCKeditor richText = new FCKeditor();
                        richText.BasePath = "~/Administration/Controls/fckeditor/";
                        richText.Width = new Unit(98, UnitType.Percentage);
                        richText.Height = RichHeight > 0 ? new Unit(RichHeight, UnitType.Pixel) : new Unit(100, UnitType.Percentage);
                        richText.Value = DefaultValue;
                        div.Controls.Add(richText);
                        DefaultControl = richText;
                        break;
                }
                div.Style["display"] = "block";
                Context.Session["DefaultControl_" + ID] = DefaultControl;
            }
            LanguageControls.Clear();
            bool isFirst = true;
            foreach (Language language in LanguageList)
            {
                div = new HtmlGenericControl("div");
                div.ID = ID + "_div_" + language.Code;
                Controls.Add(div);
                //divPrefix = div.ClientID.Replace(ID + "_div_" + language.Code, "");
                div.Style["width"] = "100%";
                div.Style["height"] = "100%";

                switch (Type)
                {
                    case ResourceEditorType.SingleLine:
                        TextBox textBox = new TextBox();
                        if (_Values.Items.Count > 0)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(_Values[language.Code]))
                                    textBox.Text = _Values[language.Code];
                            }
                            catch
                            { }
                        }
                        textBox.Width = new Unit(98, UnitType.Percentage);
                        div.Controls.Add(textBox);
                        LanguageControls.Add(language.Code, textBox.UniqueID);
                        break;
                    case ResourceEditorType.MultiLine:
                        TextBox textBoxMulti = new TextBox();
                        textBoxMulti.TextMode = TextBoxMode.MultiLine;
                        textBoxMulti.Rows = 5;
                        if (_Values.Items.Count > 0)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(_Values[language.Code]))
                                    textBoxMulti.Text = _Values[language.Code];
                            }
                            catch { }
                        }
                        textBoxMulti.Width = new Unit(98, UnitType.Percentage);
                        div.Controls.Add(textBoxMulti);
                        LanguageControls.Add(language.Code, textBoxMulti.UniqueID);
                        break;
                    case ResourceEditorType.RichText:
                        FCKeditor richText = new FCKeditor();
                        richText.BasePath = "~/Administration/Controls/fckeditor/";
                        richText.Width = new Unit(98, UnitType.Percentage);
                        if (RichHeight > 0)
                            richText.Height = new Unit(RichHeight, UnitType.Pixel);
                        else
                            richText.Height = new Unit(100, UnitType.Percentage);
                        if (_Values.Items.Count > 0)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(_Values[language.Code]))
                                    richText.Value = _Values[language.Code];
                            }
                            catch { }
                        }
                        div.Controls.Add(richText);
                        LanguageControls.Add(language.Code, richText.UniqueID);
                        break;
                }
                Context.Session["LanguageControls_" + ID] = LanguageControls;
                //if (first)
                //{
                //    div.Style["display"] = "block";
                //    first = false;
                //}
                //else
                if (!DisplayDefault)
                {
                    if (isFirst)
                    {
                        div.Style["display"] = "block";
                        isFirst = false;
                    }
                    else
                        div.Style["display"] = "none";
                }
            }
        }
        #endregion

        #region Events

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string langList = "";
            if (DisplayDefault)
                langList += "'Default', ";
            foreach (Language language in LanguageList)
            {
                langList += "'" + language.Code + "',";
            }
            char[] chars = { ',' };
            langList = langList.TrimEnd(chars);
            Page.ClientScript.RegisterArrayDeclaration("langs", langList);
            if (TextID > 0)
            {
                _Values = new Resource(TextID);
            }
            GenerateLangsTable();
            GenerateLangDivs();
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript", _script, true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "dimscr", _dimensionsScript.Replace("%DIV_PREFIX%", divPrefix), true);
        }
        #endregion
    }
}