<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.Article>" %>
<%@ Import Namespace="Dev.Helpers" %>
<%--<div class="articleItem" name="<%= Model.Id %>" id="<%= Model.Id %>">
    <div class="articleItemDate"><%= Model.Date.Day%> <%= Model.Date.GetMonthName() %> <%= Model.Date.Year %></div>
    <div class="articleItemTitle"><%=Model.Title %></div>
    <div class="articleItemText"><%=Model.Text %></div>
    <% if(Roles.IsUserInRole("Administrators")){ %>
    <p class="adminLink">
        <%= Html.ActionLink("Редактировать", "AddEdit","Articles", new { area="Admin", id = Model.Id, type = Model.Type },null)%> |
        <%= Html.ActionLink("Удалить", "Delete", "Articles", new { area = "Admin", id = Model.Id }, new { onclick = "return confirm('Вы уверены?')" })%>
        </p>
    <%} %>
</div>--%>

    <div id="news1">
        <p class="it3">
            <%= Model.Date.Day%>
            <%= Model.Date.GetMonthName() %>
            <%= Model.Date.Year %>
            года</p>
        <p class="it1">
            <b>
                <%=Model.Title %></b></p>
        <br />
        <p class="dt3">
            <%=Model.Text %></p>
        <% if (Roles.IsUserInRole("Administrators"))
           { %>
        <p class="adminLink">
            <%= Html.ActionLink("Редактировать", "AddEdit","Articles", new { area="Admin", id = Model.Id, type = Model.Type },null)%>
            |
            <%= Html.ActionLink("Удалить", "Delete", "Articles", new { area = "Admin", id = Model.Id }, new { onclick = "return confirm('Вы уверены?')" })%>
        </p>
        <%} %>
        <br />
    </div>

