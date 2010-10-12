<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<% if(Roles.IsUserInRole("Administrators")){ %>
    <p class="adminLink">
        <%= Html.ActionLink("редактировать", "Edit", "Content", new { area="Admin", id=ViewData["contentName"] }, null)%>
    </p>
<%} %>

<%= ViewData["text"] %>