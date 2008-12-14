using System;
using System.Web.UI.HtmlControls;
using Superi.Features;

public partial class Controls_MainMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NavigationList navigationList = new NavigationList(true);
        if (navigationList.Count > 0)
        {
            int i = 0;
            bool isLast = false;
            HtmlTable table = new HtmlTable();
            table.CellPadding = 0;
            table.CellSpacing = 0;
            HtmlTableRow row = new HtmlTableRow();
            table.Controls.Add(row);
            HtmlTableCell cell;
            foreach (Navigation navigation in navigationList)
            {
                cell = new HtmlTableCell();
                if (navigationList.Count - 1 == i)
                    isLast = true;
                i++;
                bool current = (navigation.ID == WebSession.NavigationID && Request.Url.AbsoluteUri.ToLower().IndexOf("default.aspx")==-1);
                if(!current)
                {
                    Navigation nav = new Navigation(WebSession.NavigationID);
                    current = (nav.ParentID == navigation.ID);
                }
                
                GenerateMenuCell(getNavigationText(navigation), GetNavigationLink(navigation),cell, current);
                row.Controls.Add(cell);
                if (!isLast)
                {
                    cell = new HtmlTableCell();
                    //GenerateSeparatorCell(cell);
                    cell.Attributes["class"] = "menuDivSeprator";
                    row.Controls.Add(cell);
                }
                
            }
            Controls.Add(table);
        }
    }

    private string GetNavigationLink(Navigation navigation)
    {
        return DefaultValues.BaseUrl + navigation.Name;
    }


    private string getNavigationText(Navigation navigation)
    {
        string result;
        if (WebSession.Language!= null)
        {
            string language = WebSession.Language;
            if (navigation.Texts != null && navigation.Texts.Items.Count > 0)
                result = navigation.Texts[language];
            else
                result = navigation.Text;
        }
        else result = navigation.Text;
        return result;
    }


    private void GenerateMenuCell(string text, string link, HtmlTableCell cell, bool Current)
    {
        cell.Attributes.Add("class", "menuDiv");
        cell.Attributes.Add("valign", "middle");
        if (!Current)
        {
            cell.Attributes.Add("onmouseover", "menuDivOver(this);");
            cell.Attributes.Add("onmouseout", "menuDivOut(this);");
        }
        else
        {
            cell.Style["background-image"] = "url(" + DefaultValues.BaseImageUrl + "menuHover.jpg)";
        }
        HtmlAnchor anchor = new HtmlAnchor();
        anchor.Attributes.Add("class", "menuLink");
        anchor.InnerText = text;
        anchor.HRef = link;
        cell.Controls.Add(anchor);
    }

}
