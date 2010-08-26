<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="MBrand.Models" %>
<%
    
    string chapter = ViewContext.RouteData.Values["action"].ToString();

    if (chapter == "See")
        chapter = ViewContext.RouteData.Values["type"].ToString();

    string sitesClass, vcardsClass, logoClass, polyClass, textClass, videoClass;
    sitesClass = vcardsClass = logoClass = polyClass = textClass = videoClass = "seeMenuItem";

    string sitesContent, vcardsContent, logosContent, polyContent, textContent, videoContent;
    sitesContent = vcardsContent = logosContent = polyContent = textContent = videoContent = "";

    Func<WorkType, string> CreateContent = delegate(WorkType workType)
    {
        StringBuilder sb = new StringBuilder();
        int workGroupId = int.MinValue;
        if (ViewContext.RouteData.Values["id"] != null && !string.IsNullOrEmpty(ViewContext.RouteData.Values["id"].ToString()))
            workGroupId = Convert.ToInt32(ViewContext.RouteData.Values["id"]);
        using (DataStorage context = new DataStorage())
        {
            int workTypeId = (int)workType;
            var items = context.WorkGroups.Where(wg => wg.Type == workTypeId).OrderByDescending(wg=>wg.Date).Select(wg => new { Id = wg.Id, Name = wg.Name });
            string linkFormat = "<a href=\"/{0}/{1}/{2}\" {4}>{3}</a>";
            string linkClass = "class=\"current\"";
            foreach (var item in items)
            {
                string finalLinkClass = (item.Id == workGroupId) ? linkClass : string.Empty;
                sb.AppendFormat(linkFormat, "See", workType.ToString(), item.Id, item.Name, finalLinkClass);
                sb.Append("<br />");
            }
        }
        if (Request.IsAuthenticated)
        {
            sb.Append(Html.ActionLink("Добавить", "AddEditWorkGroup", "Admin", new { workType = workType }, new { @class="adminLink", id = "addWorkGroup" }));
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
        case "Video":
            videoClass += " bold";
            videoContent = CreateContent(WorkType.Video);
            break;
        default:
            break;
    }
%>
<%if(Request.IsAuthenticated){ %>

<script type="text/javascript">
    $(function() {
        $("#addWorkGroup").fancybox({ hideOnContentClick: false, frameWidth: 400, frameHeight: 150 });
    })    
</script>

<%} %>
<div id="seeMenu">
    <div class="seeMenuItemSplitter">
    </div>
    <div class="<%= sitesClass %>">
        <a href="/See/Site">
            Сайты
        </a>
    </div>
    <div class="seeMenuItemSplitter">
        <%= sitesContent %>
    </div>
    <div class="<%= vcardsClass %>">
        <a href="/See/Vcard">
            Фирменный стиль
        </a>
    </div>
    <div class="seeMenuItemSplitter">
        <%= vcardsContent %>
    </div>
    <div class="<%= polyClass %>">
        <a href="/See/Poly">
            Реклама
        </a>
    </div>
    <div class="seeMenuItemSplitter">
        <%= polyContent %>
    </div>
    <div class="<%= textClass %>">
        <a href="/See/Text">
            Брендинг
        </a>
    </div>
    <div class="seeMenuItemSplitter">
        <%= textContent %>
    </div>
    <div class="<%= videoClass %>">
        <a href="/See/Video">
            Видеодизайн
        </a>
    </div>
    <div class="seeMenuItemSplitter">
        <%= videoContent %>
    </div>
</div>
