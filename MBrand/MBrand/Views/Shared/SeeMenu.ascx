<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="MBrand.Models" %>
<%
    
    string chapter = ViewContext.RouteData.Values["action"].ToString();

    if (chapter == "See")
        chapter = ViewContext.RouteData.Values["type"].ToString();

    string sitesClass, vcardsClass, logoClass, polyClass, textClass;
    sitesClass = vcardsClass = logoClass = polyClass = textClass = "seeMenuItem";

    string sitesContent, vcardsContent, logosContent, polyContent, textContent;
    sitesContent = vcardsContent = logosContent = polyContent = textContent = "";

    Func<WorkType, string> CreateContent = delegate(WorkType workType)
    {
        StringBuilder sb = new StringBuilder();
        using (DataStorage context = new DataStorage())
        {
            var items = context.WorkGroups.Where(wg => wg.Type == (int)workType).Select(wg => new { Id = wg.Id, Name = wg.Name });
            foreach (var item in items)
            {
                sb.Append(Html.ActionLink(item.Name, workType.ToString(), "See", new { id = item.Id }));
                sb.Append("<br />");
            }
        }
        if (Request.IsAuthenticated)
        { 
            sb.Append(Html.ActionLink)
        }
        return sb.ToString();
    };

    switch (chapter)
    {
        case "Sites":
        case "Site":
            sitesClass += " bold";
            sitesContent = CreateContent(WorkType.Site);
            break;
        case "Vcards":
        case "Vcard":
            vcardsClass += " bold";
            vcardsContent = CreateContent(WorkType.Vcard);
            break;
        case "Logo":
        case "Logos":
            logoClass += " bold";
            logosContent = CreateContent(WorkType.Logo);
            break;
        case "Poly":
            polyClass += " bold";
            polyContent = CreateContent(WorkType.Poly);
            break;
        case "Text":
            textClass += " bold";
            textContent = CreateContent(WorkType.Text);
            break;
        default:
            break;
    }
%>
<div id="seeMenu">
    <div class="seeMenuItemSplitter">
    </div>
    <div class="<%= sitesClass %>">
        <%= Html.ActionLink("Сайты", "Sites", "See")%>
    </div>
    <div class="seeMenuItemSplitter">
        <%= sitesContent %>
    </div>
    <div class="<%= vcardsClass %>">
        <%= Html.ActionLink("Визитки", "Vcards", "See")%>
    </div>
    <div class="seeMenuItemSplitter">
        <%= vcardsContent %>
    </div>
    <div class="<%= logoClass %>">
        <%= Html.ActionLink("Логотипы", "Logos", "See")%>
    </div>
    <div class="seeMenuItemSplitter">
        <%= logosContent %>
    </div>
    <div class="<%= polyClass %>">
        <%= Html.ActionLink("Полиграфия", "Poly", "See")%>
    </div>
    <div class="seeMenuItemSplitter">
        <%= polyContent %>
    </div>
    <div class="<%= textClass %>">
        <%= Html.ActionLink("Работа с текстом", "Text", "See")%>
    </div>
    <div class="seeMenuItemSplitter">
        <%= textContent %>
    </div>
</div>
