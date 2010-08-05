<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Article>" %>
<%@ Import Namespace="Dev.Helpers" %>
<div class="articleItem" name="<%= Model.Id %>" id="<%= Model.Id %>">
    <div class="articleItemDate"><%= Model.Date.Day%> <%= Model.Date.GetMonthName() %> <%= Model.Date.Year %></div>
    <div class="articleItemTitle"><%=Model.Title %></div>
    <div class="articleItemText"><%=Model.Text %></div>
    <% if(Roles.IsUserInRole("Administrators")){ %>
    <p class="adminLink">
        <%= Html.ActionLink("Редактировать", "AddEdit","Articles", new { area="Admin", id = Model.Id, type = Model.Type },null)%>
        </p>
    <%} %>
</div>

        


