<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<div id="search">
    <% using(Html.BeginForm("Search", "Products", FormMethod.Post, null)){ %>
    <p>
        <%= Html.TextBox("searchField") %>
    </p>
    <%} %>
</div>



