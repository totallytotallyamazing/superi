<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%if(Request.IsAuthenticated){ %>
<div>
    <%= Html.ActionLink("������", "Cities", "Admin", null, null) %>
    &nbsp;/&nbsp;
    <%= Html.ActionLink("��������", "Routes", "Admin", null, null) %>
</div>
<%} %>