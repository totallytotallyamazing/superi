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

        private int _TextID = int.MinValue;
        public Resource _Values = new Resource();
        private LanguageList _LanguageList = new LanguageList(true);
        private ResourceEditorType _Type = ResourceEditorType.SingleLine;
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
         //   set { ViewState["lc"] = value; }
        }

        #region Public properties
        /// <summary>
        /// Teh tepe of input (SingleLine, MultiLine, RichText)
        /// </summary>
        public ResourceEditorType Type
        {
            get 
            {
                if (EnableViewState && ViewState["type"] != null)
                    _Type = (ResourceEditorType)Convert.ToInt32(ViewState["type"]);
                return _Type; 
            }
            set 
            {
                if (EnableViewState)
                    ViewState["type"] = value;
                _Type = value; 
            }
        }

        /// <summary>
        /// The resource ID to get from DB
        /// </summary>
        public int TextID
        {
            get 
            {
                if (EnableViewState && ViewState["textId"] != null)
                    _TextID = Convert.ToInt32(ViewState["textId"]);
                return _TextID; 
            }
            set
            {
                if (EnableViewState)
                    ViewState["textId"] = value;
                _TextID = value; 
            }
        }

        /// <summary>
        /// Returns TextID afert resource is saved
        /// </summary>
        public int ResourceId
        {
            set 
            {
                _TextID = value;
            }
            get
            {
                _TextID = Values.Save();
                return _TextID;
            }

        }

        public Resource Values
        {
            get
            {
                Resource values = new Resource(TextID);
                values.Items.Clear();
                foreach (string key in LanguageControls.Keys)
                {
                    Context.Trace.Write("resEditor/values", "key=" + key);
                    values.Items.Add(key, Context.Request.Form[LanguageControls[key].ToString()]);
                }
                return values;
            }
        }

        public LanguageList LanguageList
        {
            get { return _LanguageList; }
            set { _LanguageList = value; }
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
            LanguageControls.Clear();
            bool isFirst = true;
            foreach (Language language in LanguageList)
            {
                div = new HtmlGenericControl("div");
                div.ID = ID + "_div_" + language.Code;
                Controls.Add(div);
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
                if (isFirst)
                {
                    div.Style["display"] = "block";
                    isFirst = false;
                }
                else
                    div.Style["display"] = "none";
            }
        }
        #endregion

        #region Events

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string langList = "";
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
        }
        #endregion
    }
}