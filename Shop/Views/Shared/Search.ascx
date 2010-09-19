<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%= Ajax.ScriptInclude("/Scripts/jquery.watermark.js")%>

<script type="text/javascript">
    $(function () {
        $("#searchField").watermark({ html: "Слово + “Enter”", cls: "watermark"});
    })
</script>

<div id="search">
    <% using(Html.BeginForm("Search", "Products", FormMethod.Post, null)){ %>
    <p>
        <%= Html.TextBox("searchField") %>
    </p>
    <%} %>
</div>



