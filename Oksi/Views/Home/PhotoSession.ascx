<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>
<%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
<%= Ajax.ScriptInclude("/Scripts/jquery.fancybox.js") %>
<%= Ajax.Create("ClientLibrary.PhotoSessionExtender", new { id = "PageManager" }, null, "pageExtender")%>

<div id="photoSession">
    <div id="sessionTitle">
        <%= Html.ActionLink("Фотосессия для журнала L’OFFICIEL.", "Index", "Gallery", null, new { rel = "async" })%>
    </div>
    <div id="sessionSubTitle">
        Краткая информация по фотосессии.
    </div>
    <a href="/Content/img/photo1.jpg" rel="photoSession" class="photoSession">
        <img src="/Content/img/photo1.jpg" />
    </a>
    <a href="/Content/img/photo2.jpg" rel="photoSession" class="photoSession">
        <img src="/Content/img/photo2.jpg" />
    </a>
    <a href="/Content/img/photo3.jpg" rel="photoSession" class="photoSession">
        <img src="/Content/img/photo3.jpg" />
    </a>
</div>