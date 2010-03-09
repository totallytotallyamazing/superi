<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%if(Request.IsAuthenticated){ %>
<div>
    <%= Html.ActionLink("Города", "Cities", "Admin", null, null) %>
    &nbsp;/&nbsp;
    <%= Html.ActionLink("Маршруты", "Routes", "Admin", null, null) %>
</div>
<%} %>