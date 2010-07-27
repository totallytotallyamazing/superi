<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%= Ajax.ScriptInclude("/Scripts/start.js") %>
<%= Ajax.ScriptInclude("/Scripts/extended/ExtendedControls.js")%>
<script type="text/javascript">
    Sys.require(Sys.components.watermark, function() {
        $("#searchField").watermark("Слово + “Enter”", "watermark");
    });   
</script>

<div id="search">
    <% using(Html.BeginForm("Search", "Products", FormMethod.Post, null)){ %>
    <p>
        <%= Html.TextBox("searchField") %>
    </p>
    <%} %>
</div>



