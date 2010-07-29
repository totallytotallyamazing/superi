<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%= Ajax.ScriptInclude("/Scripts/start.js") %>
<%= Ajax.ScriptInclude("/Scripts/extended/ExtendedControls.js")%>
<script type="text/javascript">
    Sys.require(Sys.components.watermark, function() {
        $("#searchField").watermark("Введите текст и нажмите “Enter”", "searchWatermark");
    });   
</script>
<div id="searchText">
    <p>
        ПОИСК ПО КАТАЛОГУ
    </p>
</div>
<div id="search">
    <% using(Html.BeginForm("Search", "Products", FormMethod.Get, null)){ %>
        <%= Html.TextBox("searchField") %>
    <%} %>
    <p>
        <a href="#">Расширенный поиск</a>
    </p>
</div>