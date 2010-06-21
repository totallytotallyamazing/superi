<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Article>" %>
<div class="articleItem">
    <div class="articleItemDate"><%= Model.Date.ToString("dd.MM.yyyy")%></div>
    <div class="articleItemTitle"><%=Model.Title %></div>
    <div class="articleItemText"><%=Model.Text %></div>
    <% if(Roles.IsUserInRole("Administrators")){ %>
    <p class="adminLink">
        <%= Html.ActionLink("Редактировать", "AddEdit","Articles", new { area="Admin", id = Model.Id },null)%>
        </p>
    <%} %>
</div>

        


